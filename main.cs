namespace Lab3
{

  public interface IBlocks
  {
    int[] ExecuteOne(int[] array);
    int[][] ExecuteTwo(int n);
    int[][] ExecuteThree(int[][] matrix);
    int[][] ExecuteFour(int[][] matrix1, int[][] matrix2);
  }

  public class Start
  {
    public static readonly Dictionary<int, IBlocks> Blocks = new Dictionary<int, IBlocks>
    {
      [13] = new VladBlock(),
      [14] = new DmytroBlock(),
      [15] = new AntonBlock(),
    };

    public static void Main()
    {
      Console.OutputEncoding = System.Text.UTF8Encoding.UTF8;
      int match, variant;
      int[] array = null;
      int[][] matrix = null, matrix2 = null;
      do
      {
        Console.Write("\n[<- 0]\nВолощук Влад (Варіант 13)\nДмитро Киба (Варіант 14)\nПопов Антон (Варіант 15)\nВведіть варіант: ");
        variant = int.Parse(System.Console.ReadLine());
        do
        {
          Console.Write("\n[<- 0] Введіть номер блоку (1-4): ");
          match = int.Parse(System.Console.ReadLine());
          if (Blocks.TryGetValue(variant, out IBlocks block))
          {
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
                matrix = Lib.match_matrix(matrix);
                matrix2 = Lib.match_matrix(matrix2);
                Console.WriteLine("In 1");
                Lib.print_matrix(matrix);
                Console.WriteLine("\nIn 2");
                Lib.print_matrix(matrix2);
                matrix = block.ExecuteFour(matrix, matrix2);
                Console.WriteLine("\nOut");
                Lib.print_matrix(matrix);
                break;
            }
          }
          else
          {
            Console.WriteLine("Немає такого блоку/варіанту");
          }

        } while (match != 0);

      } while (variant != 0);
    }
  }
}
