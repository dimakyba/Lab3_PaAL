namespace Lab3 {
  public class Vlad : IStudents {
    public int[] one_alg(int[] array) {
      int max = 0;
      int len = array.Length;
      int[] tarray = new int[len + 1];

      for (int i = 0; i < len; i++) {
        if (array[i] > array[max]) {
          max = i;
        }
      }

      Console.WriteLine($"Максимальний елемент: {array[max]}");

      if (array[max] % 2 == 0) {
        for (int i = len + 1; i --> 0;)
          tarray[i] = (i > max) ? array[i - 1] : array[i];

          (tarray[max], tarray[max + 1]) = (array[max] / 2, array[max] / 2);
        return tarray;
      }

      return array;
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

    public int[][] three_alg(int[][] matrix) {
      int i = 0, min_i = 0, min_j = 0, len = matrix.Length;
      int[][] result = new int[len + 1][];

      for (;i < len; i++) {
        for (int j = 0; j < matrix[i].Length; j++) {
          if (matrix[i][j] < matrix[min_i][min_j]) {
            min_i = i;
            min_j = j;
          }
        }
      }

      for (i = 0; i < min_i; i++) result[i] = matrix[i];

      Lib.gen_array(out result[i]);

      for (; i < len; i++) result[i + 1] = matrix[i];

      return result;
    }

    public int[][] four_alg(int[] a, int[] a2, int[][] matrix1, int[][] matrix2) {
      int maxLength = Math.Max(matrix1.Length, matrix2.Length);
      int[][] result = new int[maxLength][];

      for (int i = 0; i < maxLength; i++) {
        int len1 = i < matrix1.Length ? matrix1[i].Length : 0;
        int len2 = i < matrix2.Length ? matrix2[i].Length : 0;
        int maxLen = Math.Max(len1, len2);

        result[i] = new int[maxLen];

        for (int j = 0; j < maxLen; j++)
          result[i][j] = (j < len1 ? matrix1[i][j] : 0) + (j < len2 ? matrix2[i][j] : 0);
      }

      return result;
    }
  }
}
