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

namespace RickandMortySlotMachine
{
    class StartScreen
    {
        MousePointer mousePointer;

        public StartScreen(int width, int height)
        {
            mousePointer = new MousePointer(50, 50, width, height);
        }

        public void Update(MouseState mouseState)
        {
            mousePointer.Update(mouseState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mousePointer.Draw(spriteBatch);
        }
    }
}
