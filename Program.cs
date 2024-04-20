using System.Diagnostics;

int size = 70000000;

int[] unordered = new int[size];
var dice = new Random();
var stopwatch = new Stopwatch();

for (int i = 0; i < size; i++)
{
  unordered[i] = dice.Next(-1000,1000);
}
stopwatch.Start();
int[] ordered = MergeSort(unordered);
stopwatch.Stop();

Console.WriteLine(stopwatch.Elapsed);
Console.WriteLine("Press a key to continue");
Console.ReadKey();

// foreach (var item in ordered)
// {
//   Console.WriteLine(item);
// }

static int[] MergeSort(int[] array)
{
  int length = array.Length;
  if (length <= 1) 
    return array;

  int[] left = array[0..(length/2)];
  int[] right = array[(length/2 )..];
  
  left = MergeSort(left);
  right = MergeSort(right);

  return Interpolate(left, right);

}


/*
merge the two arrays, left and right
the elements are added in ascending order
*/
static int[] Interpolate(int[] left, int[] right)
{
  List<int> ordered = [];

  int leftIndex = 0;
  int rightIndex = 0;

  while (leftIndex < left.Length && rightIndex < right.Length)
  {
    if (left[leftIndex] < right[rightIndex])
    {
      ordered.Add(left[leftIndex++]);
    }
    else
    {
      ordered.Add(right[rightIndex++]);
    }
  }

  if (leftIndex < left.Length)
  {
    ordered.AddRange(left[leftIndex..]);
  }
  if (rightIndex < right.Length)
  {
    ordered.AddRange(right[rightIndex..]);
  }

  //return the list as an array
  return [.. ordered];
}
