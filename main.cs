using System;
using System.Collections.Generic;

namespace Lab3
{
  public interface IBlocks
  {
    int[] ExecuteOne(int[] array);
    int[][] ExecuteTwo(int n);
    int[][] ExecuteThree(int[][] matrix);
    // int[][] ExecuteFour(int[][] matrix1, int[][] matrix2);
    // int[][] ExecuteFour(int[] array);
    // int[][] ExecuteFour(int[] array1, int[] array2);
    // int[][] ExecuteFour(int[] array1 = null, int[] array2 = null, int[][] matrix1 = null, int[][] matrix2 = null);
    int[][] ExecuteFour(int[] _, int[] __, int[][] matrix1, int[][] matrix2);

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
      int variant;

      do
      {
        Console.Write("\n[<- 0]\nВолощук Влад (Варіант 13)\nДмитро Киба (Варіант 14)\nПопов Антон (Варіант 15)\nВведіть варіант: ");
        variant = int.Parse(System.Console.ReadLine());

        if (Blocks.TryGetValue(variant, out IBlocks block))
        {
          ProcessBlock(block);
        }
        else
        {
          Console.WriteLine("Немає такого блоку/варіанту");
        }

      } while (variant != 0);
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
