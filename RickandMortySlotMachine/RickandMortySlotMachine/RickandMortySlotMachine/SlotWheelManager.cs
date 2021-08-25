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
        public bool slotsSpinning;

        public SlotWheelManager()
        {
            slotWheels = new SlotWheel[3];
            slotsSpinning = false;
            for (int i = 0; i < slotWheels.Length; i++)
            {
                slotWheels[i] = new SlotWheel(100 + (i * 100), 100 + (i * 60), 50 + (i * 20), i);
            }
        }

        public void Update(bool leverPulled)
        {
            slotsSpinning = slotWheels[0].spinning || slotWheels[1].spinning || slotWheels[2].spinning;

            if (!slotsSpinning && leverPulled)
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
