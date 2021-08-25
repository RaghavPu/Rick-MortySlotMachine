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
        SlotWheelManager slotWheelManager;
        MousePointer mousePointer;
        Lever lever;

        public GameScreen(int width, int height)
        {
            //slotWheel = new SlotWheel(100, 100);
            slotWheelManager = new SlotWheelManager();
            mousePointer = new MousePointer(50, 50, width, height);
            lever = new Lever();
        }

        public void Update(MouseState oldMouseState, MouseState mouseState)
        {
            //Console.WriteLine("[{0}]", string.Join(", ", slotManager.generateNewSlots()));
            //if (!slotWheel.spinning && oldMouseState.LeftButton != ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed)
            //    slotWheel.Update(true);
            //else
            //    slotWheel.Update(false);
            bool leverPulled = lever.Update(oldMouseState, mouseState, slotWheelManager);
            slotWheelManager.Update(leverPulled);
            mousePointer.Update(mouseState);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            slotWheelManager.Draw(spriteBatch);
            lever.Draw(spriteBatch);
            mousePointer.Draw(spriteBatch);
        }

        public static void LoadContent(Game game)
        {
            SlotWheelManager.loadContent(game);
            Lever.loadContent(game);
        }

    }
}
