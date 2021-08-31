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
        int[] slotWheelIndexes;
        public bool slotsSpinning, prevSlotsSpinning;

        public SlotWheelManager()
        {
            slotWheels = new SlotWheel[3];
            slotWheelIndexes = new int[3];
            slotsSpinning = prevSlotsSpinning = false;
            for (int i = 0; i < slotWheels.Length; i++)
            {
                slotWheels[i] = new SlotWheel(100 + (i * 100), 100 + (i * 60), 50 + (i * 20), i);
                slotWheelIndexes[i] = -1;
            }
        }

        public void Update(bool leverPulled, Score score)
        {
            prevSlotsSpinning = slotsSpinning;
            slotsSpinning = slotWheels[0].spinning || slotWheels[1].spinning || slotWheels[2].spinning;

            if (!slotsSpinning && leverPulled)
            {
                for (int i = 0; i < slotWheels.Length; i++) slotWheels[i].Update(true);
            }
            else
            {
                for (int i = 0; i < slotWheels.Length; i++)
                {
                    slotWheels[i].Update(false);
                }

                if (prevSlotsSpinning && !slotsSpinning)
                {
                    updateSlotIndexes();
                    Console.WriteLine(String.Join(", ", slotWheelIndexes));
                    if (slotWheelIndexes[0] == slotWheelIndexes[1]  && slotWheelIndexes[1] == slotWheelIndexes[2])
                    {
                        score.Update(Score.JACKPOT_SCORE);
                    }
                    else if (slotWheelIndexes[0] == slotWheelIndexes[1] || slotWheelIndexes[0] == slotWheelIndexes[2] ||
                             slotWheelIndexes[1] == slotWheelIndexes[2])
                    {
                        score.Update(Score.SEMI_JACKPOT_SCORE);
                    }
                    else
                    {
                        score.Update(-10);
                    }
                }
            }
        }

        private void updateSlotIndexes()
        {
            for (int i = 0; i < 3; i++)
            {
                slotWheelIndexes[i] = slotWheels[i].slotIndex;
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
