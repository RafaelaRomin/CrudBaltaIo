using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CrudBaltaIo.Entities
{
    public class Assinatura
    {
        public int Id { get; set; }

        [DisplayName("Id do Aluno")]
        public int IdAluno { get; set; }

        [DisplayName("Data Cadastro")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        [DisplayName("Incío da Assinatura")]
        public DateTime Inicio { get; set; } 

        [DisplayName("Expira em")]
        public DateTime Termino { get; set; }

        [DisplayName("Assinatura expirada")]
        public bool? Expirada { get; set; } = false;

        public Aluno? Aluno { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
