using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static void Sort(int[] array, int minIndex, int maxIndex)
        {
            int i = minIndex;
            int j = maxIndex;
            // minIndex maxIndex referenceElement
            int referenceElement = array[(minIndex + maxIndex) / 2]; //Получение опорного элемента
            while (i <= j)
            {
                while (array[i] < referenceElement)
                {
                    i++;
                }
                while (array[j] > referenceElement)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            //Рекурсия каждой части массива
            if (minIndex < j)
            {
                Sort(array, minIndex, j);
            }
            if (i < maxIndex)
            {
                Sort(array, i, maxIndex);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Ввведите количество строк в массиве N = ");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[size];
            // Массив заполняется рандомными числами в дитапозоне (-1000; 1000):
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(-1000, 1000); // Задаем интервал заполнения массива случайными числами
            }
            //Ввод значеений массива вручную:
            /*
            int i = 0;
            while (i != size)
            {
                array[i++] = Convert.ToInt32(Console.ReadLine());
            }
            */
            Console.WriteLine();
            foreach (int ar in array)
            {
                Console.WriteLine(ar + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Быстрая сортировка: ");
            Sort(array, 0, array.Length - 1);
            foreach (int ar in array)
            {
                Console.WriteLine(ar + " ");
            }
            Console.ReadLine();
        }

    }
}