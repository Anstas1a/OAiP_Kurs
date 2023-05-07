namespace ConsoleApp1
{
    internal class SortMethod
    {
        public ResultTable Bubble(int[] a, int direction_sort)
        {
            var count_comparison = 0;
            var count_permutation = 0;
            var isSort = false;
            do
            {
                isSort= false;
                for(int i=0;i< a.Length-1;i++)
                {
                    count_comparison++;
                    if (direction_sort == 1 ? a[i] > a[i+1] : a[i] < a[i+1])
                    {
                        int num = a[i+1];
                        a[i+1] = a[i];
                        a[i] = num;
                        isSort = true;
                        count_permutation++;
                    }
                }
            }while(isSort);

            var result = new ResultTable()
            {
                count_comparison = count_comparison,
                count_permutation = count_permutation,
                sort_method = ESortMethod.Bubble,
                direction_sort = (EDirectionSort)direction_sort
            };
            return result;
        }

        public ResultTable Shake(int[] a, int direction_sort)
        {
            var count_comparison = 0;
            var count_permutation = 0;
            var isSort = false;
            var left = 0;
            var right = a.Length-1;
            do
            {
                isSort = false;
                for (int i = left; i < right; i++)
                {
                    count_comparison++;
                    if (direction_sort == 1 ? a[i] > a[i + 1] : a[i] < a[i + 1])
                    {
                        var num = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = num;
                        isSort = true;
                        count_permutation++;
                    }
                }
                var numDirection = right;
                right = left;
                left = numDirection;

            } while (isSort);

            var result = new ResultTable()
            {
                count_comparison = count_comparison,
                count_permutation = count_permutation,
                sort_method = ESortMethod.Shake,
                direction_sort = (EDirectionSort)direction_sort
            };
            return result;
        }
    }
}
