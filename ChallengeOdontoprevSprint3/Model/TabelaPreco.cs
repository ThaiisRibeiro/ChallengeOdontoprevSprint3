using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Tabela_Precos")]
    public class TabelaPreco
    {




        [Key]
        // public int id { get; set; }
        public int id_tabela_preco { get; set; }
        [Column("nome_procedimento ")]
        [Display(Name = "Nome do procedimento: ")]
        [Required(ErrorMessage = "Campo Nome do procedimento Obrigátorio", AllowEmptyStrings = false)]
        public string nome_procedimento { get; set; }


        [Column("valor ")]
        [Display(Name = "valor : ")]
        [Required(ErrorMessage = "Campo Valor Obrigátorio", AllowEmptyStrings = false)]
        public double valor { get; set; }

        [Column("descricao ")]
        [Display(Name = "descricao tabela paciente: ")]
        [Required(ErrorMessage = "Campo Descrição Obrigátorio", AllowEmptyStrings = false)]
        public string descricao { get; set; }
    }
}
