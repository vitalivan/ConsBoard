using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static int[,] board;
        static void ReadMove(out int iFrom, out int jFrom, out int iTo, out int jTo)
        {
            iFrom = 0;
            jFrom = 0;
            iTo = 0;
            jTo = 0;
            bool reading = true;
            do
            {
                Console.WriteLine("Your turn: ");
                string[] cmd = Console.ReadLine().Split(' ');
                if (cmd.Length != 4)
                {
                    Console.WriteLine("Enter 4 numbers ");
                    continue;
                }
                try
                {
                    iFrom = int.Parse(cmd[0])-1;
                    jFrom = int.Parse(cmd[1])-1;
                    iTo = int.Parse(cmd[2])-1;
                    jTo = int.Parse(cmd[3])-1;

                    if (iFrom < 0 || iFrom > 7) continue;
                    if (jFrom < 0 || jFrom > 7) continue;
                    if (iTo < 0 || iTo > 7) continue;
                    if (jTo < 0 || jTo > 7) continue;
                    reading = false;
                }
                catch
                {
                    Console.WriteLine("Enter 4 numbers ");
                    continue;
                }
            }while(reading);
        }
        
        static void Main(string[] args)
        {
            board = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                board[1, i]=1;
                board[6, i]=-1;
            }

            bool moveWhite = true;

            while (true)
            {
                for (int j = 7; j >= 0; j--)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write("{0} ", board[j, i]);
                    }
                    Console.WriteLine();
                }


                int i1, j1, i2, j2;
                bool reading = true;
                
                do
                {
                    ReadMove(out i1, out j1, out i2, out j2);

                    if (board[j1, i1] == 0)
                    {
                        Console.WriteLine("There is no figure on this cell");
                        continue;
                    }
                    if (moveWhite && board[j1, i1] < 0)
                    {
                        Console.WriteLine("White move");
                        continue;
                    }
                    if (!moveWhite && board[j1, i1] > 0)
                    {
                        Console.WriteLine("Black move");
                        continue;
                    }
                    if (board[j1, i1] == 1 || board[j1, i1] == -1)
                    {
                        bool correctMove = true;
                        if (i1 != i2)
                        {
                            correctMove = false;

                        }
                        if (board[j1, i1] == 1)
                        {
                            if (j2 - j1 != 1) correctMove = false;
                            if (board[j2, i2] == -1) correctMove = false;

                        }
                        else
                        {
                            if (j2 - j1 != -1) correctMove = false;
                            if (board[j2, i2] == 1) correctMove = false;
                        }
                        if (!correctMove)
                        {
                            Console.WriteLine("Wrong move");
                            continue;
                        }
                        reading = false;

                    }
                    

                } while (reading);

                board[j2, i2] = board[j1, i1];
                board[j1, i1] = 0;

                moveWhite = !moveWhite;
            }
            
            
            Console.WriteLine("END OF THE GAME");
            Console.ReadKey();
        }
    }
}
