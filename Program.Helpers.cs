using St = Sort.Sort;
using System.Diagnostics;

partial class Program
{
  static void CalculateMedia(string[] aglgorithms, int size)
  {
    // WriteLine($"size: {size}");
    foreach (var algorithm in aglgorithms)
    {
      string[] pastas = ["Aleatorio","Invertido","Ordenado"];
      // Write($"{algorithm} - media:");
      var filename = $"{algorithm}";
      foreach (var pasta in pastas)
      {
        var path = $@"C:\Users\willi\source\repos\c#\SortMethods\Resultados\{pasta}\{filename}_{size}.txt";
        string mediaFilePath = $@"C:\Users\willi\source\repos\c#\SortMethods\Media\{pasta}\{filename}.txt";
        
        var times = ReadTimesFromFile(path);

        double average = CalculateAverage(times);
        var span = new TimeSpan(Convert.ToInt64(average));
        string timeInSeconds = span.ToString();

        using (StreamWriter sw = File.AppendText(mediaFilePath))
        {
          sw.WriteLine($"media de vetor de {size} elementos: {timeInSeconds[6..]}");

        }
      }


    }
  }

  static void Test(int size)
  {

    int[] originalArray = GenerateRandomArray(size);

    WriteLine($"Size: {size:N}");
    // TestSortAlgorithm("Merge Sort ", originalArray, arr => St.MergeSort(arr), "Aleatorio");
    // TestSortAlgorithm("Bubble Sort", originalArray, arr => St.BubbleSort(arr), "Aleatorio");
    // TestSortAlgorithm("Insertion  ", originalArray, arr => St.InsertionSort(arr), "Aleatorio");
    // TestSortAlgorithm("Shell Sort ", originalArray, arr => St.ShellSort(arr), "Aleatorio");
    // TestSortAlgorithm("Selection  ", originalArray, arr => St.StraightSort(arr), "Aleatorio");
    // TestSortAlgorithm("Heap Sort  ", originalArray, arr => St.HeapSort(arr), "Aleatorio");
    // TestSortAlgorithm("Quick Sort ", originalArray, arr => St.QuickSort(arr, 0, arr.Length - 1), "Aleatorio");
    WriteLine();

    //teste de vetor ordenado
    originalArray = GenerateOrderedArray(size);
    TestSortAlgorithm("Merge Sort ", originalArray, arr => St.MergeSort(arr), "Ordenado");
    TestSortAlgorithm("Bubble Sort", originalArray, arr => St.BubbleSort(arr), "Ordenado");
    TestSortAlgorithm("Insertion  ", originalArray, arr => St.InsertionSort(arr), "Ordenado");
    TestSortAlgorithm("Shell Sort ", originalArray, arr => St.ShellSort(arr), "Ordenado");
    TestSortAlgorithm("Selection  ", originalArray, arr => St.StraightSort(arr), "Ordenado");
    TestSortAlgorithm("Heap Sort  ", originalArray, arr => St.HeapSort(arr), "Ordenado");
    TestSortAlgorithm("Quick Sort ", originalArray, arr => St.QuickSort(arr, 0, arr.Length - 1), "Ordenado");
    WriteLine();

    originalArray = GenerateInvertedArray(size);
    TestSortAlgorithm("Merge Sort ", originalArray, arr => St.MergeSort(arr), "Invertido");
    TestSortAlgorithm("Bubble Sort", originalArray, arr => St.BubbleSort(arr), "Invertido");
    TestSortAlgorithm("Insertion  ", originalArray, arr => St.InsertionSort(arr), "Invertido");
    TestSortAlgorithm("Shell Sort ", originalArray, arr => St.ShellSort(arr), "Invertido");
    TestSortAlgorithm("Selection  ", originalArray, arr => St.StraightSort(arr), "Invertido");
    TestSortAlgorithm("Heap Sort  ", originalArray, arr => St.HeapSort(arr), "Invertido");
    TestSortAlgorithm("Quick Sort ", originalArray, arr => St.QuickSort(arr, 0, arr.Length - 1), "Invertido");

  }
  static void TestSortAlgorithm(string algorithmName, int[] originalArray, Action<int[]> sortFunction, string tipo_vetor)
  {
    string resultado = "";
    var stopwatch = new Stopwatch();
    
    /*
    QuickSort gera Erro de StackOverflow para vetores ordenados e invertidos
    com tamanho de 100.000,00 items, seu resultado é 0 para
    indicar erro
    */
    if(
      algorithmName == "Quick Sort " 
      && originalArray.Length == 100000 
      && (tipo_vetor == "Invertido" || tipo_vetor == "Ordenado"))
    {
      resultado = "00000000";
      WriteResult(tipo_vetor, $"{algorithmName}_{originalArray.Length}", resultado);
      return;
    }


    // WriteLine(string.Join(" ", originalArray));
    int[] arrayToSort = new int[originalArray.Length];
    Array.Copy(originalArray, arrayToSort, originalArray.Length);

    stopwatch.Start();
    sortFunction(arrayToSort);
    stopwatch.Stop();
  
    resultado = stopwatch.Elapsed.ToString();
    
    WriteResult(tipo_vetor, $"{algorithmName}_{originalArray.Length}", resultado);
    WriteLine($"{algorithmName}: {resultado}");
  

    // Imprime o array ordenado para verificar a correção
    // WriteLine(string.Join(" ", arrayToSort));
  }


  static void WriteResult(string diretorio, string filename, string result)
  {
    var path = $@"C:\Users\willi\source\repos\c#\SortMethods\Resultados\{diretorio}\{filename}.txt";
    using (StreamWriter sw = File.AppendText(path))
    {
      sw.WriteLine(result[6..]);
    }
  }

  // Função para ler valores de um arquivo
  static List<double> ReadTimesFromFile(string filePath)
  {
    var times = new List<double>();

    try
    {
      foreach (var line in File.ReadLines(filePath))
      {
        if (double.TryParse(line, out double time))
        {
          times.Add(time);
        }
      }
    }
    catch (Exception ex)
    {
      WriteLine($"Não foi possível ler o arquivo: {filePath}. Erro: {ex.Message}");
    }

    return times;
  }

  // Função para calcular a média de uma lista de valores
  static double CalculateAverage(List<double> values)
  {
    if (values.Count == 0) return 0.0;

    double sum = values.Sum();
    return sum / values.Count;
  }
  static int[] GenerateRandomArray(int size)
  {
    var random = new Random();
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
      array[i] = random.Next(-10000, 10000);
    }
    return array;
  }
  static int[] GenerateOrderedArray(int size)
  {
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
      array[i] = i;
    }
    return array;
  }
  static int[] GenerateInvertedArray(int size)
  {
    int[] array = new int[size];
    for (int i = 0; i < size; i++)
    {
      array[i] = size - i;
    }
    return array;
  }

}