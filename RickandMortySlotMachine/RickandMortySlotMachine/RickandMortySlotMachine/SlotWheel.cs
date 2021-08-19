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
    class SlotWheel
    {
        public static Texture2D[] slotIcons;
        public static int middleY = 150;

        Texture2D[] icons;
        Rectangle[] iconRectangles;
        Random random;
        public bool spinning;
        int totalSpinTime;
        int spinningTime;
        bool positionReached;

        double speed;

        public SlotWheel(int spinTime)
        {
            this.random = new Random();
            this.spinning = false;
            this.totalSpinTime = spinTime;
            this.spinningTime = 0;
            this.speed = 50;
            this.positionReached = false;

            this.iconRectangles = new Rectangle[4];

            for (int i = 0; i < 4; i++)
            {
                int verticalFactor = getVerticalFactor(i * 75);
                iconRectangles[i] = new Rectangle(50 - (verticalFactor / 2), i * 75, verticalFactor, verticalFactor);
                Console.WriteLine((i * 75) + " " + verticalFactor);
            }


            //for (int i = 0; i < 4; i++) iconRectangles[1, i] = new Rectangle(0, 0, 60, 60);

            this.icons = new Texture2D[4];

        }

        public static int getVerticalFactor(int y)
        {
            if (y > middleY)
            {
                return (int)(60 * (1 - (Double)(y - middleY) / middleY));
            }
            else
            {
                return (int)(60 * (1 - (Double)(middleY - y) / middleY));
            }
        }

        public void Update(bool spin)
        {
            if (!spinning) spinning = spin;

            
            if (spinning)
            {
                spinningTime++;
                if (spinning)
                {
                    for (int i = 0; i < iconRectangles.Length; i++)
                    {
                        int verticalFactor = getVerticalFactor(iconRectangles[i].Y + (int)speed);
                        iconRectangles[i] = new Rectangle(50 - (verticalFactor / 2), iconRectangles[i].Y + (int)speed, verticalFactor, verticalFactor);

                        if (spinningTime >= totalSpinTime)
                        {
                            if (iconRectangles[i].Y == middleY) positionReached = true;
                        }
                        if (iconRectangles[i].Y >= 300)
                            iconRectangles[i] = new Rectangle(50, 0, 0, 0);
                    }
                    speed = Math.Max(1, speed - 0.5);
                    if (spinningTime >= totalSpinTime && positionReached)
                    {
                        spinning = false;
                        positionReached = false;
                        spinningTime = 0;
                        speed = 50;
                    }
                        
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < iconRectangles.Length; i++)
            {
                spriteBatch.Draw(slotIcons[0], iconRectangles[i], Color.White);
            }
        }
        

        public static void loadSlotIcons(Game Game)
        {
            slotIcons = new Texture2D[RandomSlotManager.NUMBER_OF_SLOTS];
            for (int i = 0; i < slotIcons.Length; i++)
            {
                slotIcons[i] = Game.Content.Load<Texture2D>("Slot-Images/slot_icon" + i);
            }
        }
    }
}
