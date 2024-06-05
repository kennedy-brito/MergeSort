namespace Sort;

public static partial class Sort
{


  public static void MergeSort(int[] arr)
  {
    int[] aux = new int[arr.Length];
    MergeSort(arr, aux);
  }

  private static void MergeSort(int[] arr, int[] aux, int inicio = 0, int fim = -1)
  {
    fim = (fim < 0) ? arr.Length - 1 : fim;

    if (fim - inicio < 1) return;

    int meio = inicio + (fim - inicio) / 2;

    MergeSort(arr, aux, inicio, meio);
    MergeSort(arr, aux, meio + 1, fim);

    Merge(arr, aux, inicio, meio, fim);
  }

  private static void Merge(int[] arr, int[] aux, int inicio, int meio, int fim)
  {
    int esq = inicio, dir = meio + 1, k = inicio;

    while (esq <= meio && dir <= fim)
    {
      if (arr[dir] < arr[esq])
      {
        aux[k] = arr[dir];
        dir++;
        k++;
      }
      else
      {
        aux[k] = arr[esq];
        k++;
        esq++;
      }

    }

    while (esq <= meio)
    {
      aux[k] = arr[esq];
      esq++;
      k++;
    }
    while (dir <= fim)
    {
      aux[k] = arr[dir];
      dir++;
      k++;
    }

    //trocando os valores do vetor
    for (int i = inicio; i <= fim; i++)
    {
      arr[i] = aux[i];
    }
  }
}