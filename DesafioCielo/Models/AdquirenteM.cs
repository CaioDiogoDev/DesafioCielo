namespace DesafioCielo.Models
{
    #region Adquirente Model
    public class AdquirenteM
    {
        public string Adquirente { get; set; }
        public List<Taxa> Taxas { get; set; }
    }
    #endregion

    #region Taxa Model
    public class Taxa
    {
        public string Bandeira { get; set; }
        public decimal Credito { get; set; }
        public decimal Debito { get; set; }
    }
    #endregion
}
