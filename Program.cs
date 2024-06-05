
for (int i = 10; i <= 100000; i*=10)
{
  int size = i;
  Test(size);
  string[] algorithms = [
    "Merge Sort ",
    "Bubble Sort",
    "Insertion  ",
    "Shell Sort ",
    "Selection  ",
    "Heap Sort  ",
    "Quick Sort "];
    CalculateMedia(algorithms, size);
}
