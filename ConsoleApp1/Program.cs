using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        //Файл с данными массива
        const string path = "data-mas.txt";

        static void Main(string[] args)
        {
            try
            {
                var a = WriteMas();

                if (a.Length != 0)
                {
                    ReadMas(a);

                    var result_table = new ResultTable();
                    var sortMethod = new SortMethod();
                    Random rnd = new Random();

                    Console.WriteLine("Выберите метод сортировки:");
                    Console.WriteLine(String.Format("1 - {0}", result_table.MethodSortName((int)ESortMethod.Bubble)));
                    Console.WriteLine(String.Format("2 - {0}", result_table.MethodSortName((int)ESortMethod.Shake)));
                    Console.WriteLine("3 - Случайная");

                    int choice = int.Parse(Console.ReadLine());
                    int sort;
                    switch(choice)
                    {
                        case 1:
                            sort = (int)ESortMethod.Bubble;
                            break;
                        case 2:
                            sort = (int)ESortMethod.Shake;
                            break;
                        case 3:
                            sort = rnd.Next(1, 3);
                            break;
                        default:
                            sort = rnd.Next(1, 3);
                            break;
                    }

                    Console.WriteLine("Выберите направление сортировки:");
                    Console.WriteLine(String.Format("1 - {0}", result_table.DirectionSortName((int)EDirectionSort.Left)));
                    Console.WriteLine(String.Format("2 - {0}", result_table.DirectionSortName((int)EDirectionSort.Right)));
                    Console.WriteLine("3 - Случайная");
                    choice = int.Parse(Console.ReadLine());
                    int direction;
                    switch (choice)
                    {
                        case 1:
                            direction = (int)EDirectionSort.Left;
                            break;
                        case 2:
                            direction = (int)EDirectionSort.Right;
                            break;
                        case 3:
                            direction = rnd.Next(1, 3);
                            break;
                        default:
                            direction = rnd.Next(1, 3);
                            break;
                    }

                    switch (sort)
                    {
                        case (int)ESortMethod.Bubble:
                            result_table = sortMethod.Bubble(a, direction);
                            break;
                        case (int)ESortMethod.Shake:
                            result_table = sortMethod.Shake(a, direction);
                            break;
                    }

                    Console.WriteLine("отсортированный массив:");
                    ReadMas(a);
                    Console.WriteLine();
                    Console.WriteLine(result_table.result_row_heading());
                    Console.WriteLine(result_table.result_row());
                    Console.WriteLine();
                }
               
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }

        static void ReadMas(int[] a)
        {
            for(int i=0;i<a.Length;i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        static int[] WriteMas()
        {
            int[] a;
            using (StreamReader reader = new StreamReader(path))
            {
                int size = int.Parse(reader.ReadLine());

                a = new int[size];

                var line_mas = reader.ReadLine().Split(' ');
                for (int i = 0; i < line_mas.Length; i++)
                {
                    a[i] = int.Parse(line_mas[i]);
                }
            }

            return a;
        }
    }
}
