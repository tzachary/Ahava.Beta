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
    public class Sprite
    {
        private Texture2D myTexture;
        private Vector2 myPosition;
        private Vector2 myVelocity;
        private Vector2 myAcceleration;
        private Vector2 myOrigin;
        private float myAngle;

        public Sprite(Texture2D texture, Vector2 position)
        {
            myTexture = texture;
            myPosition = position;
        }

        public Sprite() { }

        public void Update(GameTime elapsedTime)
        {
            myPosition += myVelocity;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(myTexture, myPosition, Color.White);
        }
    }
}
