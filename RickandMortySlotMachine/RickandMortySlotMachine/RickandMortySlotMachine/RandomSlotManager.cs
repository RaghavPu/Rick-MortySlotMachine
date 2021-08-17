using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RickandMortySlotMachine
{
    class RandomSlotManager
    {
        public static int NUMBER_OF_SLOTS = 20;

        Random random;
        int[] slots;

        public RandomSlotManager()
        {
            random = new Random();
            slots = new int[3];
        }

        public int[] generateNewSlots()
        {
            for (int i = 0; i < slots.Length; i++)
                slots[i] = random.Next(NUMBER_OF_SLOTS);
            return slots;
        }

        public int[] getSlots()
        {
            return slots;
        }
    }
}
