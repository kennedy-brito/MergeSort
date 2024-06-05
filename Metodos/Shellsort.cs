namespace Sort;

public static partial class Sort
{

  public static void ShellSort(int[] arr)
  {
    int i, j, k = 1;
    while (k < arr.Length / 3)
    {
      k = 3 * k + 1;
    }

    while (k > 0)
    {
      for (i = k; i < arr.Length; i++)
      {
        int aux = arr[i];
        j = i;

        while (j >= k && arr[j - k] > aux)
        {
          arr[j] = arr[j - k];
          j = j - k;
        }

        arr[j] = aux;

      }

      k = (k - 1) / 3;
    }

  }
}