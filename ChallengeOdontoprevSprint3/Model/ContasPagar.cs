using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Contas_Pagar")]
    public class ContasPagar
    {




        [Key]
        // public int id { get; set; }
        public int id_conta_pagar { get; set; }

        [Column("id_clinica ")]
        [Display(Name = "id_clinica : ")]
        public int id_clinica { get; set; }


        [Column("valor ")]
        [Display(Name = "valor : ")]
        [Required(ErrorMessage = "Campo Valor Obrigátorio", AllowEmptyStrings = false)]
        public double valor { get; set; }

        [Column("data_emissao ")]
        [Display(Name = "data_emissao : ")]
        [Required(ErrorMessage = "Campo Data Emissao Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_emissao { get; set; }

        [Column("data_vencimento  ")]
        [Display(Name = "data_vencimento  : ")]
        [Required(ErrorMessage = "Campo Data Vencimento Obrigátorio", AllowEmptyStrings = false)]
        public DateTime data_vencimento { get; set; }



    }
}
