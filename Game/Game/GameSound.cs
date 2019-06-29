using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class  GameSound
    {
        public static void playGameTheme() {
            System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer();
            System.Media.SoundPlayer win = new System.Media.SoundPlayer();
            System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer();

            backgroundSound.SoundLocation = "BackgroundSound.wav";
            win.SoundLocation = "GettingTheStar.wav";
            gameOver.SoundLocation = "GameOver.wav";
            backgroundSound.Play();

        }

        public static void playLevelsTheme() {

        }
    }
}
