using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MaxGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        MainChar main;
        Enemy enemy1;
        List<Dagger> myDaggers = new List<Dagger>();
        List<Bolt> myBolts = new List<Bolt>();
        List<Enemy> myEnemies = new List<Enemy>();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 764;
            graphics.ApplyChanges();
            base.Initialize();
        }


        public void AddBolt(MaxGame.Bolt b)
        {
            myBolts.Add(b);
        }

        public void AddDagger(Dagger s)
        {
            myDaggers.Add(s);
        }

        public void RemoveDagger(Dagger s)
        {
            myDaggers.Remove(s);
        }

        public void RemoveBolt(Bolt b)
        {
            myBolts.Remove(b);
        }

        public void AddEnemy(Enemy e)
        {
            myEnemies.Add(e);
        }

        public void RemoveEnemy(Enemy e)
        {
            myEnemies.Remove(e);
        }

        public Boolean CollisionMainAndEnemy(MainChar M, Enemy E)
        {
            Vector2 MPos = M.getPosition();
            Vector2 EPos = E.getPosition();
            if (MPos.X + (M.getTex().Width) > EPos.X && MPos.Y + (M.getTex().Height) > EPos.Y && MPos.X + (M.getTex().Width) < EPos.X + E.getTex().Width && MPos.Y + (M.getTex().Height) < EPos.Y + E.getTex().Height
                || MPos.X + (M.getTex().Width) > EPos.X && MPos.Y > EPos.Y && MPos.X + (M.getTex().Width) < EPos.X + E.getTex().Width && MPos.Y < EPos.Y + E.getTex().Height
                || MPos.X > EPos.X && MPos.Y + (M.getTex().Height) > EPos.Y && MPos.X < EPos.X + E.getTex().Width && MPos.Y + (M.getTex().Height) < EPos.Y + E.getTex().Height
                || MPos.X > EPos.X && MPos.Y > EPos.Y && MPos.X < EPos.X + E.getTex().Width && MPos.Y < EPos.Y + E.getTex().Height)
            {
                return true;
            }
            return false;
        }

        public Boolean CollisionDaggerAndEnemy(Dagger M, Enemy E)
        {
            Vector2 MPos = M.getPosition();
            Vector2 EPos = E.getPosition();
            if (MPos.X + (M.getTex().Width) > EPos.X && MPos.Y + (M.getTex().Height) > EPos.Y && MPos.X + (M.getTex().Width) < EPos.X + E.getTex().Width && MPos.Y + (M.getTex().Height) < EPos.Y + E.getTex().Height
                || MPos.X + (M.getTex().Width) > EPos.X && MPos.Y > EPos.Y && MPos.X + (M.getTex().Width) < EPos.X + E.getTex().Width && MPos.Y < EPos.Y + E.getTex().Height
                || MPos.X > EPos.X && MPos.Y + (M.getTex().Height) > EPos.Y && MPos.X < EPos.X + E.getTex().Width && MPos.Y + (M.getTex().Height) < EPos.Y + E.getTex().Height
                || MPos.X > EPos.X && MPos.Y > EPos.Y && MPos.X < EPos.X + E.getTex().Width && MPos.Y < EPos.Y + E.getTex().Height)
            {
                return true;
            }
            return false;
        }



        public Boolean CollisionBoltAndEnemy(Bolt B, Enemy E)
        {
            Vector2 MPos = B.getPosition();
            Vector2 EPos = E.getPosition();
            if (MPos.X + (B.getBolt1().Width) > EPos.X && MPos.Y + (B.getBolt1().Height) > EPos.Y && MPos.X + (B.getBolt1().Width) < EPos.X + E.getTex().Width && MPos.Y + (B.getBolt1().Height) < EPos.Y + E.getTex().Height
                || MPos.X + (B.getBolt1().Width) > EPos.X && MPos.Y > EPos.Y && MPos.X + (B.getBolt1().Width) < EPos.X + E.getTex().Width && MPos.Y < EPos.Y + E.getTex().Height
                || MPos.X > EPos.X && MPos.Y + (B.getBolt1().Height) > EPos.Y && MPos.X < EPos.X + E.getTex().Width && MPos.Y + (B.getBolt1().Height) < EPos.Y + E.getTex().Height
                || MPos.X > EPos.X && MPos.Y > EPos.Y && MPos.X < EPos.X + E.getTex().Width && MPos.Y < EPos.Y + E.getTex().Height)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            main = new MainChar(Content.Load<Texture2D>("testBox"), Content.Load<Texture2D>("daggerSprite"), Content.Load<Texture2D>("bolt2"), new Vector2(100f, 100f), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, -.2f), new Vector2(.5f, 0), new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), 10f, this);
            enemy1 = new Enemy(Content.Load<Texture2D>("enemyBox"), new Vector2(700, 100), new Vector2(-.5f, 0), new Vector2(0, -.2f), new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), this);
            AddEnemy(enemy1);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            InputManager.ActKeyboard(Keyboard.GetState());
            InputManager.ActMouse(Mouse.GetState());

            // TODO: Add your update logic here
            Dagger toBeRemoved = null;
            foreach (Dagger s in myDaggers)
            {
                s.Update(gameTime);
                foreach (Enemy e in myEnemies)
                {
                    if (CollisionDaggerAndEnemy(s, e))
                    {
                        e.takeDmg(s.getDamage());
                        toBeRemoved = s;
                    }
                }
            }

            //tried to mimic logic for dagger with the bolt
            Bolt toRemove = null;
            //Dagger toBeRemoved = null;
            foreach (Bolt b in myBolts)
            {
                b.Update(gameTime);
                foreach (Enemy e in myEnemies)
                {
                    if (CollisionBoltAndEnemy(b, e))
                    {
                        e.takeDmg(b.getDamage());
                        toRemove = b;
                    }
                }
            }


            RemoveDagger(toBeRemoved);
            Enemy removeThisEnemy = null;
            foreach (Enemy e in myEnemies)
            {
                e.Update(gameTime);
                if (CollisionMainAndEnemy(main, e))
                {
                    main.takeDamage(e.touchDmg());
                }
                if (e.getHealth() <= 0)
                {
                    removeThisEnemy = e;
                }
            }
            RemoveEnemy(removeThisEnemy);

            /*enemy1.Update(gameTime);
            if(CollisionMainAndEnemy(main, enemy1))
            {
                main.takeDamage(enemy1.touchDmg());
            }*/
            base.Update(gameTime);
            main.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            // TODO: Add your drawing code here
            main.Draw(spriteBatch);
            foreach (Dagger s in myDaggers)
            {
                s.Draw(spriteBatch);
            }

            foreach (Bolt b in myBolts)
            {
                b.Draw(spriteBatch);
            }
            foreach (Enemy e in myEnemies)
            {
                e.Draw(spriteBatch);
            }
            //enemy1.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
