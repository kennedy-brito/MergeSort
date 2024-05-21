using System.Collections.Concurrent;
using System.Reflection.Metadata;

namespace Sort;

public class Sort
{

  /************************************************
  uma forma de melhorar o algoritmo é verificando se houve troca
  se não houve nenhuma troca significa que o vetor já está ordenado
  *************************************************/
  public static void BubbleSort(int[] arr)
  {
    bool troca = true;
    for (int i = 0; i < arr.Length - 1 && troca; i++)
    {
      troca = false;
      for (int j = 0; j < arr.Length - 1; j++)
      {
        if (arr[j] > arr[j + 1])
        {
          troca = true;
          (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        }
      }
    }
  }
  public static void MergeSort(int[] arr, int inicio = 0, int fim = -1)
  {
    fim = (fim < 0) ? arr.Length - 1 : fim;

    if (fim - inicio < 1) return;

    int meio = inicio + (fim - inicio) / 2;

    MergeSort(arr, inicio, meio);
    MergeSort(arr, meio + 1, fim);

    Merge(arr, inicio, meio, fim);
  }

  private static void Merge(int[] arr, int inicio, int meio, int fim)
  {
    int[] aux = new int[fim - inicio + 1];
    int esq = inicio, dir = meio + 1, k = 0;

    while (esq <= meio && dir <= fim)
    {
      if (arr[dir] < arr[esq])
      {
        aux[k] = arr[dir];
        ++dir;
        ++k;
      }
      else
      {
        aux[k] = arr[esq];
        ++k;
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
    for (int i = 0; i < aux.Length; i++)
    {
      arr[inicio + i] = aux[i];
    }
  }

  public static void QuickSort(int[] arr, int start, int end)
  {
    if (start < end)
    {
      int p = Partition(arr, start, end);

      QuickSort(arr, start, p - 1);
      QuickSort(arr, p + 1, end);
    }
  }

  private static int Partition(int[] arr, int low, int high)
  {
    //pivot is the low threshold
    //and low starts after the pivot
    int pivot = low;

    while (low < high)
    {
      //searching a low that is greater than the pivot
      //it stops if low cross high
      while (arr[low] < arr[pivot] && low < high)
      {
        low++;
      }
      //searching a high that is lesser than the pivot
      //it stops if high cross low
      while (arr[pivot] < arr[high] && low < high)
      {
        high--;
      }

      if (low < high)
      {
        (arr[low], arr[high]) = (arr[high], arr[low]);
      }
    }

    (arr[pivot], arr[high]) = (arr[high], arr[pivot]);
    return pivot;
  }

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

  public static void ShellSort(int[] arr, bool usar)
  {
    int i, j, k = 1;
    int TAM = arr.Length;

    // Calcula o intervalo inicial (gap)
    while (k < TAM / 3)
    {
      k = 3 * k + 1; // Exemplo: 1, 4, 13, 40, etc.
    }

    // Reduz o intervalo e ordena os subarrays
    while (k > 0)
    {
      // Ordena subarrays usando insertion sort com intervalo k
      for (i = k; i < TAM; i++)
      {
        int temp = arr[i];
        j = i;

        // Move elementos do subarray para a posição correta
        while (j >= k && arr[j - k] > temp)
        {
          arr[j] = arr[j - k];
          j -= k;
        }
        arr[j] = temp;
      }

      // Reduz o intervalo para a próxima iteração
      k = (k - 1) / 3;
    }
  }

  public static void StraightSort(int[] arr)
  {
    int smallest;
    int i, j;
    for (i = 0; i < arr.Length - 1; i++)
    {
      smallest = i;

      for (j = i + 1; j < arr.Length; j++)
      {
        if (arr[j] < arr[smallest])
        {
          smallest = j;
        }
      }
      (arr[smallest], arr[i]) = (arr[i], arr[smallest]);
    }
  }
}