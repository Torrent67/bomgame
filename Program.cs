using System;
using System.Collections.Generic;
using GameMain;

namespace BombGame
{
    class Program
    {

        
        public static List<List<string>> Solution = new List<List<string>>();
        public static List<string> buildState = new List<string>();
        public static List<string> currentState;
        public static List<string> ClueList = new List<string>();
        public static Random rnd = new Random();
        public static Bomb bomb = new Bomb();
        public static void Main()
        {
            int s1 = rnd.Next(1,3);
            int s2 = rnd.Next(1,4);
            int s3 = rnd.Next(1,5);
            int traps = 12;
            int timeLeft = 15;


            StageOneBuilder(s1);
            StageTwoBuilder(s2);
            StageThreeBuilder(s3);
            TrapBuilder(traps);

            Console.WriteLine("Operator please begin bomb difusing test. \n");

            while(timeLeft > 0)
            {
                Console.WriteLine("When you look at the bomb you see: ");
                Console.WriteLine("Timer reads: " + timeLeft + "\n");
                TurnStart(s1);
                timeLeft -= TurnActions(s1, timeLeft);
            }
            

        }
        //adds stage1 to Solution
        public static void StageOneBuilder(int n) 
        {
            List<string> stringTemp1 = new List<string>();
            int i = 0;
            while( i < n)
            {
                int index = rnd.Next(0,3);
                string part = bomb.GetPart(index);
                if (!stringTemp1.Contains(part))
                {
                    stringTemp1.Add(part);
                    i++;
                }
            }
            Solution.Add(stringTemp1);
        }
        //adds stage2 to Solution
        public static void StageTwoBuilder(int n) 
        {
            List<string> stringTemp2 = new List<string>();
        
            int i = 0;
            while( i < n)
            {
                int index = rnd.Next(1,4);
                string part = bomb.GetPart2(index);
                if (!stringTemp2.Contains(part))
                {
                    stringTemp2.Add(part);
                    i++;
                }
            }
            Solution.Add(stringTemp2);
        }
        //adds stage3 to Solution
        public static void StageThreeBuilder(int n) 
        {
            List<string> stringTemp3 = new List<string>();
        
            int i = 0;
            while( i < n)
            {
                int index = rnd.Next(0,7);
                string part = bomb.GetPart3(index);
                if (!stringTemp3.Contains(part))
                {
                    stringTemp3.Add(part);
                    i++;
                }
            }
            Solution.Add(stringTemp3);
        }
        //adds traps to Solution
        public static void TrapBuilder(int n) 
        {
            List<string> stringTemp4 = new List<string>();
        
            int i = 0;
            while( i < n)
            {
                int index = rnd.Next(0,17);
                string part = bomb.GetTrap(index);
                if (!stringTemp4.Contains(part))
                {
                    stringTemp4.Add(part);
                    i++;
                }
            }
            Solution.Add(stringTemp4);
        }
    
        //"builds" currentState of bomb
        public static void TurnStart(int stage)
        {
            
            for (int i = 0; i < stage; i++)
            {
                buildState.Add(Solution[0][i]);
            }
            Solution.RemoveAt(0);
            int index = 0;
            while (index < 2)
            {   
                int picker = rnd.Next(0, 12);
                if (!buildState.Contains(Solution[Solution.Count-1][picker]))
                {
                buildState.Add(Solution[Solution.Count-1][picker]);
                index++;
                }
            }
            currentState = new List<string>(buildState);
            Console.WriteLine(stage);
            for (int i = 0; i <= buildState.Count; i++)
            {
            int part = rnd.Next(0, buildState.Count);
            Console.WriteLine(buildState[part]);
            buildState.RemoveAt(part);
            }
            Console.WriteLine(buildState[0]); 
            Console.WriteLine("\n"); 
        }
        //queries user for actions
        public static int TurnActions(int stage, int timer)
        {
            int success = 0;
            while (stage > success || timer > 0)
            {
                Console.WriteLine("Choose your action!\n");
                Console.WriteLine("Study Bomb. [study]");
                Console.WriteLine("Attempt to Disarm! [disarm]");
                string userAction = Console.ReadLine().ToLower();
                if (userAction == "study")
                {

                    string hint = Clue(currentState,stage);
                    Console.WriteLine("This part looks suspicious " + hint);
                    timer--;
                }
                else if (userAction == "disarm")
                {
                    Console.WriteLine(stage);
                    int decrement = disarmBomb(stage);
                    if (decrement == 0)
                    {
                        success++;
                        timer--;
                    } else if (decrement > 0)
                    {
                        timer -= decrement;
                        timer--;
                    } else
                    {
                        timer--;
                    }
                    
                }
                Console.WriteLine("Timer reads: " + timer);
            }
            return timer;
        }
        public static string Clue(List<string> currentState, int stage)
        {
            
            string clue = "";
            int j = 1;
            while (j <= stage)
            {
                if (ClueList.Contains(currentState[currentState.Count-j]))
                {
                    j++;
                    clue = currentState[currentState.Count-j];
                    ClueList.Add(currentState[currentState.Count-j]);
                    return clue;
                } else
                {
                    Console.WriteLine(j);
                    clue = currentState[currentState.Count-j];
                    ClueList.Add(currentState[currentState.Count-j]);
                    j++;
                    return clue;
                }
            }
            clue = "You should know your next move!";
            return clue;
        }
        public static int disarmBomb(int stage)
        {
            int danger = 0;
            Console.WriteLine("What would you like to interact with? [type in full name of part case sensitive]");
            string partChoice = Console.ReadLine();
            int partNumber = currentState.IndexOf(partChoice);
            Console.WriteLine(partNumber);
            if (currentState.Contains(partChoice))
            {
                if (partNumber < stage && partNumber == 0) 
                {
                    Console.WriteLine("That seemed to be the right choice!");
                    currentState.RemoveAt(0);
                } else if (partNumber < stage) 
                {
                    Console.WriteLine("That seemed to be the right!");
                    currentState.RemoveAt(partNumber);
                    danger++;
                } else
                {
                    Console.WriteLine("Oops! That made the timer speed up!");
                    danger += 2;
                }
            } else 
                {
                    Console.WriteLine("That did not match a part currently showing");
                    danger--;
                }
            for (int i = 0; i <= currentState.Count; i++)
            {
            int part = rnd.Next(0, currentState.Count);
            Console.WriteLine(currentState[part]);
            currentState.RemoveAt(part);
            }
            Console.WriteLine(currentState);
            return danger;
        }

    }
}

