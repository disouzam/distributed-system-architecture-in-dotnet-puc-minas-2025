using System.ComponentModel.DataAnnotations;

namespace RotativoO9.Entities
{
    public class Cadastro
    {
        [Key]
        public Guid Id { get; set; }

        [StringLength(250)]
        public string Nome { get; set; }

        public TipoCadastroEnum Tipo { get; set; }//teste

        [Range(1, 99)]
        public int Quantidade { get; set; }
    }

    public class FilhoCadastro : Cadastro
    {
        [StringLength(500)]
        public string DetalheAdicional { get; set; }
    }

    public enum TipoCadastroEnum
    {
        Cliente = 1,
        Fornecedor = 2,
        Transportadora = 3
    }
}
