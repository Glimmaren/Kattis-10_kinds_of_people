using System;
using System.Collections.Generic;

namespace Problem2C
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            string[] input1 = Console.ReadLine().Split(' ');
            int rows = int.Parse(input1[0]);
            int columns = int.Parse(input1[1]);
            string[] map = new string[rows];

            for (int i = 0; i < rows; i++)
            {
                map[i] = Console.ReadLine();
            }

            int[][] groups = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                groups[i] = new int[columns];
                for (int j = 0; j < columns; j++)
                {
                    groups[i][j] = 0;
                }
            }

            int numOfLocations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfLocations; i++)
            {
                string[] locations = Console.ReadLine().Split(' ');
                Coordinates coordinates = new Coordinates( int.Parse(locations[1]) - 1, int.Parse(locations[0]) - 1, int.Parse(locations[2]) - 1, int.Parse(locations[3]) - 1);
                find(coordinates, i + 1, groups, map);
            }
        }

        class Coordinates
        {
            public int StartRow, StartColumn, EndRow, EndColumn;

            public Coordinates(int _startColumn, int _startRow, int _endRow, int _endColumn)
            {
                StartRow = _startRow;
                StartColumn = _startColumn;
                EndRow = _endRow;
                EndColumn = _endColumn;         
            }
        }

        static void find(Coordinates coords,int group, int[][] groups, string[] map)
        {
            List<int[]> queue = new List<int[]>();
            int num = map[coords.StartRow][coords.StartColumn];

            if (groups[coords.StartRow][coords.StartColumn] == 0)
            {
                queue.Add(new int[] { coords.StartRow, coords.StartColumn });
                while (queue.Count > 0)
                {
                    int tempRow = queue[0][0];
                    int tempColumn = queue[0][1];
                    groups[tempRow][tempColumn] = group;
                    queue.RemoveAt(0);
                    if (tempRow > 0 && num == map[tempRow - 1][tempColumn] && groups[tempRow - 1][tempColumn] == 0)
                    {
                        groups[tempRow - 1][tempColumn] = group;
                        queue.Add(new int[] { tempRow - 1, tempColumn });
                    }
                                      
                    if (tempColumn > 0 && num == map[tempRow][tempColumn - 1] && groups[tempRow][tempColumn - 1] == 0)
                    {
                        groups[tempRow][tempColumn - 1] = group;
                        queue.Add(new int[] { tempRow, tempColumn - 1 });
                    }
                        
                    if (tempRow < map.Length - 1 && num == map[tempRow + 1][tempColumn] && groups[tempRow + 1][tempColumn] == 0)
                    {
                        groups[tempRow + 1][tempColumn] = group;
                        queue.Add(new int[] { tempRow + 1, tempColumn });
                    }                     
                    if (tempColumn < map[0].Length - 1 && num == map[tempRow][tempColumn + 1] && groups[tempRow][tempColumn + 1] == 0)
                    {
                        groups[tempRow][tempColumn + 1] = group;
                        queue.Add(new int[] { tempRow, tempColumn + 1 });
                    }                                     
                }
            }
            if (groups[coords.StartRow][coords.StartColumn] == groups[coords.EndRow][coords.EndColumn])
                Console.WriteLine(map[coords.StartRow][coords.StartColumn].Equals('0') ? "binary" : "decimal");
            else
                Console.WriteLine("neither");
        }
    }
}
