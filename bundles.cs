using System.Diagnostics;
namespace Lab3 {
  public static partial class Start {
    public static void process_one(ref int[] array, IStudents student)
    {
      array = Lib.match_array(array);

      Console.WriteLine("Вхідний масив");
      Lib.print_array(array);

      array = student.one_alg(array);

      Console.WriteLine("Результат");
      Lib.print_array(array);
    }

    public static void process_two(ref int[][] matrix, IStudents student)
    {
      double MB = 1048576.0;
      GC.Collect();
      double before = Process.GetCurrentProcess().WorkingSet64 / MB;
      
      Console.WriteLine("Введіть n: ");
      int n = int.Parse(System.Console.ReadLine());

      GC.TryStartNoGCRegion((long)MB*1000);
      two_algb(n);
      double after = Process.GetCurrentProcess().WorkingSet64 / MB;
      GC.EndNoGCRegion();
      GC.Collect();

      GC.TryStartNoGCRegion((long)MB*1000);
      matrix = student.two_alg(n);
      double afterb = Process.GetCurrentProcess().WorkingSet64 / MB;
      GC.EndNoGCRegion();

      Console.WriteLine("Результат");
      Lib.print_matrix(matrix);

      Console.WriteLine($"а) Використання пам'яті:\nа) До {before:F4} MB\nа) Після {afterb:F4} MB\nа) Різниця {afterb - before:F4} MB");

      Console.WriteLine($"\nб) Використання пам'яті:\nа) До {before:F4} MB\nб) Після {after:F4} MB\nб) Різниця {after - before:F4} MB");
    }

    public static int[][] two_algb(int n) {
      static int num_sum(int n) {
        int sum = 0;
        while (n > 0) {
          sum += n % 10;
          n /= 10;
        }
        return sum;
      }

      int[][] result = new int[n][];

      for (int i = 0; i < n; i++) {
        int sum = num_sum(i);
        result[i] = new int[n / (i+1)];
        for (int j = 1; j <= sum / (i+1); j++) {
          result[i][j - 1] = j * (i+1);
        }
      }
      return result;
    }

    public static void process_three(ref int[][] matrix, IStudents student)
    {
      matrix = Lib.match_matrix(matrix);

      Console.WriteLine("Вхідна матриця");
      Lib.print_matrix(matrix);

      matrix = student.three_alg(matrix);

      Console.WriteLine("Результат");
      Lib.print_matrix(matrix);
    }

    public static void process_four(ref int[] array, ref int[] array2, ref int[][] matrix, ref int[][] matrix2, IStudents student, int variant) {
      switch (variant) {
        case 1: 
          array = Lib.match_array(array);
          array2 = Lib.match_array(array2);

          Console.WriteLine("Вхідний масив 1");
          Lib.print_array(array);

          Console.WriteLine("\nВхідний масив 2");
          Lib.print_array(array2);

          matrix = student.four_alg(array, array2);
          break;

        case 2:
          matrix = Lib.match_matrix(matrix);
          matrix2 = Lib.match_matrix(matrix2);

          Console.WriteLine("Вхідна матриця 1");
          Lib.print_matrix(matrix);

          Console.WriteLine("\nВхідна матриця 2");
          Lib.print_matrix(matrix2);

          matrix = student.four_alg(m1: matrix, m2: matrix2);
          break;

        case 3:
          array = Lib.match_array(array);

          Console.WriteLine("Вхідний масив");
          Lib.print_array(array);

          matrix = student.four_alg(array);
          break;

        default:
          break;
      }

      Console.WriteLine("\nРезультат");
      Lib.print_matrix(matrix);   
    }
  }
}