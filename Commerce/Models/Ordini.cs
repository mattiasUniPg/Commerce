namespace Commerce.Models
{
    public class Ordini
    {
        int IdOrdine { get; set; }
        float Importo { get; set; }
        DateTime Data { get; set; }
        string Valuta { get; set; }
        string CodC8 { get; set; }
        int CodCliente { get; set; }
    }
}
