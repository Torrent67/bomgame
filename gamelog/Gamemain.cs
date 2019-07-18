using System;
using System.Collections.Generic;

namespace GameMain
{
    class Bomb
    {
        private string[] StageOne;
        private string[] StageTwo;
        private string[] StageThree;
        private string[] Traps;

        
        public Bomb ()
        {  
            StageOne = new string [] {"Red Wire", "Blue Wire", "Green Button"};
            StageTwo = new string [] {"Black Wire", "White Wire", "Omega Switch", "Gamma Switch", "Orange Button", "Green Button"};
            StageThree  = new string [] {"Lime Wire", "Purple Wire", "Turqoise Button", "Yellow Wire", "Alpha Switch", "Epsilon Switch", "Blue Button", "Black Button"};
            Traps  = new string [] {"Red Wire", "Blue Wire", "Green Button", "Black Wire", "White Wire", "Omega Switch", "Gamma Switch", "Orange Button", "Green Button", "Lime Wire", "Purple Wire", "Turqoise Button", "Yellow Wire", "Alpha Switch", "Epsilon Switch", "Blue Button", "Black Button", "Red Button"};
        }
        
        public string GetPart(int i)
        {
            return StageOne[i];
        }
        public string GetPart2(int i)
        {
            return StageTwo[i];
        }
        public string GetPart3(int i)
        {
            return StageThree[i];
        }
        public string GetTrap(int i)
        {
            return Traps[i];
        }
    }
}

//turn C.WL(description of bomb)