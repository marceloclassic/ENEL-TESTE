using Teste.Domain.Interfaces;

namespace Teste.Domain.Services;
public class CalculadoraService : ICalculadoraService
{
    private readonly decimal _taxa;
    public CalculadoraService()
    {
        _taxa = 1.1M;
    }

    public void AplicarTaxa(List<decimal> values)
    {
        for (int i = 0; i < values.Count; i++)
            values[i] *= _taxa;
    }
}