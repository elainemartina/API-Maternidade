namespace MaternidadeAPI.DBOs
{
    public class DTORN
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime Nascimento { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public string TipoParto { get; set; } = string.Empty;
        public int Apgar { get; set; }
        public string CondiçãoMedica { get; set; } = string.Empty;
    }
}
