namespace Lab3
{

  public interface IBlocks
  {
    int[] ExecuteOne(int[] array);
    int[][] ExecuteTwo(int n);
    int[][] ExecuteThree(int[][] matrix);
    int[][] ExecuteFour(int[] array1 = null, int[] array2 = null, int[][] matrix1 = null, int[][] matrix2 = null);
  }

  public class Start
  {
    public static readonly Dictionary<int, IBlocks> Blocks = new()
    {
      [1] = new AntonBlock(),
      [2] = new VladBlock(),
      [3] = new DmytroBlock(),
    };

    public static void Main()
    {
      int match, variant;
      int[] array = null, array2 = null;
      int[][] matrix = null, matrix2 = null;
      do {
        Console.Write("\n<- [0]\nПопов Антон [1]\nВолощук Влад [2]\nДмитро Киба [3]\n> ");
        variant = int.Parse(System.Console.ReadLine());
        do {
          Console.Write("\n<- [0]\nНомер блоку > ");
          match = int.Parse(System.Console.ReadLine());
          if (Blocks.TryGetValue(variant, out IBlocks block)) {
            switch (match) {
              case 1:
                    Bundle.one(ref array, block);
                    break;
              case 2:
                    Bundle.two(ref matrix, block);
                    break;
              case 3:
                    Bundle.three(ref matrix, block);
                    break;
              case 4:
                    Bundle.four(ref array, ref array2, ref matrix, ref matrix2, block, variant);
                    break;
            }
          }
          else Console.WriteLine("Немає такого блоку/варіанту");

        } while (match != 0);

      } while (variant != 0);
    }
  }
}
