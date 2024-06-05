namespace Sort;

public static partial class Sort
{

  public static void InsertionSort(int[] arr)
  {
    for (int k = 1; k < arr.Length; k++)
    {
      int elemento = arr[k];
      int i = k - 1;
      while (i >= 0 && arr[i] > elemento)
      {
        arr[i + 1] = arr[i];
        i--;
      }
      arr[i + 1] = elemento;
    }
  }
}