using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons3_task3
{
    internal class DynamicArray<T>
    {

        //1.	Конструктор без параметров (создаётся массив ёмкостью 8 элементов).
        public DynamicArray() 
        {
            int[] array = new int[8];

        }

        //2.	Конструктор с одним целочисленным параметром (создаётся массив указанной ёмкости).
        public DynamicArray(int size)
        {
            int[] array = new int [size];
        }

        //3.Конструктор, который в качестве параметра принимает коллекцию, реализующую интерфейс IEnumerable<T>,
        //создаёт массив нужного размера и копирует в него все элементы из коллекции.
        public DynamicArray(T size)
        {
            int[] array = new int[size];
        }



    }
}
