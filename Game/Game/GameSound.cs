using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public static class GameSound
    {
        public static System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer();
        public static System.Media.SoundPlayer win = new System.Media.SoundPlayer();
        public static System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer();

        public static bool isSoundOn;

        public static void playGameTheme()
        {
            backgroundSound.SoundLocation = "GameThemeSong.wav";
            win.SoundLocation = "GettingTheStar.wav";
            gameOver.SoundLocation = "GameOver.wav";

            backgroundSound.PlayLooping();
        }

        public static void stopGameTheme() {
            backgroundSound.Stop();
        }

        public static void playLevelsTheme()
        {

        }
    }
}
