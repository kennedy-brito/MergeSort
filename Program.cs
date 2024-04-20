

int[] unordered = [5, 4, 3, 2, 1, 25];

int[] ordered = MergeSort(unordered);

foreach (var item in ordered)
{
  Console.WriteLine(item);
}

static int[] MergeSort(int[] array)
{
  int length = array.Length;
  if (length <= 1) return array;

  int[] left = array[0..(length/2)];
  int[] right = array[(length/2 )..];
  
  left = MergeSort(left);
  right = MergeSort(right);

  return Interpolate(left, right);

}

static int[] Interpolate(int[] left, int[] right)
{
  int[] ordered = new int[left.Length + right.Length];
  int currentIndex = 0;

  int itemL = 0;
  int itemR = 0;

  while (itemL < left.Length && itemR < right.Length)
  {
    if (left[itemL] < right[itemR])
    {
      ordered[currentIndex++] = left[itemL++];
    }
    else
    {
      ordered[currentIndex++] = right[itemR++];
    }
  }

  while (itemL < left.Length)
  {
    ordered[currentIndex++] = left[itemL++];
  }
  while (itemR < right.Length)
  {
    ordered[currentIndex++] = right[itemR++];
  }

  return ordered;
}
