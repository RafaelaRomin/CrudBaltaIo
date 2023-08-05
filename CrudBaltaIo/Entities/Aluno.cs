using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudBaltaIo.Entities
{
    public class Aluno
    {
        public int Id { get; set; }

        [DisplayName("Nome Completo")]
        [Required(ErrorMessage ="Preenchimento obrigatório")]
        public string? NomeCompleto { get; set; }

        [DisplayName("CPF")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string? CpfAluno { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }
        public string? Telefone { get; set; }

        [NotMapped]
        public IFormFile? Imagem { get; set; }
        public string? ImagemBase64 { get; set; }
        public string? ImagemUrl { get; set; }
        public List<Assinatura>? Assinaturas { get; set; }
    }
}
