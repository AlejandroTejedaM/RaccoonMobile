namespace RaccoonMobile.Models
{
    public class Fallo
    {
        public int id { get; set; }
        public String? usuario { get; set; }
        public DateTime fechaReporte { get; set; }
        public DateTime fechaResolucion { get; set; }
        public String? descripcion { get; set; }
        public Estado estado { get; set; }
        public Double PosicionLatitud { get; set; }
        public Double PosicionLongitud { get; set; }
        public String? dispositivo { get; set; }
        public String? tipoRed { get; set; }
    }
}