using System.ComponentModel.DataAnnotations;

namespace MaternidadeAPI.Models
{
    public class MãeModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; } = string.Empty;
        public DateTime Nascimento { get; set; }
        public string RG { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Endereço { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string EstadoCivil { get; set; } = string.Empty;
        public string Profissão { get; set; } = string.Empty;
        public string Etnia { get; set; } = string.Empty;
        public string HistoricoMedico { get; set; } = string.Empty;
       
    }
}
