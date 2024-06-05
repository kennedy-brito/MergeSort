namespace Sort;

public static partial class Sort
{
  public static void QuickSort(int[] arr, int inicio, int fim)
  {
    if (inicio < fim)
    {
      int p = Particionar(arr, inicio, fim);

      QuickSort(arr, inicio, p - 1);
      QuickSort(arr, p + 1, fim);
    }
  }

  private static int Particionar(int[] a, int limInf, int limSup)
  {
    int pivot, temp;
    int baixo, alto;

    pivot = a[limInf];
    alto = limSup;
    baixo = limInf;

    while (baixo < alto)
    {
      //move o baixo até encontrar um elemento maior que o pivot
      while (a[baixo] <= pivot && baixo < limSup)
      {
        baixo++;
      }
      while (a[alto] >= pivot && alto > limInf)
      {
        alto--; 
      }
      if (baixo < alto)
      { // Troca.
        temp = a[baixo];
        a[baixo] = a[alto];
        a[alto] = temp;
      }
    }
    a[limInf] = a[alto];
    a[alto] = pivot;
    return alto;
  }
}