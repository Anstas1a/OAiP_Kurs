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

    public enum ESortDirection
    {
        Right = 1,
        Left
    }

    internal class ResultTable
    {
        public int count_comparison { get; set; }
        public ESortMethod sort_method { get; set; }
        public int count_permutation { get; set; }
        public ESortDirection direction_sort { get; set; }

        public string Result_row()
        {
            return string.Format("|  {0}  |  {1}  |  {2}  |  {3}  |", 
                count_comparison,
                count_permutation,
                MethodSortName((int)sort_method), 
                DirectionSortName((int)direction_sort)
                );
        }

        public string Result_row_heading()
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
                case (int)ESortDirection.Right:
                    return "По возрастанию";
                case (int)ESortDirection.Left:
                    return "По убыванию";
                default:
                    return "";
            }
        }
    }
}
