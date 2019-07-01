using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    [Serializable]
    public class LevelsState
    {
        public static bool [] levelPassed  = new bool[15];

        public static bool isLevelPassed(int i)
        {
            return levelPassed[i];
        }

    }
}
