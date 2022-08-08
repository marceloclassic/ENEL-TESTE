namespace Teste.Domain.Interfaces;
public interface ICsvService
{
    void ReadColumn(string pathFile, int indexColumn);
    void ReadColumn(string pathFile, char letter);
    void GenerateCsv(List<decimal> values, string filename);
}