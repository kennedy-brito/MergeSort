namespace Sort;

public static partial class Sort
{

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
  private static void Heapify(int[] arr, int tamanho, int raiz)
  {
    int maior = raiz;
    int filhoEsq = 2 * raiz + 1;
    int filhoDir = 2 * raiz + 2;

    while (true)
    {
      // Se o filho da esquerda é maior que a raiz
      if (filhoEsq < tamanho && arr[filhoEsq] > arr[maior])
      {
        maior = filhoEsq;
      }

      // Se o filho da direita é maior que o maior até agora
      if (filhoDir < tamanho && arr[filhoDir] > arr[maior])
      {
        maior = filhoDir;
      }

      // Se o maior não é a raiz, troca os elementos e continua
      if (maior != raiz)
      {
        (arr[raiz], arr[maior]) = (arr[maior], arr[raiz]);

        // Atualiza o índice da raiz e os filhos
        raiz = maior;
        filhoEsq = 2 * raiz + 1;
        filhoDir = 2 * raiz + 2;
      }
      else
      {
        break;
      }
    }
  }

}