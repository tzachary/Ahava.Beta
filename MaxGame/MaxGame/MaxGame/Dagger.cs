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
    public class Dagger : Sprite
    {
        Texture2D myTexture;
        Vector2 myPosition;
        Vector2 myVelocity;
        double damage;

        public Dagger(Texture2D image, Vector2 position, Vector2 velocity)
        {
            myTexture = image;
            myPosition = position;
            myVelocity = velocity;
            damage = 100;
        }

        public Vector2 getPosition()
        {
            return myPosition;
        }

        public Texture2D getTex()
        {
            return myTexture;
        }

        public void Update(GameTime elapsedTime)
        {
            myPosition += myVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, Color.White);
        }

        public double getDamage()
        {
            return damage;
        }
    }
}
