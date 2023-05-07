using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public enum ESortMethod
    {
        Bubble = 1,
        Shake
    }

    public enum EDirectionSort
    {
        Right = 1,
        Left
    }

    internal class ResultTable
    {
        public int[] sort_mas { get; set; }
        public int count_comparison { get; set; }
        public ESortMethod sort_method { get; set; }
        public int count_permutation { get; set; }
        public EDirectionSort direction_sort { get; set; }

        public string result_row()
        {
            return string.Format("|  {0}  |  {1}  |  {2}  |  {3}  |", 
                count_comparison,
                count_permutation,
                MethodSortName((int)sort_method), 
                DirectionSortName((int)direction_sort)
                );
        }

        public string result_row_heading()
        {
            return "|  Сравнений  |  Перестановок  |  Метод сортировки  |  Направление сортировки  |";
        }

        public string MethodSortName(int method)
        {
            switch (method)
            {
                case (int)ESortMethod.Bubble:
                    return "Сортировка методом пузырька";
                case (int)ESortMethod.Shake:
                    return "Шейкерная сортировка";
                default:
                    return "";
            }
        }

        public string DirectionSortName(int direction)
        {
            switch (direction)
            {
                case (int)EDirectionSort.Right:
                    return "По возрастанию";
                case (int)EDirectionSort.Left:
                    return "По убыванию";
                default:
                    return "";
            }
        }
    }
}
