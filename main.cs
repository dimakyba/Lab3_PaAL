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
  }
}
