namespace teste.Models
{
    public class Adquirente
    {
        public decimal? Valor { get; set; }
        public string Nome { get; set; }

        public string Bandeira { get; set; }

        public string Tipo { get; set; }

        public List<Taxa> Taxas { get; set; }


    }

    public class Taxa
    {
        public string Bandeira { get; set; }

        public decimal Credito { get; set; }

        public decimal Debito { get; set; }
    }
}
