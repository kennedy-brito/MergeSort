namespace Sort;

public static partial class Sort
{
  public static void SelectionSort(int[] arr)
  {
    int menor;
    int i, j;
    for (i = 0; i < arr.Length - 1; i++)
    {
      menor = i;

      for (j = i + 1; j < arr.Length; j++)
      {
        if (arr[j] < arr[menor])
        {
          menor = j;
        }
      }
      (arr[menor], arr[i]) = (arr[i], arr[menor]);
    }
  }
}