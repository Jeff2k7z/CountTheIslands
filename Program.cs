using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTheIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();

            var grid = new string[80,50];
            string[] lines = File.ReadAllLines(@"..\..\map.txt");
            for (var y = 1; y < 50; y++)
            {
                for (var x = 3; x < 83; x++)
                {
                    grid[x - 3,y - 1] = lines[y][x].ToString();
                }
            }

            //Stopwatch sw = Stopwatch.StartNew();

            var continentCount = 0;
            var continents = new List<int>();
            for (var x = 0; x < 80; x++)
            {
                for (var y = 0; y < 50; y++)
                {
                    if (grid[x, y] == "+")
                    {
                        continentCount++;
                        var landCount = FindAdjacentLand(grid, x, y, continentCount.ToString(), 0);
                        continents.Add(landCount);
                    }
                }
            }

            sw.Stop();
            Console.WriteLine("Elapsed Time: {0}", sw.Elapsed);
            Console.WriteLine("There are {0} continents.", continentCount);
            for(var i = 0; i < continents.Count; i++)
            {
                Console.WriteLine("Continent {0} has {1} +.", i+1, continents[i]);
            }

            Console.ReadLine();
        }

        static int FindAdjacentLand(string[,] map, int x, int y, string label, int count)
        {
            map[x, y] = label;
            count++;

            // Right, Middle
            if (x < 80 && map[x + 1, y] == "+")
            {
                //map[x + 1, y] = label;
                count = FindAdjacentLand(map, x + 1, y, label, count);
            }

            // Left, Bottom
            if (x > 0 && y < 50 && map[x - 1, y + 1] == "+")
            {
                //map[x - 1, y + 1] = label;
                count = FindAdjacentLand(map, x - 1, y + 1, label, count);
            }

            // Middle, Bottom
            if (y < 50 && map[x, y + 1] == "+")
            {
                //map[x, y + 1] = label;
                count = FindAdjacentLand(map, x, y + 1, label, count);
            }

            // Right, Bottom
            if (x < 80 && y < 50 && map[x + 1, y + 1] == "+")
            {
                //map[x + 1, y + 1] = label;
                count = FindAdjacentLand(map, x + 1, y + 1, label, count);
            }

            // Left, Middle
            if (x > 0 && map[x - 1, y] == "+" )
            {
                //map[x - 1, y] = label;
                count = FindAdjacentLand(map, x-1, y, label, count);
            }

            // Left, Top
            if (x > 0 && y>0 && map[x - 1, y - 1] == "+")
            {
                //map[x - 1, y - 1] = label;
                count = FindAdjacentLand(map, x - 1, y - 1, label, count);
            }

            // Middle, Top
            if (y > 0 && map[x, y - 1] == "+")
            {
                //map[x, y - 1] = label;
                count = FindAdjacentLand(map, x, y - 1, label, count);
            }

            // Right, Top
            if (x < 80 && y > 0 && map[x + 1, y - 1] == "+")
            {
                //map[x + 1, y - 1] = label;
                count = FindAdjacentLand(map, x + 1, y - 1, label, count);
            }

            

            

            return count;
        }

        
    }
}
