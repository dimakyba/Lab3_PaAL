namespace Lab3
{
  public class Anton : IStudents
  {
    public int[] one_alg(int[] array)
    {
      int counter = 0;

        int arraySize = array.Length; 
        for (int i = 0; i < arraySize; i++) if (array[i] % 2 == 0)counter++;

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
      int[] firstRow = matrix[0];
      int len = firstRow.Length;
      int splitLen = len/2;
      int[] firstHalf = new int[splitLen];
      int[] secondHalf = new int[len-splitLen];
      if (len > 10)
      {
        Array.Copy(firstRow, 0, firstHalf, 0, splitLen);
        Array.Copy(firstRow, splitLen, secondHalf, 0,secondHalf.Length);
      } 

      for (int i = matrix.Length-1; i>0; i--)matrix[i] = matrix[i-1]; 
      matrix[0] = firstHalf;
      Array.Resize(ref matrix, matrix.Length);
      for (int i = matrix.Length - 1; i > 0; i--)matrix[i] = matrix[i - 1];
      
      matrix[1] = secondHalf;
      return matrix;
    }

    public int[][] four_alg(int[] array, int[] array2, int[][] _, int[][] __)
    {
      int cols = array.Length;
      int rows = array2.Length;

      int[][] solution = new int[cols][];
      for (int i = 0; i < cols; i++)
      {
          solution[i] = new int[rows];
          for (int j = 0; j < rows; j++)solution[i][j] = array[i] + array2[j];
      }

      System.Console.WriteLine("\nКвадратна матриця, сформована із сум елементів i-тої matrix1 та j-тої matrix2: ");
      Lib.print_matrix(solution);

      int[][] transposedSolution = new int[rows][];
      for (int i = 0; i < rows; i++)
      {
        transposedSolution[i] = new int[cols];
        for (int j = 0; j < cols; j++)transposedSolution[i][j] = solution[j][i];
      }

      System.Console.WriteLine("\nТранспонована матриця: ");
      Lib.print_matrix(transposedSolution);
      for (int i = 0; i < rows; i++)Array.Reverse(transposedSolution[i]);


      int[] temp = transposedSolution[0];
      transposedSolution[0] = transposedSolution[rows - 1];
      transposedSolution[rows - 1] = temp;



      System.Console.WriteLine("\nКінцевий результат: ");
      Lib.print_matrix(transposedSolution);
      return transposedSolution;
    }

  }
}