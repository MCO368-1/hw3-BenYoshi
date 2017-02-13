using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife
{
    class Program
    {
        private const int DELAY = 500;

        private static bool[,] cells = new bool[20,20];

        private static int genCount = 1;

        static void Main(string[] args)
        {
            ChooseOscillator();
            RunOscillator();
        }

        public static void ChooseOscillator()
        {
            Console.WriteLine("Please choose an Oscillator by enterring its corresponding number:" +
                              "\n1: Blinker (period 2)" +
                              "\n2: Toad (period 2)" +
                              "\n3: Beacon (period 2)" +
                              "\n4: Pulsar (period 3)" +
                              "\n5: Pentadecathlon (period 15)" +
                              "\nEnter Here:");
            int chosenOscillator = Convert.ToInt32(Console.ReadLine());
            switch (chosenOscillator)
            {
                case 1:
                    InitializeBlinker();
                    break;
                case 2:
                    InitializeToad();
                    break;
                case 3:
                    InitializeBeacon();
                    break;
                case 4:
                    InitializePulsar();
                    break;
                case 5:
                    InitializePentadecathlon();
                    break;
                default:
                    Console.WriteLine("that is not a valid input");
                    break;
            }
        }

        public static void RunOscillator()
        {
            while (!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                DrawCells();
                UpdateCells();
                Thread.Sleep(DELAY);
                Console.Clear();
            }
        }

        public static void DrawCells()
        {
            Console.WriteLine("Generation " + (genCount++) + ":");

            for (var i = 0; i < cells.GetLength(0); i++)
            {
                for (var j = 0; j < cells.GetLength(1); j++)
                {
                    Console.Write(cells[i, j] ? "O " : ". ");
                }
                Console.WriteLine();
            }
        }

        private static void UpdateCells()
        {
            bool[,] newCells = new bool[cells.GetLength(0), cells.GetLength(1)];

            for (int i = 1; i < cells.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < cells.GetLength(1) - 1; j++)
                {
                    newCells[i, j] = ApplyRules(i, j);
                }
            }

            cells = newCells;
        }

        private static bool ApplyRules(int i, int j)
        {
            var liveNeighborCount = CountLiveNeighbors(i, j);
            var currentCell = cells[i, j];
            
            return currentCell && (liveNeighborCount == 2 || liveNeighborCount == 3) || !currentCell && liveNeighborCount == 3;
        }

        private static int CountLiveNeighbors(int x, int y)
        {
            var neighborCount = 0;

            if (cells[x - 1, y])
            {
                neighborCount++;
            }
            if (cells[x - 1, y - 1])
            {
                neighborCount++;
            }
            if (cells[x, y - 1])
            {
                neighborCount++;
            }

            if (cells[x + 1, y - 1])
            {
                neighborCount++;
            }
            if (cells[x - 1, y + 1])
            {
                neighborCount++;
            }

            if (cells[x + 1, y])
            {
                neighborCount++;
            }
            if (cells[x + 1, y + 1])
            {
                neighborCount++;
            }
            if (cells[x, y + 1])
            {
                neighborCount++;
            }
            return neighborCount;
        }

        private static void InitializeBlinker()
        {
            Console.Title = "Blinker (period 2)";

            cells[9, 9] = true;
            cells[9, 10] = true;
            cells[9, 11] = true;
        }

        private static void InitializeToad()
        {
            Console.Title = "Toad (period 2)";

            cells[9, 9] = true;
            cells[9, 10] = true;
            cells[9, 11] = true;
            cells[10, 8] = true;
            cells[10, 9] = true;
            cells[10, 10] = true;
        }

        private static void InitializeBeacon()
        {
            Console.Title = "Beacon (period 2)";

            cells[9, 8] = true;
            cells[9, 9] = true;
            cells[10, 8] = true;
            cells[10, 9] = true;
            cells[11, 10] = true;
            cells[11, 11] = true;
            cells[12, 10] = true;
            cells[12, 11] = true;
        }

        private static void InitializePulsar()
        {
            Console.Title = "Pulsar (period 3)";

            cells[4, 5] = true;
            cells[4, 6] = true;
            cells[4, 7] = true;
            cells[4, 11] = true;
            cells[4, 12] = true;
            cells[4, 13] = true;
            cells[6, 3] = true;
            cells[6, 8] = true;
            cells[6, 10] = true;
            cells[6, 15] = true;
            cells[7, 3] = true;
            cells[7, 8] = true;
            cells[7, 10] = true;
            cells[7, 15] = true;
            cells[8, 3] = true;
            cells[8, 8] = true;
            cells[8, 10] = true;
            cells[8, 15] = true;
            cells[9, 5] = true;
            cells[9, 6] = true;
            cells[9, 7] = true;
            cells[9, 11] = true;
            cells[9, 12] = true;
            cells[9, 13] = true;
            cells[11, 5] = true;
            cells[11, 6] = true;
            cells[11, 7] = true;
            cells[11, 11] = true;
            cells[11, 12] = true;
            cells[11, 13] = true;
            cells[12, 3] = true;
            cells[12, 8] = true;
            cells[12, 10] = true;
            cells[12, 15] = true;
            cells[13, 3] = true;
            cells[13, 8] = true;
            cells[13, 10] = true;
            cells[13, 15] = true;
            cells[14, 3] = true;
            cells[14, 8] = true;
            cells[14, 10] = true;
            cells[14, 15] = true;
            cells[16, 5] = true;
            cells[16, 6] = true;
            cells[16, 7] = true;
            cells[16, 11] = true;
            cells[16, 12] = true;
            cells[16, 13] = true;
        }

        private static void InitializePentadecathlon()
        {
            Console.Title = "Pentadecathlon (period 15)";

            cells[8, 7] = true;
            cells[8, 12] = true;
            cells[9, 5] = true;
            cells[9, 6] = true;
            cells[9, 8] = true;
            cells[9, 9] = true;
            cells[9, 10] = true;
            cells[9, 11] = true;
            cells[9, 13] = true;
            cells[9, 14] = true;
            cells[10, 7] = true;
            cells[10, 12] = true;
        }
    }
}