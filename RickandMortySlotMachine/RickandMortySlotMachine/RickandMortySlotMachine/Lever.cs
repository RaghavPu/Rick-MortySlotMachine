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
    class Lever
    {
        public static Texture2D leverSlot, leverHandle;

        public Rectangle leverSlotRectangle;
        public Rectangle leverHandleRectangle;

        public bool handleHeld;

        public Lever()
        {
            leverSlotRectangle = new Rectangle(600, 0, 174, 480);
            leverHandleRectangle = new Rectangle(640, 0, 100, 100);
            handleHeld = false;
        }

        public bool Update(MouseState oldMouseState, MouseState mouseState, SlotWheelManager slotWheelManager)
        {
            if (mouseState.LeftButton != ButtonState.Pressed) handleHeld = false;

            if (mouseState.LeftButton == ButtonState.Pressed && 
                leverHandleRectangle.Contains(mouseState.X, mouseState.Y) && !slotWheelManager.slotsSpinning)
            {
                handleHeld = true;
                if (mouseState.Y <= 430 && mouseState.Y >= 50)
                    leverHandleRectangle.Y = mouseState.Y - 50;

                return leverHandleRectangle.Y >= 350;
            }
            else if (leverHandleRectangle.Y > 2 && handleHeld && !slotWheelManager.slotsSpinning)
            {
                if (mouseState.Y <= 430 && mouseState.Y >= 50)
                    leverHandleRectangle.Y = mouseState.Y - 50;

                return leverHandleRectangle.Y >= 350;
            }
            else if (leverHandleRectangle.Y > 0)
            {
                leverHandleRectangle.Y -= Math.Max(2, (int)(leverHandleRectangle.Y / 30.0));
            }

            return false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(leverSlot, leverSlotRectangle, Color.White);
            spriteBatch.Draw(leverHandle, leverHandleRectangle, Color.White);
        }

        public static void loadContent(Game game)
        {
            leverSlot = game.Content.Load<Texture2D>("Lever/lever-sliding-slot");
            leverHandle = game.Content.Load<Texture2D>("Lever/lever-handle");
        }


    }
}
