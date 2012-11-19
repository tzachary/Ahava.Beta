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
    class Bolt : Sprite
    {

        Texture2D myTexture1;
        Texture2D myTexture2;
        Texture2D myTexture3;
        Texture2D currentBoltImage;
        Texture2D myTexture4;
        Vector2 position;
        Vector2 velocity;
        double damage;

        public Bolt(Texture2D myTexture1, Texture2D myTexture2, Texture2D myTexture3, Vector2 position, Vector2 velocity)
        {
            this.myTexture1 = myTexture1;
            this.myTexture2 = myTexture2;
            this.myTexture3 = myTexture3;
            this.position = position;
            this.velocity = velocity;
            currentBoltImage = myTexture1;
        }

        public Vector2 getPosition()
        {
            return position;
        }

        public Texture2D getBolt1()
        {
            return myTexture1;
        }

        public Texture2D getBolt2()
        {
            return myTexture2;
        }

        public Texture2D getBolt3()
        {
            return myTexture3;
        }

        public Texture2D getBoltIcon()
        {
            return myTexture4;
        }

        public void Update(GameTime elapsedTime)
        {
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(currentBoltImage, position, Color.White);
        }

        public double getDamage()
        {

        }

    }
}
