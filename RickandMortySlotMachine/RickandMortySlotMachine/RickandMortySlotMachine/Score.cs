using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace RickandMortySlotMachine
{
    class Score
    {
        public static int JACKPOT_SCORE = 100;
        public static int SEMI_JACKPOT_SCORE = 20;

        public static SpriteFont scoreFont, scoreReactionFont;
        public int score;

        private String text;
        private int time = 0;
        private Color stringColor;

        public Score()
        {
            this.score = 100;
            this.text = "";
            stringColor = Color.Red;
        }

        public static void loadFont(Game game)
        {
            scoreFont = game.Content.Load<SpriteFont>("ScoreFont");
            scoreReactionFont = game.Content.Load<SpriteFont>("ScoreReactionFont");
        }

        public void Update(int payOut)
        {
            score += payOut;
            if (payOut == JACKPOT_SCORE)
            {
                text = "  JACKPOT!   ";
                stringColor = Color.Green;
            }
            else if (payOut == SEMI_JACKPOT_SCORE)
            {
                text = "ALMOST THERE!";
                stringColor = Color.LightSeaGreen;
            }
            else
            {
                text = " NOTHING :(  ";
                stringColor = Color.Red;
            }

            time = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(scoreFont, "Balance: $" + score, new Vector2(10, 10), Color.Black);

            if (time < 180 && time / 30 % 2 == 0)
            {
                spriteBatch.DrawString(scoreReactionFont, text, new Vector2(200, 200), stringColor);
            }
            if (text != "") time++;
        }


    }
}
