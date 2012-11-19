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
    public class Bolt : Sprite
    {

        Texture2D myTexture1;

        Vector2 position;
        Vector2 velocity;
        double damage;

        public Bolt(Texture2D myTexture1, Vector2 position, Vector2 velocity)
        {
            this.myTexture1 = myTexture1;

            this.position = position;
            this.velocity = velocity;

            damage = 175;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getBolt1()
        {
            return myTexture1;
        }




        public void Update(GameTime elapsedTime)
        {
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture1, position, Color.White);
        }

        public double getDamage()
        {
            return damage;
        }

    }
}
