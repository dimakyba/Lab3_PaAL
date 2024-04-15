using System.Diagnostics;

namespace Lab3
{
  public class Lib
  {
    public static int[] match_array(int[] array)
    {
      Console.Write("\nЯку масив використовувати?\n 1 - Ввести новий\n 2 - Згенерувати новий\n 3 - Використати старий\n Введіть число: ");
      int option = int.Parse(Console.ReadLine());
      switch (option) {
        case 1:
          int[] read_array;
          Lib.read_array(out read_array);
          array = read_array;
          break;
        case 2:
          int[] gen_array;
          Lib.gen_array(out gen_array);
          array = gen_array;
          break;
        default:
          break;
      }
      return array;
    }

    public static int[][] match_matrix(int[][] matrix)
    {
      Console.Write("\nЯку матрицю використовувати?\n 1 - Ввести нову\n 2 - Згенерувати нову\n 3 - Використати стару\n Введіть число: ");
      int option = int.Parse(System.Console.ReadLine());
      switch (option) {
        case 1:
          int[][] read_matrix;
          Lib.read_matrix(out read_matrix);
          matrix = read_matrix;
          break;
        case 2:
          int[][] gen_matrix;
          Lib.gen_matrix(out gen_matrix);
          matrix = gen_matrix;
          break;
        default:
          break;
      }
      return matrix;
    }

    public static void print_array(int[] array)
    {
      foreach (var item in array) 
        Console.Write($"{item} ");
      Console.WriteLine();
    }

    public static void read_array(out int[] array)
    {
      Console.Write("\n   Введіть масив: ");
      string[] nums = Console.ReadLine().Split();
      array = new int[nums.Length];
      for (int i = 0; i < nums.Length; i++)
        array[i] = int.Parse(nums[i]);
    }

    public static void gen_array(out int[] array)
    {
      var rand = new Random();
      int length = rand.Next(1, 5);
      array = new int[length];
      for (int i = 0; i < length; i++)
        array[i] = rand.Next(-100, 101);
    }

    public static void print_matrix(int[][] a)
    {
      for (int i = 0; i < a.Length; i++) {
        if (a[i] == null) break;

        for (int j = 0; j < a[i].Length; j++)
          Console.Write($"{a[i][j],2} ");
          
        Console.WriteLine();
      }
    }

    public static void read_matrix(out int[][] matrix) 
    {
      Console.Write("\nВведіть кількість рядків матриці: ");
      int height = int.Parse(Console.ReadLine());

      matrix = new int[height][];

      for (int i = 0; i < height; i++) {
        Console.Write($"\nВведіть елементи {i}-го рядка: ");
        string[] data = Console.ReadLine().Split();
        matrix[i] = new int[data.Length];
        for (int j = 0; j < data.Length; j++)
          matrix[i][j] = int.Parse(data[j]);
      }
    }

    public static void gen_matrix(out int[][] matrix)
    {
      var rand = new Random();
      int length, height = rand.Next(1, 10);
      matrix = new int[height][];

      for (int i = 0; i < height; i++)
      {
        length = rand.Next(1, 10);
        matrix[i] = new int[length];
        for (int j = 0; j < length; j++)
          matrix[i][j] = rand.Next(-100, 101);
      }
    }
  }

  public static class Bundle {
    public static void one(ref int[] array, IBlocks block)
    {
        array = Lib.match_array(array);

        Console.WriteLine("Вхідна матриця");
        Lib.print_array(array);

        array = block.ExecuteOne(array);

        Console.WriteLine("Результат");
        Lib.print_array(array);
    }

    public static void two(ref int[][] matrix, IBlocks block)
    {
        double before = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;
        
        Console.WriteLine("Введіть n: ");
        int n = int.Parse(System.Console.ReadLine());

        matrix = block.ExecuteTwo(n);
        double after = Process.GetCurrentProcess().WorkingSet64 / 1024.0 / 1024.0;

        Console.WriteLine("Результат");
        Lib.print_matrix(matrix);

        Console.WriteLine($"Використання пам'яті:\nДо {before:F4} MB");
        Console.WriteLine($"Після {after:F4} MB");
        Console.WriteLine($"Різниця {after - before:F4} MB");
    }

    public static void three(ref int[][] matrix, IBlocks block)
    {
        matrix = Lib.match_matrix(matrix);

        Console.WriteLine("Вхідна матриця");
        Lib.print_matrix(matrix);

        matrix = block.ExecuteThree(matrix);

        Console.WriteLine("Результат");
        Lib.print_matrix(matrix);
    }

    public static void four(ref int[] array, ref int[] array2, ref int[][] matrix, ref int[][] matrix2, IBlocks block, int variant)
    {
      switch (variant) {
        case 1: 
          array = Lib.match_array(array);
          array2 = Lib.match_array(array2);

          Console.WriteLine("Вхідний масив 1");
          Lib.print_array(array);

          Console.WriteLine("\nВхідний масив 2");
          Lib.print_array(array2);

          matrix = block.ExecuteFour(array1: array, array2: array2);
          break;

        case 2:
          matrix = Lib.match_matrix(matrix);
          matrix2 = Lib.match_matrix(matrix2);

          Console.WriteLine("Вхідна матриця 1");
          Lib.print_matrix(matrix);

          Console.WriteLine("\nВхідна матриця 2");
          Lib.print_matrix(matrix2);

          matrix = block.ExecuteFour(matrix1: matrix, matrix2: matrix2);
          break;

        case 3:
          matrix = Lib.match_matrix(matrix);

          Console.WriteLine("Вхідна матриця");
          Lib.print_matrix(matrix);

          matrix = block.ExecuteFour(matrix1: matrix);
          break;

        default:
          break;
      }

      Console.WriteLine("\nРезультат");
      Lib.print_matrix(matrix);   
    }
  }
}
