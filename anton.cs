namespace Lab3
{
  public class AntonBlock : Lab3.IBlocks
  {
    public int[] ExecuteOne(int[] array)
    {
      int counter = 0;
      int arraySize = array.Length;
      for (int i = 0; i < arraySize; i++) if (array[i] % 2 == 0) counter++;

      int[] solution = new int[counter + arraySize];

      for (int i = 0, j = 0; i < arraySize; i++, j++)
      {
        solution[j] = array[i];
        if (array[i] % 2 == 0)
        {
          j++;
          solution[j] = 0;

        }
      }
      return solution;
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
      int[] firstRow = matrix[0];
      int len = firstRow.Length;
      int splitLen = len / 2;
      int[] firstHalf = new int[splitLen];
      int[] secondHalf = new int[len - splitLen];
      if (len > 10)
      {
        Array.Copy(firstRow, 0, firstHalf, 0, splitLen);
        Array.Copy(firstRow, splitLen, secondHalf, 0, secondHalf.Length);
      }

      for (int i = matrix.Length - 1; i > 0; i--) matrix[i] = matrix[i - 1];
      matrix[0] = firstHalf;
      Array.Resize(ref matrix, matrix.Length);
      for (int i = matrix.Length - 1; i > 0; i--) matrix[i] = matrix[i - 1];

      matrix[1] = secondHalf;
      return matrix;
    }

    public int[][] ExecuteFour(int[] array, int[] array2)
    {
      int cols = array.Length;
      int rows = array2.Length;

      int[][] solution = new int[cols][];
      for (int i = 0; i < cols; i++)
      {
        solution[i] = new int[rows];
        for (int j = 0; j < rows; j++) solution[i][j] = array[i] + array2[j];
      }

      System.Console.WriteLine("\nКвадратна матриця, сформована із сум елементів i-тої matrix1 та j-тої matrix2: ");
      Lib.print_matrix(solution);

      int[][] transposedSolution = new int[rows][];
      for (int i = 0; i < rows; i++)
      {
        transposedSolution[i] = new int[cols];
        for (int j = 0; j < cols; j++) transposedSolution[i][j] = solution[j][i];
      }

      System.Console.WriteLine("\nТранспонована матриця: ");
      Lib.print_matrix(transposedSolution);
      for (int i = 0; i < rows; i++) Array.Reverse(transposedSolution[i]);

      int[] temp = transposedSolution[0];
      transposedSolution[0] = transposedSolution[rows - 1];
      transposedSolution[rows - 1] = temp;


      System.Console.WriteLine("\nКінцевий результат: ");
      Lib.print_matrix(transposedSolution);
      return transposedSolution;
    }

  }
}
