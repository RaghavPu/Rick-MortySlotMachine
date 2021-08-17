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
    class GameScreen
    {
        RandomSlotManager slotManager;

        public GameScreen(int width, int height)
        {
            slotManager = new RandomSlotManager();
        }

        public void Update(MouseState oldMouseState, MouseState mouseState)
        {
            Console.WriteLine("[{0}]", string.Join(", ", slotManager.generateNewSlots()));
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

    }
}
