using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MaxGame
{
    public class MainChar : Sprite
    {
        Texture2D myTexture;
        Texture2D daggerImage;
        //bolt img's
        Texture2D boltImg1;
        //Texture2D boltImg2;
        //Texture2D boltImg3;
        //Texture2D boltImg4;

        Flipbook idleBook;
        Flipbook attackBook;
        Flipbook jumpBook;

        private Vector2 myPosition;
        private Vector2 myVelocity;
        private Vector2 myAcceleration;
        private Vector2 myOrigin;
        private float myAngle;
        private double health;
        private Vector2 gravity;
        private Vector2 friction;
        private Vector2 myScreenSize;
        private Boolean doJump;
        private float LRspeed;
        private Boolean faceRight;

        private double dagTimer;
        private double boltTimer;

        Bolt myBolt = new Bolt();


        private Game1 myGame;
        private String healthString;
        private int daggerLevel;

        public MainChar(Texture2D texture, Texture2D daggerImg, Texture2D boltImg1, Vector2 position, Vector2 velocity, Vector2 acceleration, Vector2 setGrav, Vector2 setFric, Vector2 screen, float setLR, Game1 game)
        {
            myTexture = texture;
            myPosition = position;
            myAcceleration = acceleration;
            gravity = setGrav;
            friction = setFric;
            myScreenSize = screen;
            LRspeed = setLR;
            faceRight = true;
            myGame = game;
            daggerImage = daggerImg;
            dagTimer = 0;
            SetUpInput();
            daggerLevel = 1;

            this.boltImg1 = boltImg1;

        }

        public void SetUpInput()
        {
            GameAction left = new GameAction(this, this.GetType().GetMethod("GoLeft"), new object[0]);

            GameAction right = new GameAction(this, this.GetType().GetMethod("GoRight"), new object[0]);

            GameAction jump = new GameAction(this, this.GetType().GetMethod("Jump"), new object[0]);

            GameAction dagger = new GameAction(this, this.GetType().GetMethod("Dagger"), new object[0]);

            GameAction daggerUp = new GameAction(this, this.GetType().GetMethod("DaggerUp"), new object[0]);

            GameAction boltAttack = new GameAction(this, this.GetType().GetMethod("BoltAttack"), new object[0]);




            InputManager.AddToKeyboardMap(Keys.Left, left);
            InputManager.AddToKeyboardMap(Keys.Right, right);
            InputManager.AddToKeyboardMap(Keys.Space, jump);
            InputManager.AddToKeyboardMap(Keys.LeftShift, dagger);
            InputManager.AddToKeyboardMap(Keys.Tab, daggerUp);
            InputManager.AddToKeyboardMap(Keys.B, boltAttack);
            InputManager.AddToKeyboardMap(Keys.CapsLock, boltAttack);

        }

        public Texture2D getTex()
        {
            return myTexture;
        }

        public Vector2 getPosition()
        {
            return myPosition;
        }

        public void GoLeft()
        {
            myPosition.X -= LRspeed;
            faceRight = false;
        }

        public void GoRight()
        {
            myPosition.X += LRspeed;
            faceRight = true;
        }

        public void Jump()
        {
            if ((myPosition.Y + (myTexture.Height)) >= myScreenSize.Y)
            {
                doJump = true;
            }
        }

        public void takeDamage(double dmg)
        {
            health -= dmg;
            myVelocity.X = 20;
            if (faceRight)
            {
                myVelocity.X = -20;
            }
            myVelocity.Y = -10;
            myPosition.Y -= 1;
        }

        public void Dagger()
        {
            if (dagTimer < 0)
            {
                float dagSpeed = -30f;
                if (faceRight)
                {
                    dagSpeed = 30f;
                }
                if (daggerLevel == 1)
                {
                    Dagger myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                }
                if (daggerLevel == 2)
                {
                    Dagger myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2 + 50), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                    myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2 - 50), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                }
                if (daggerLevel == 3)
                {
                    Dagger myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2 + 90), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                    myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2 + 30), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                    myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2 - 90), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                    myDagger = new Dagger(daggerImage, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2 - 30), new Vector2(dagSpeed, 0));
                    myGame.AddDagger(myDagger);
                }
                dagTimer = 50;
            }
        }


        public void BoltAttack()
        {

            if (boltTimer < 0)
            {

                if (faceRight)
                {
                    myBolt = new Bolt(boltImg1, myPosition + new Vector2(myTexture.Width / 2, myTexture.Height / 2), new Vector2(0, 0));
                    myGame.AddBolt(myBolt);
                }
                else
                {
                    myBolt = new Bolt(boltImg1, myPosition + new Vector2(myTexture.Width - 1000, myTexture.Height / 2), new Vector2(0, 0));
                    myGame.AddBolt(myBolt);
                }
            }

            boltTimer = 100;



            //myGame.RemoveBolt(myBolt);

        }

        public void DaggerUp()
        {
            if (dagTimer < 0)
            {
                daggerLevel += 1;
                if (daggerLevel > 3)
                {
                    daggerLevel = 1;
                }
                dagTimer = 10;
            }
        }


        public void Update(GameTime elapsedTime)
        {
            myVelocity -= gravity;
            if ((myPosition.Y + (myTexture.Height)) >= myScreenSize.Y)
            {
                myVelocity.Y = 0;
            }
            if (doJump)
            {
                myVelocity.Y = -10;
                doJump = false;
            }
            if (myVelocity.X > 0)
            {
                myVelocity -= friction;
                if (myVelocity.X < 0)
                {
                    myVelocity.X = 0;
                }
            }
            if (myVelocity.X < 0)
            {
                myVelocity += friction;
                if (myVelocity.X > 0)
                {
                    myVelocity.X = 0;
                }
            }
            dagTimer -= 1;
            boltTimer -= 1;


            if (boltTimer == 95)
            {
                myGame.RemoveBolt(myBolt);
            }

            myPosition += myVelocity;
            myVelocity += myAcceleration;
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(myTexture, myPosition, Color.White);
        }
    }
}
