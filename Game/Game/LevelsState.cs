using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class LevelsState
    {
        private bool [] levelPassed;

        public LevelsState()
        {
            levelPassed = new bool[15];
        }

        public void passLevel(int i) {
            levelPassed[i] = true;
        }

        public bool isLevelPassed(int i) {
            return levelPassed[i];
        }

        public bool [] getLevelPassed() {
            return levelPassed;
        }


    }
}
