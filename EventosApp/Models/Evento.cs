// ReSharper disable IdentifierTypo
namespace EventosApp.Models;

public class Evento
{
    // Guarda o local selecionado
    public Local? LocalSel { get; set; }
    
    // Guarda o nome do evento
    public required String EventName { get; set; }
    
    // Guarda a quantidade de pessoas que participarão do evento
    public int NumPessoas { get; set; }
    
    // Data de início e fim do evento
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    // Retorna o valor da duração do evento
    public int Duracao => DataFim.Subtract(DataInicio).Days;

    /**
     * Retorna o valor total a ser pago.
     * Multiplica o número de pessoas com um valor específico;
     * Multiplica o valor obtido pela quantidade de dias,
     * e soma com o valor de cada local
     */
    public double Total {
        get
        {
            // O valor por pessoa nesse caso seria 5 reais
            double valPessoa = NumPessoas * 5;
            double total = valPessoa * Duracao + LocalSel!.Preco;
            return total;
        }
    }
}