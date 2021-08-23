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
    class SlotWheelManager
    {
        SlotWheel[] slotWheels;

        public SlotWheelManager()
        {
            slotWheels = new SlotWheel[3];
            for (int i = 0; i < slotWheels.Length; i++)
            {
                slotWheels[i] = new SlotWheel(100 + (i * 100), 100 + (i * 30), 50 + (i * 20), i);
            }
        }

        public void Update(MouseState oldMouseState, MouseState mouseState)
        {
            bool slotsSpinning = slotWheels[0].spinning || slotWheels[1].spinning || slotWheels[2].spinning;

            if (!slotsSpinning && oldMouseState.LeftButton != ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed)
            {
                for (int i = 0; i < slotWheels.Length; i++) slotWheels[i].Update(true);
            }
            else
            {
                for (int i = 0; i < slotWheels.Length; i++) slotWheels[i].Update(false);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < slotWheels.Length; i++)
                slotWheels[i].Draw(spriteBatch);
        }

        public static void loadContent(Game game)
        {
            SlotWheel.loadSlotIcons(game);
        }
    }
}
