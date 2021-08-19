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
        SlotWheel slotWheel;

        public GameScreen(int width, int height)
        {
            slotManager = new RandomSlotManager();
            slotWheel = new SlotWheel(100);
        }

        public void Update(MouseState oldMouseState, MouseState mouseState)
        {
            //Console.WriteLine("[{0}]", string.Join(", ", slotManager.generateNewSlots()));
            if (!slotWheel.spinning && oldMouseState.LeftButton != ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed)
                slotWheel.Update(true);
            else
                slotWheel.Update(false);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            slotWheel.Draw(spriteBatch);
        }

    }
}
