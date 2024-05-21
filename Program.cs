using System.Diagnostics;
using S = Sort.Sort;
int size = 10;

int[] a = new int[size];
var dice = new Random();
var stopwatch = new Stopwatch();

for (int i = 0; i < size; i++)
{
  a[i] = dice.Next(-1000, 1000);
}

int[] b = new int[a.Length];
Array.Copy(a, b, a.Length);

int[] c = new int[a.Length];
Array.Copy(a, c, a.Length);

stopwatch.Start();
S.MergeSort(a);
stopwatch.Stop();

Console.WriteLine("Merge Sort: \t" + stopwatch.Elapsed);

stopwatch.Start();
S.BubbleSort(b);
stopwatch.Stop();
Console.WriteLine("Bubble Sort: \t" + stopwatch.Elapsed);

Console.WriteLine();
