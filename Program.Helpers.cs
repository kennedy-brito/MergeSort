

partial class Program
{
  static void CalculateMedia(string[] algoritmos, int tamanho)
  {
    // WriteLine($"size: {size}");
    foreach (var algoritmo in algoritmos)
    {
      string[] pastas = ["Aleatorio", "Invertido", "Ordenado"];
      // Write($"{algorithm} - media:");
      var nomeArquivo = $"{algoritmo}";
      foreach (var pasta in pastas)
      {
        var path = $@"C:\Users\willi\source\repos\c#\SortMethods\Resultados\{pasta}\{nomeArquivo}_{tamanho}.txt";
        string mediaFilePath = $@"C:\Users\willi\source\repos\c#\SortMethods\Media\{pasta}\{nomeArquivo}.txt";

        var tempos = LerTemposDosArquivos(path);

        double media = CalcularMedia(tempos);
        var span = new TimeSpan(Convert.ToInt64(media));
        string tempoEmSegundos = span.ToString();

        using (StreamWriter sw = File.CreateText(mediaFilePath))
        {
          sw.WriteLine($"media de vetor de {tamanho} elementos: {tempoEmSegundos[6..]}");

        }
      }


    }
  }

  // Função para ler valores de um arquivo
  static List<double> LerTemposDosArquivos(string caminhoArquivo)
  {
    var tempos = new List<double>();

    try
    {
      foreach (var linha in File.ReadLines(caminhoArquivo))
      {
        if (double.TryParse(linha, out double tempo))
        {
          tempos.Add(tempo);
        }
      }
    }
    catch (Exception ex)
    {
      WriteLine($"Não foi possível ler o arquivo: {caminhoArquivo}. Erro: {ex.Message}");
    }

    return tempos;
  }

  // Função para calcular a média de uma lista de valores
  static double CalcularMedia(List<double> valores)
  {
    if (valores.Count == 0) return 0.0;

    double soma = valores.Sum();
    return soma / valores.Count;
  }

}