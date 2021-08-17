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
    class StartScreen
    {
        MousePointer mousePointer;
        Button playButton;

        public StartScreen(int width, int height)
        {
            mousePointer = new MousePointer(50, 50, width, height);
            playButton = new Button(new Rectangle((width - 100) / 2, (height - 30) / 2, 100, 30), "Play");
        }

        public void Update(MouseState oldMouseState, MouseState mouseState)
        {
            mousePointer.Update(mouseState);
            playButton.Update(mouseState.X, mouseState.Y);

            if (oldMouseState.LeftButton != ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed &&
                playButton.overLapping)
            {
                Game1.gameState = GameState.PLAY;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mousePointer.Draw(spriteBatch);
            playButton.Draw(spriteBatch);
        }
    }
}
