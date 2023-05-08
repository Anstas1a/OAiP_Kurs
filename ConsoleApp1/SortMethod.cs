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
                direction_sort = (ESortDirection)direction_sort
            };
            return result;
        }

        public ResultTable Shake(int[] a, int direction_sort)
        {
            var result = new ResultTable()
            {
                sort_method = ESortMethod.Shake,
                direction_sort = (ESortDirection)direction_sort
            };

            var count_comparison = 0;
            var count_permutation = 0;
            var isSort = false;
            var left_index = 0;
            var right_index = a.Length-1;
            do
            {
                var left = left_index;
                var right = right_index;
                isSort = false;
                while (left != right)
                {
                    int next_numb = left > right ? left - 1 : left + 1;
                    count_comparison++;
                    if (direction_sort == 1 ? a[left] > a[next_numb] : a[left] < a[next_numb])
                    {
                        var num = a[next_numb];
                        a[next_numb] = a[left];
                        a[left] = num;
                        isSort = true;
                        count_permutation++;
                    }
                    left = next_numb;
                }
                int num_direction = left_index;
                left_index = right_index;
                right_index = num_direction;
                direction_sort = direction_sort == 1 ? 2 : 1;

            } while (isSort);

            result.count_comparison = count_comparison;
            result.count_permutation = count_permutation;
            return result;
        }
    }
}
