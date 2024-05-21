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

  public static void Merge(int[] arr, int inicio, int meio, int fim)
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

}