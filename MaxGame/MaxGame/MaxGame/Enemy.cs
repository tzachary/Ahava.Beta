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
    public class Enemy : Sprite
    {
        double health;
        Texture2D myTexture;
        Vector2 myPosition;
        Vector2 myVelocity;
        Vector2 gravity;
        Vector2 myScreenSize;
        double touchDamage;
        Game1 myGame;
        double moveTimer;

        public Enemy(Texture2D texture, Vector2 position, Vector2 velocity, Vector2 grav, Vector2 screen, Game1 game)
        {
            health = 100;
            touchDamage = 10;
            myTexture = texture;
            myPosition = position;
            myVelocity = velocity;
            myScreenSize = screen;
            gravity = grav;
            myGame = game;
            moveTimer = 100;
        }

        public Texture2D getTex()
        {
            return myTexture;
        }

        public Vector2 getPosition()
        {
            return myPosition;
        }

        public double touchDmg()
        {
            return touchDamage;
        }

        public void takeDmg(double dmg)
        {
            health -= dmg;
        }

        public double getHealth()
        {
            return health;
        }

        public void Update(GameTime elapsedTime)
        {
            myVelocity -= gravity;
            if ((myPosition.Y + (myTexture.Height)) >= myScreenSize.Y)
            {
                myVelocity.Y = 0;
            }
            if (moveTimer <= 0)
            {
                myVelocity.X *= -1;
                moveTimer = 100;
            }
            moveTimer -= 1;
            myPosition += myVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, Color.White);
        }
    }
}
