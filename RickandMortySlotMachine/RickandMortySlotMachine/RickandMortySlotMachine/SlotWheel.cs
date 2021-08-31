using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public static bool rickandmortyTheme = false;


        public static Texture2D[] slotIcons;
        public static int middleY;

        Texture2D[] icons;
        Rectangle[] iconRectangles;
        float[] opacities;
        public static Random random = new Random();
        public bool spinning;
        int totalSpinTime;
        int spinningTime;
        bool positionReached;
        int x;
        int[] slotIndexes;
        public int slotIndex;

        double highestSpeed;
        double speed;
        int id;

        public SlotWheel(int x, int spinTime, int speed, int id)
        {
            this.x = x;
            middleY = 200;
            this.spinning = false;
            this.totalSpinTime = spinTime;
            this.spinningTime = 0;
            this.highestSpeed = speed;
            this.speed = speed;
            this.positionReached = false;
            this.slotIndex = -1;
            this.opacities = new float[4];

            this.id = id;

            this.iconRectangles = new Rectangle[4];

            for (int i = 0; i < 4; i++)
            {
                double verticalFactor = getVerticalFactor(50 + i * 90 + (int)(getVerticalFactor(50 + i * 90) / 2));
                opacities[i] = (float)verticalFactor / 60;
                iconRectangles[i] = new Rectangle(x/* + (int)getXOffset(verticalFactor)*/, 50 + i * 90, (int)verticalFactor, (int)verticalFactor);
                Console.WriteLine((i * 75) + " " + verticalFactor);
            }


            //for (int i = 0; i < 4; i++) iconRectangles[1, i] = new Rectangle(0, 0, 60, 60);

            this.icons = new Texture2D[4];
            this.slotIndexes = new int[4];
            for (int i = 0; i < icons.Length; i++)
            {
                int randomNum = random.Next(slotIcons.Length);
                icons[i] = slotIcons[randomNum];
                slotIndexes[i] = randomNum;
            }

            Console.WriteLine(String.Join(", ", slotIndexes));
        }

        public static double getVerticalFactor(int y)
        {
            if (y > middleY)
            {
                return (int)(60 * (1 - (Double)(y - middleY - 60) / middleY));
            }
            else
            {
                return (int)(60 * (1 - (Double)(middleY - y) / middleY));
            }
        }

        public double getXOffset(double verticalFactor)
        {
            if (id == 0) return -verticalFactor / 2;
            else if (id == 2) return verticalFactor / 2;
            else return 0;
        }

        public int Update(bool spin)
        {
            if (!spinning)
            {
                spinning = spin;
            }


            
            if (spinning)
            {
                spinningTime++;
                for (int i = 0; i < iconRectangles.Length; i++)
                {
                    if (iconRectangles[i].Y + (int)speed >= 400)
                    {
                        iconRectangles[i] = new Rectangle(x, 50 + ((int)speed - (400 - iconRectangles[i].Y)), 0, 0);
                        int randomNum = random.Next(slotIcons.Length);
                        icons[i] = slotIcons[randomNum];
                        slotIndexes[1] = slotIndexes[0];
                        slotIndexes[2] = slotIndexes[1];
                        slotIndexes[3] = slotIndexes[2];
                        slotIndexes[0] = randomNum;
                    } 
                    else
                    {
                        //double verticalFactor = getVerticalFactor(i * 65 + (int)(getVerticalFactor(i * 65) / 2));
                        double verticalFactor = getVerticalFactor(iconRectangles[i].Y + (int)speed + (int)(getVerticalFactor(iconRectangles[i].Y + (int)speed) / 2));
                        opacities[i] = (float)verticalFactor / 60;
                        //double verticalFactor = getVerticalFactor(iconRectangles[i].Y + (int)speed + (int)(getVerticalFactor(iconRectangles[i].Y + (int)speed));
                        iconRectangles[i] = new Rectangle(x/* + (int)getXOffset(verticalFactor)*/, iconRectangles[i].Y + (int)speed, (int)verticalFactor, (int)verticalFactor);
                    }

                    if (spinningTime >= totalSpinTime)
                    {
                        if (Math.Abs(iconRectangles[i].Y - middleY) < 5) positionReached = true;
                    }
                    
                }
                speed = Math.Max(5, speed - 0.5);
                if (spinningTime >= totalSpinTime && positionReached)
                {
                    spinning = false;
                    positionReached = false;
                    spinningTime = 0;
                    speed = highestSpeed;
                    slotIndex = slotIndexes[1];
                }
                    
            }

            return slotIndex;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < iconRectangles.Length; i++)
            {
                spriteBatch.Draw(icons[i], iconRectangles[i], new Rectangle(0, 0, 60, 60), Color.White * opacities[i], 0, new Vector2(icons[i].Width / 2, icons[i].Height / 2), SpriteEffects.None, 0);
                //spriteBatch.Draw(icons[i], iconRectangles[i], Color.White);
            }
        }
        

        public static void loadSlotIcons(Game Game)
        {
            slotIcons = new Texture2D[RandomSlotManager.NUMBER_OF_SLOTS];
            for (int i = 0; i < slotIcons.Length; i++)
            {
                slotIcons[i] = Game.Content.Load<Texture2D>(
                    ((rickandmortyTheme) ? "RM-" : "") + "Slot-Images/slot_icon" + i);
            }

        }
    }
}
