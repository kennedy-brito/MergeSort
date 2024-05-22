
using System.Diagnostics;
using St = Sort.Sort;

for (int i = 500; i <= 1000000; i*=10)
{
  int size = i;
  int[] originalArray = GenerateRandomArray(size);

  WriteLine($"Size: {size:N}");
  TestSortAlgorithm("Merge Sort ", originalArray, arr => St.MergeSort(arr));
  TestSortAlgorithm("Bubble Sort", originalArray, arr => St.BubbleSort(arr));
  TestSortAlgorithm("Insertion  ", originalArray, arr => St.InsertionSort(arr));
  TestSortAlgorithm("Shell Sort ", originalArray, arr => St.ShellSort(arr));
  TestSortAlgorithm("Selection  ", originalArray, arr => St.StraightSort(arr));
  TestSortAlgorithm("Heap Sort  ", originalArray, arr => St.HeapSort(arr));
  TestSortAlgorithm("Quick Sort ", originalArray, arr => St.QuickSort(arr, 0, arr.Length - 1));
  WriteLine();
}

static void TestSortAlgorithm(string algorithmName, int[] originalArray, Action<int[]> sortFunction)
{
  int[] arrayToSort = new int[originalArray.Length];
  Array.Copy(originalArray, arrayToSort, originalArray.Length);

  var stopwatch = new Stopwatch();
  stopwatch.Start();

  sortFunction(arrayToSort);

  stopwatch.Stop();
  WriteLine($"{algorithmName}: {stopwatch.Elapsed}");
  // Imprime o array ordenado para verificar a correção
  // WriteLine(string.Join(" ", arrayToSort));
}

static int[] GenerateRandomArray(int size)
{
  var random = new Random();
  int[] array = new int[size];
  for (int i = 0; i < size; i++)
  {
    array[i] = random.Next(0, 2000);
  }
  return array;
}

