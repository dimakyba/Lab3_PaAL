namespace Lab3
{
  public class Dmytro : IStudents
  {
    public int[] one_alg(int[] array)
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

    public int[][] two_alg(int n) {
      int digit_count = (int)Math.Ceiling(Math.Log10(n));
      int max_sum = digit_count * 9;
      int[][] sum_lists = new int[max_sum + 1][];

      for (int i = 1; i <= max_sum; i++) {
        sum_lists[i] = new int[n / i];
        for (int j = 1; j <= n / i; j++) {
          sum_lists[i][j - 1] = j * i;
        }
      }

      int[][] result = new int[n][];

      for (int i = 1; i <= n; i++)
        result[i - 1] = sum_lists[num_sum(i)];

      return result;

      static int num_sum(int n) {
        int sum = 0;
        while (n > 0) {
          sum += n % 10;
          n /= 10;
        }
        return sum;
      }
    }

    public int[][] three_alg(int[][] matrix)
    {
      int FindMinRowIndex(int[][] matrix)
      {
        int minRowIndex = 0;
        int minValue = matrix[0][0];

        for (int i = 0; i < matrix.Length; i++)
        {
          for (int j = 0; j < matrix[i].Length; j++)
          {
            if (matrix[i][j] < minValue)
            {
              minValue = matrix[i][j];
              minRowIndex = i;
            }
          }
        }

        return minRowIndex;
      }
      int minRowIndex = FindMinRowIndex(matrix);
      int[] newRow = new int[matrix[0].Length];
      int[][] newMatrix = new int[matrix.Length + 1][];

      for (int i = 0; i < minRowIndex; i++)
      {
        newMatrix[i] = matrix[i];
      }
      newMatrix[minRowIndex] = newRow;

      for (int i = minRowIndex + 1; i < newMatrix.Length; i++)
      {
        newMatrix[i] = matrix[i - 1];
      }

      return newMatrix;
    }

    public int[][] four_alg(int[] nr, int[] _, int[][] __, int[][] ___)
    {
      int GetCountOfOnes(int[] arr)
      {
        int counter = 0;
        for (int i = 0; i < arr.Length; i++)
        {
          if (arr[i] == 1)
          {
            counter++;
          }
        }

        return counter;
      }

      int N = nr.Length, sumY = 0;
      int[][] array = new int[N][], C = new int[N][], Y = new int[N][];
      array[0] = nr;

      for (int i = 0; i < N; i++)
      {
        C[i] = new int[N];
        for (int j = 0; j < N; j++)
        {
          C[i][j] = (array[0][i] == array[0][j]) ? 1: 0;
        }
        Array.Sort(C[i]);
        Array.Reverse(C[i]);
      }

      Random rnd = new();
      for (int i = 0; i < N; i++)
      {
        int rowSize = GetCountOfOnes(C[i]);
        Y[i] = new int[rowSize];

        for (int j = 0; j < rowSize; j++)
        {
          Y[i][j] = rnd.Next(-10, 10);
          sumY += Y[i][j];
        }
      }

      Console.WriteLine("Сума всіх елементів матриці Y: {0}", sumY);

      return Y;
    }
  }
}
