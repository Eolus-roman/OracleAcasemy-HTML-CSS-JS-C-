using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {

        static void Sort(int[] array, int l, int r)
        {
            int i = l; int j = r;
            int x = array[(l + r) / 2]; //Получение опорнорного элемента ) Как бЫло указано на первом этапе.
            while (i <= j)
            {
                while (array[i] < x) i++;
                while (array[j] > x) j--;
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }
            //Рекурсия каждой части массива как и было указано во втором этапе =)
            if (l < j) Sort(array, l, j);
            if (i < r) Sort(array, i, r);
        }
        static void Main(string[] args)
        {
            Console.Write("Вввед количество строк в массиве N = ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] array = new int[size];
            //Random
            Random rand = new Random();
            for (int i = 0; i < array.Length; i++)
            array[i] = rand.Next(-1000, 1000); //

            /* int i = 0;             while (i != size)             {                 //string a = Console.ReadLine();                 array[i++] = Convert.ToInt32(Console.ReadLine());             }*/
            Console.WriteLine();
            foreach (int ar in array)
            Console.WriteLine(ar + " ");


            Console.WriteLine();
            Console.WriteLine("Быстрая сортировка");
            Sort(array, 0, array.Length - 1);
            foreach (int ar in array)
                Console.WriteLine(ar + " ");
            Console.ReadLine();
        }

    }
}