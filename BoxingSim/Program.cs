using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingSim
{
    class Program
    {
        //Power, Speed, Technique, Quickness, Stamina, Heart, Chin, Head, Body, Punch Tendency, Distance Tendency
        public static int[] player1 = new int[11]{99, 99, 99, 50, 99, 99, 99, 100, 100,50,50};
        public static int[] player2 = new int[11]{99, 99, 99, 50, 99, 99, 99, 100, 100,50,50};
        public static string player1Name = "Player One";
        public static string player2Name = "Player Two";
        public static string part;
        public static string[,] ring = new string[5, 5];
        public static int[,] player1Position = new int[1, 1];
        public static int[,] player2Position = new int[1, 1];
        public static int distance;

        public static void RingPrint()
        {
            for (int i = 0; i < ring.GetLength(0); i++)
            {
                for (int j = 0; j < ring.GetLength(1); j++)
                {
                    if (j % 5 == 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write(ring[i, j] + " ");
                }
            }
            Console.WriteLine();
        }

        public static void RingAssign()
        {
            for (int i = 0; i < ring.GetLength(0); i++)
            {
                for (int j = 0; j < ring.GetLength(1); j++)
                {
                    ring[i, j] = "Empty";
                }
            }
            ring[0, 2] = "Player One";
            ring[2, 2] = "Player Two";

        }

        public static void NormalRange(ref int chin, ref int power,ref  int health, string defenseName, string attackName, string part)
        {
            Strike(ref chin, ref power, ref health, defenseName, attackName, part);
        }

        public static void FarRange()
        {
            Console.WriteLine("Far");
        }

        public static void Movement()
        {

        }

        public static void Strike(ref int chin, ref int power, ref int health, string defenseName, string attackName, string part)
        {
            Random rnd = new Random();
            double damageRand = rnd.NextDouble();
            double defenseRand = rnd.NextDouble();
            double damage = (chin - (chin * defenseRand)) - (power - (power * damageRand));
            if (damage < 0)
            {
                damage = 0;
                Console.WriteLine(attackName + " goes for the strike");
                Console.WriteLine(damage + " damage done on " + defenseName + "'s " + part);
                Console.WriteLine(health + " health remaining for " + defenseName + "'s " + part);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine(attackName + " goes for the strike");
                Console.WriteLine(damage + " damage done on " + defenseName + "'s " + part);
                health -= Convert.ToInt16(damage);
                Console.WriteLine(health + " health remaining for " + defenseName + "'s " + part);
                Console.WriteLine();
            }
        }

        public static void DistanceFinder()
        {
            int x1 = 0;
            int x2 = 0;
            int y1 = 0;
            int y2 = 0;

            for (int i = 0; i < ring.GetLength(0); i++)
            {
                for (int j = 0; j < ring.GetLength(1); j++)
                {
                    if (ring[i, j] == "Player One")
                    {
                        x1 = i;
                        y1 = j;
                    }
                   if (ring[i, j] == "Player Two")
                    {
                        x2 = i;
                        y2 = j;
                    }
                }
            }
            if (y2 - y1 == 0)
            {
                distance = x2-x1;
            }
            else
            {
                distance = (x2 - x1) / (y2 - y1);
            }
        }

        public static void Fight(int tendencyRand, double speedRand, double speedRand2){
                double p1speed = (player1[3] - (player1[3] * speedRand));
                double p2speed = (player2[3] - (player2[3] * speedRand2));

                if (distance > 2)
                {
                    FarRange();
                }
                else if (distance <= 2)
                {
                    if (p1speed > p2speed)
                    {
                        if (tendencyRand > player1[10])
                        {
                            NormalRange(ref player2[6], ref player1[0], ref player2[7], player2Name, player1Name, "Head");
                        }
                        else
                        {
                            NormalRange(ref player2[6], ref player1[0], ref player2[8], player2Name, player1Name, "Body");
                        }
                    }
                    else
                    {
                        if (tendencyRand > player2[10])
                        {
                            NormalRange(ref player1[6], ref player2[0], ref player1[7], player1Name, player2Name, "Head");
                        }
                        else
                        {
                            NormalRange(ref player1[6], ref player2[0], ref player1[8], player1Name, player2Name, "Body");
                        }
                    }
                }

            }
        
         
        static void Main(string[] args)
        {
            RingAssign();
            RingPrint();
            DistanceFinder();
            Random rnd = new Random();
            do
            {
                int tendencyRand = rnd.Next(0, 100);
                double speedRand = rnd.NextDouble();
                double speedRand2 = rnd.NextDouble();
                Fight(tendencyRand, speedRand, speedRand2);
            }while (player1[7] > 0 && player2[7] > 0 && player1[8] > 0 && player2[8] > 0);
            Console.ReadKey();
        }
    }
}
