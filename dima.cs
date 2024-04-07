namespace Lab3
{
  public class DmytroBlock : Lab3.IBlocks
  {
    public int[] ExecuteOne(int[] array)
    {
      // Вставити після кожного від’ємного елемента його модуль.
      int negativeCount = 0;
      foreach (int num in array)
      {
        if (num < 0)
        {
          negativeCount++;
        }
      }

      int[] newArray = new int[array.Length + negativeCount];
      int newIndex = 0;

      foreach (int num in array)
      {
        newArray[newIndex] = num;
        newIndex++;

        if (num < 0)
        {
          newArray[newIndex] = Math.Abs(num);
          newIndex++;
        }
      }

      return newArray;
    }

    public int[][] ExecuteTwo(int n)
    {
      static int num_sum(int n)
      {
        int sum = 0;
        while (n > 0)
        {
          sum += n % 10;
          n /= 10;
        }
        return sum;
      }

      int[][] sum_lists = new int[100][];

      for (int i = 1; i < n; i++)
      {
        int i_sum = num_sum(i);
        sum_lists[i_sum] = new int[n];

        int k = 0;
        for (int j = 1; j < (int)Math.Sqrt(i_sum); j++)
        {
          if (i_sum % j == 0)
          {
            sum_lists[i_sum][k++] = j;
            sum_lists[i_sum][k++] = i_sum / j;
          }
        }
      }

      return sum_lists;
    }

    public int[][] ExecuteThree(int[][] matrix)
    {
      //
      return [];
    }

    public int[][] ExecuteFour(int[][] matrix1, int[][] matrix2)
    {
      //
      return [];
    }
  }
}
