using System.Collections.Concurrent;
using System.Reflection.Metadata;

namespace Sort;

public static class Sort
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
  public static void MergeSort(int[] arr)
  {
    int[] aux = new int[arr.Length];
    MergeSort(arr, aux);
  }

  public static void MergeSort(int[] arr, int[] aux, int inicio = 0, int fim = -1)
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

  public static void QuickSort(int[] arr, int start, int end)
  {
    if (start < end)
    {
      int p = Partition(arr, start, end);

      QuickSort(arr, start, p - 1);
      QuickSort(arr, p + 1, end);
    }
  }

  private static int Partition(int[] a, int limInf, int limSup)
  {
    int pivo, temp;
    int baixo, alto;
    
    pivo = a[limInf]; 
    alto = limSup;
    baixo = limInf; 
    while (baixo<alto){
      while (a[baixo] <= pivo && baixo < limSup)
      {
        baixo++; // Sobe no arquivo.
      }
      while (a[alto] >= pivo && alto > limInf)
      {
        alto--; // Desce no arquivo. 
      }
      if (baixo < alto)
      { // Troca.
        temp = a[baixo];
        a[baixo] = a[alto]; 
        a[alto] = temp;
      }
    } 
    a[limInf] = a[alto]; 
    a[alto] = pivo;
    return alto;
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

public static void HeapSort(int[] arr)
{
  int n = arr.Length;

  // Constrói o heap inicial
  for (int i = n / 2 - 1; i >= 0; i--)
  {
    Heapify(arr, n, i);
  }

  // Extrai elementos do heap, um por um, e ajusta o heap restante
  for (int i = n - 1; i > 0; i--)
  {
    // Move a raiz atual (o maior elemento) para o final
    (arr[0], arr[i]) = (arr[i], arr[0]);

    // Chama o heapify no heap reduzido
    Heapify(arr, i, 0);
  }
}

// Função para transformar um subarray em um heap
private static void Heapify(int[] arr, int heapSize, int rootIndex)
{
  int largest = rootIndex;
  int leftChild = 2 * rootIndex + 1;
  int rightChild = 2 * rootIndex + 2;

  while (true)
  {
    // Se o filho da esquerda é maior que a raiz
    if (leftChild < heapSize && arr[leftChild] > arr[largest])
    {
      largest = leftChild;
    }

    // Se o filho da direita é maior que o maior até agora
    if (rightChild < heapSize && arr[rightChild] > arr[largest])
    {
      largest = rightChild;
    }

    // Se o maior não é a raiz, troca os elementos e continua
    if (largest != rootIndex)
    {
      (arr[rootIndex], arr[largest]) = (arr[largest], arr[rootIndex]);

      // Atualiza o índice da raiz e os filhos
      rootIndex = largest;
      leftChild = 2 * rootIndex + 1;
      rightChild = 2 * rootIndex + 2;
    }
    else
    {
      break;
    }
  }
}

}