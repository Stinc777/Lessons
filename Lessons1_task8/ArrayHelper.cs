using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons1_task8
{
    internal class ArrayHelper
    {
        public static void FillRandomNumbers(int[,,] array, int xS, int yS, int zS, Random rnd)  
        {
            for (int x = 0; x < xS; x++)
            {
                for (int y = 0; y < yS; y++)
                {
                    for (int z = 0; z < zS; z++)
                    {
                        array[x, y, z] = rnd.Next(-100, 100);
                    }
                }
            }
        }

        public static void Print3DArray(int[,,] array)
        {
            int xSize = array.GetLength(0);
            int ySize = array.GetLength(1);
            int zSize = array.GetLength(2);

            for (int x = 0; x < xSize; x++)
            {

                Console.Write("{");

                for (int y = 0; y < ySize; y++)
                {
                    if (y > 0)
                    {
                        Console.Write(", ");
                    }

                    Console.Write("{");

                    for (int z = 0; z < zSize; z++)
                    {
                        if (z > 0)
                        {
                            Console.Write(", ");
                        }

                        Console.Write(array[x, y, z]);
                    }

                    Console.Write("}");
                }

                Console.WriteLine("}");
            }
        }

        public static void ReplacementArray(int[,,] array, int xS, int yS, int zS) 
        {
            for (int x = 0; x < xS; x++)
            {
                for (int y = 0; y < yS; y++)
                {
                    for (int z = 0; z < zS; z++)
                    {
                        if (array[x, y, z] > 0)
                        {
                            array[x, y, z] = 0;
                        }
                    }
                }
            }
        }

    }

}
