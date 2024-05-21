using System.Diagnostics;
using S = Sort.Sort;
int size = 10;

int[] a = new int[size];
var dice = new Random();
var stopwatch = new Stopwatch();

for (int i = 0; i < size; i++)
{
  a[i] = dice.Next(0, 2000);
}

// int[] b = new int[a.Length];
// Array.Copy(a, b, a.Length);

// int[] c = new int[a.Length];
// Array.Copy(a, c, a.Length);

// int[] d = new int[a.Length];
// Array.Copy(a, d, a.Length);

// int[] e = new int[a.Length];
// Array.Copy(a, e, a.Length);

int[] f = new int[a.Length];
Array.Copy(a, f, a.Length);

// stopwatch.Start();
// S.MergeSort(a);
// stopwatch.Stop();

// WriteLine("Merge Sort: \t" + stopwatch.Elapsed);

// stopwatch.Start();
// S.BubbleSort(b);
// stopwatch.Stop();
// WriteLine("Bubble Sort: \t" + stopwatch.Elapsed);

// stopwatch.Start();
// S.QuickSort(c, 0, c.Length - 1);
// stopwatch.Stop();
// WriteLine("Quick Sort: \t" + stopwatch.Elapsed);


// stopwatch.Start();
// S.InsertionSort(d);
// stopwatch.Stop();
// WriteLine("Insertion Sort: \t" + stopwatch.Elapsed);

// stopwatch.Start();
// S.ShellSort(e);
// stopwatch.Stop();
// WriteLine("Shell Sort: \t" + stopwatch.Elapsed);

stopwatch.Start();
S.StraightSort(f);
stopwatch.Stop();
WriteLine("Selection Sort: \t" + stopwatch.Elapsed);

foreach (var i in f)
{
  Write(i + " ");
}
WriteLine();
