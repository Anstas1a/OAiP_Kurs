﻿using System;
using System.IO;

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

                    Console.WriteLine();
                    Console.WriteLine("Выберите направление сортировки:");
                    Console.WriteLine(String.Format("1 - {0}", result_table.DirectionSortName((int)ESortDirection.Left)));
                    Console.WriteLine(String.Format("2 - {0}", result_table.DirectionSortName((int)ESortDirection.Right)));
                    Console.WriteLine("3 - Случайная");
                    choice = int.Parse(Console.ReadLine());
                    int direction;
                    switch (choice)
                    {
                        case 1:
                            direction = (int)ESortDirection.Left;
                            break;
                        case 2:
                            direction = (int)ESortDirection.Right;
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

                    Console.WriteLine();
                    Console.WriteLine("отсортированный массив:");
                    ReadMas(a);
                    Console.WriteLine();
                    Console.WriteLine(result_table.Result_row_heading());
                    Console.WriteLine(result_table.Result_row());
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
            Console.WriteLine();
        }

        static int[] WriteMas()
        {
            int[] a;
            using (StreamReader reader = new StreamReader(path))
            {
                var line_size = reader.ReadLine();
                if (line_size != null)
                {
                    int size = int.Parse(line_size);


                    if (size <= 0)
                    {
                        throw new Exception("Некорректный размер массива");
                    }

                    a = new int[size];

                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var line_mas = line.Split(' ');
                        if (size == line_mas.Length)
                        {
                            for (int i = 0; i < line_mas.Length; i++)
                            {
                                a[i] = int.Parse(line_mas[i]);
                            }
                        }
                        else
                        {
                            throw new Exception("Некорректный размер массива");
                        }
                    }
                    else
                    {
                        throw new Exception("Некорректный входные данные");
                    }
                }
                else
                {
                    throw new Exception("Файл не может быть пустым");
                }
            }

            return a;
        }
    }
}
