namespace Commerce.Models
{
    public class OrdiniViewModel
    {
        int IdOrdine { get; set; }
        decimal Importo { get; set; }
        DateTime Data { get; set; }
        string Valuta { get; set; }
        string CodC8 { get; set; }
        int CodCliente { get; set; }
    }
}
