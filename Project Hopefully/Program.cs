using System;

namespace Project_Hopefully
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp1, temp2, sum = 0;
            int g = GameSize();
            int Pairs = (g * g) / 2;
            int i, j, NumPlayers;
            int flag = 0;
            int turn = 0;
            NumPlayers = Players();

            int[] GMS2 = new int[2];
            int[] GMS = new int[2];
            int[] R = new int[NumPlayers];
            int[] BasicArray = new int[Pairs];
            int[,] GameMatrix = new int[g, g];

            for (i = 0; i < Pairs; i++)
            {
                BasicArray[i] = i + 1;
            }
            for (i = 0; i < g; i++)
            {
                for (j = 0; j < g; j++)
                {
                    GameMatrix[i, j] = 0;
                }
            }
            for (i = 0; i < NumPlayers; i++)
            {
                R[i] = 0;

            }


            Random RNG = new Random();

            while (flag < Pairs * 2)
            {
                i = RNG.Next(0, g);
                j = RNG.Next(0, g);

                if (GameMatrix[i, j] == 0)
                {
                    GameMatrix[i, j] = BasicArray[flag / 2];
                    flag++;
                }

            }

            while (sum < Pairs)
            {
                Console.WriteLine("Player " + (turn+1) + "'s turn");
                GMS = PlayerInput(g);
                PrintBoard(GameMatrix, g, GMS);

                temp1 = GameMatrix[GMS[0], GMS[1]];
                GMS2 = PlayerInput(g);
                PrintBoard(GameMatrix, g, GMS2);
                temp2 = GameMatrix[GMS2[0], GMS2[1]];

                if (temp1 == temp2 && temp1 != 0 && temp2 != 0)
                {
                    GameMatrix[GMS[0], GMS[1]] = 0;
                    GameMatrix[GMS2[0], GMS2[1]] = 0;

                    R[turn] += 1;
                    turn--;
                    sum += 1;
                }


                turn++;
                turn = turn % NumPlayers;

            }


        }

        public static int[] PlayerInput(int g)
        {
            int flag, i;
            int Flag2 = 0;
            int[] KMS = new int[2];
            int Index = 0;
            string s;
            while (Flag2 == 0)
            {
                Console.WriteLine("Please insert line number to play on:");
                Index = 0;
                flag = 0;
                s = Console.ReadLine();
                Flag2 = 1;
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i] < 48 || s[i] > 57)
                    {
                        flag = 1;

                    }
                }

                if (flag == 1)
                {
                    Flag2 = 0;
                    continue;
                }


                Index = int.Parse(s);

                if (Index < 0 || Index > g - 1)
                {
                    Flag2 = 0;
                }
            }
            KMS[0] = Index;
            Flag2 = 0;
            while (Flag2 == 0)
            {
                Console.WriteLine("Please insert row number to play on:");
                Index = 0;
                flag = 0;
                s = Console.ReadLine();
                Flag2 = 1;
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i] < 48 || s[i] > 57)
                    {
                        flag = 1;

                    }
                }

                if (flag == 1)
                    Flag2 = 0;

                Index = int.Parse(s);

                if (Index < 0 || Index > g - 1)
                {
                    Flag2 = 0;
                    continue;
                }
            }
            KMS[1] = Index;
            return KMS;
        }

        public static void PrintBoard(int[,] smd, int g, int[] GMS)
        {
            int i, j;
            for (i = 0; i < g; i++)
            {
                for (j = 0; j < g; j++)
                {                   
                    if (smd[i, j] == 0)
                        Console.Write("0 ");

                    else if (i == GMS[0] && j == GMS[1])
                        Console.Write(smd[i, j] + " ");

                    else
                        Console.Write("X ");

                }
                Console.WriteLine("");

            }

        }

        public static int GameSize()
        {
            int Width = 0;
            string s;
            int H = 0, i, flag = 0;
            while (Width == 0)
            {
                Console.WriteLine("Please insert a even number grid size to play on:");
                H = 0;
                flag = 0;
                s = Console.ReadLine();
                Width = 1;
                for (i = 0; i < s.Length; i++)
                {
                    if (s[i] < 48 || s[i] > 57)
                    {
                        flag = 1;

                    }
                }

                if (flag == 1)
                {
                    Width = 0;
                    continue;
                }

                H = int.Parse(s);
                if (H % 2 != 0)
                {
                    Width = 0;
                }

            }

            return H;

        }

        public static int Players()
        {
            int Playing = 0;
            string s;
            while (Playing < 1 || Playing > 4)
            {
                Console.WriteLine("Please input between 1 and 4 how many players are playing:");
                s = Console.ReadLine();

                if (s.Length > 1)
                    continue;
                else if (s[0] < 48 || s[0] > 57)
                    continue;

                Playing = int.Parse(s);

            }

            return Playing;
        }
    }
}
