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
        //SlotWheel slotWheel;
        SlotWheelManager slotWheelManager;

        public GameScreen(int width, int height)
        {
            //slotWheel = new SlotWheel(100, 100);
            slotWheelManager = new SlotWheelManager();
        }

        public void Update(MouseState oldMouseState, MouseState mouseState)
        {
            //Console.WriteLine("[{0}]", string.Join(", ", slotManager.generateNewSlots()));
            //if (!slotWheel.spinning && oldMouseState.LeftButton != ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed)
            //    slotWheel.Update(true);
            //else
            //    slotWheel.Update(false);
            slotWheelManager.Update(oldMouseState, mouseState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            slotWheelManager.Draw(spriteBatch);
        }

        public static void LoadContent(Game game)
        {
            SlotWheelManager.loadContent(game);
        }

    }
}
