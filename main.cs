using System.Text;
namespace Lab3 {
  public interface IStudents {
    int[] one_alg(int[] a);
    int[][] two_alg(int n);
    int[][] three_alg(int[][] m);
    int[][] four_alg(int[] a1 = null, int[] a2 = null, int[][] m1 = null, int[][] m2 = null);

  }

  public partial class Start {
    public static readonly Dictionary<int, IStudents> Students = new() {
      [1] = new Anton(),
      [2] = new Vlad(),
      [3] = new Dmytro(),
    };


    public static void Main() {
      Console.OutputEncoding = UTF8Encoding.UTF8;
      int match, student;
      int[] array1 = null, array2 = null;
      int[][] matrix1 = null, matrix2 = null;
      
      do {
        Lib.print_student_options();
        student = int.Parse(Console.ReadLine());

        do {
          Lib.print_block_options();
          match = int.Parse(Console.ReadLine());
          
          if (Students.TryGetValue(student, out IStudents block)) {
            switch (match) {
              case 1:
                process_one(ref array1, block);
                break;
              case 2:
                process_two(ref matrix1, block);
                break;
              case 3:
                process_three(ref matrix1, block);
                break;
              case 4:
                process_four(ref array1, ref array2, ref matrix1, ref matrix2, block, student);
                break;
            }
          }
          else Console.WriteLine("Немає такого блоку/варіанту");

        } while (match != 0);


      } while (student != 0);
    }

    private static void ProcessBlock(IBlocks block)
    {
      int match;
      int[] array = null, array2 = null;
      int[][] matrix = null, matrix2 = null;

      do
      {
        Console.Write("\n[<- 0] Введіть номер блоку (1-4): ");
        match = int.Parse(System.Console.ReadLine());

        switch (match)
        {
          case 1:
            array = Lib.match_array(array);
            Console.WriteLine("In");
            Lib.print_array(array);
            array = block.ExecuteOne(array);
            Console.WriteLine("Out");
            Lib.print_array(array);
            break;

          case 2:
            Console.WriteLine("Введіть n: ");
            int n = int.Parse(System.Console.ReadLine());
            matrix = block.ExecuteTwo(n);
            Console.WriteLine("Out");
            Lib.print_matrix(matrix);
            break;

          case 3:
            matrix = Lib.match_matrix(matrix);
            Console.WriteLine("In");
            Lib.print_matrix(matrix);
            matrix = block.ExecuteThree(matrix);
            Console.WriteLine("Out");
            Lib.print_matrix(matrix);
            break;

          case 4:
            ProcessVariantFour(block, array, array2, matrix, matrix2);
            break;
        }

      } while (match != 0);
    }

    private static void ProcessVariantFour(IBlocks block, int[] array, int[] array2, int[][] matrix, int[][] matrix2)
    {
      int variant = block switch
      {
        VladBlock _ => 13,
        DmytroBlock _ => 14,
        AntonBlock _ => 15,
        _ => throw new ArgumentException("Invalid block type"),
      };

      switch (variant)
      {
        case 13:
          matrix = Lib.match_matrix(matrix);
          matrix2 = Lib.match_matrix(matrix2);
          Console.WriteLine("In 1");
          Lib.print_matrix(matrix);
          Console.WriteLine("\nIn 2");
          Lib.print_matrix(matrix2);
          matrix = block.ExecuteFour(null,null,matrix, matrix2);
          Console.WriteLine("\nOut");
          Lib.print_matrix(matrix);
          break;

        case 14:
          array = Lib.match_array(array);
          Console.WriteLine("In 1");
          Lib.print_array(array);
          matrix = block.ExecuteFour(array);
          Console.WriteLine("Out");
          Lib.print_matrix(matrix);
          break;

        case 15:
          array = Lib.match_array(array);
          array2 = Lib.match_array(array2);
          Console.WriteLine("In 1");
          Lib.print_array(array);
          Console.WriteLine("\nIn 2");
          Lib.print_array(array2);
          matrix = block.ExecuteFour(array, array2);
          Console.WriteLine("\nOut");
          Lib.print_matrix(matrix);
          break;

        default:
          Console.WriteLine("Invalid variant");
          break;
      }
    }
  }
}
