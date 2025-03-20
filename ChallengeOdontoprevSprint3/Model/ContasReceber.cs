using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Contas_Receber")]
    public class ContasReceber
    {


        [Key]
        // public int id { get; set; }
        public int id_conta_receber { get; set; }

        [Column("id_paciente ")]
        [Display(Name = "id_paciente : ")]
        public int id_paciente { get; set; }


        [Column("valor ")]
        [Display(Name = "valor  paciente: ")]
        [Required(ErrorMessage = "Campo Valor Obrigátorio", AllowEmptyStrings = false)]
        public double valor { get; set; }

        [Column("data_emissao ")]
        [Display(Name = "data_emissao : ")]
        [Required(ErrorMessage = "Campo Data de Emissao Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_emissao { get; set; }

        [Column("data_vencimento  ")]
        [Display(Name = "data_vencimento  : ")]
        [Required(ErrorMessage = "Campo Data de Vencimento Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_vencimento { get; set; }

    }
}
