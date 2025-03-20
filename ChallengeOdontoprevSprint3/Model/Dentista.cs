using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Dentistas")]
    public class Dentista
    {



        [Key]
        // public int id { get; set; }
        public int id_dentista { get; set; }
        [Column("cpf_cnpj")]

        [Display(Name = "Cpf dentista: ")]
        [Required(ErrorMessage = "Campo CPF Obrigátorio", AllowEmptyStrings = false)]
        public string cpf { get; set; }

        [Display(Name = "numero_cro  dentista: ")]
        [Required(ErrorMessage = "Campo numero CRO Obrigátorio", AllowEmptyStrings = false)]
        public string numero_cro { get; set; }



        [Column("nome")]
        [Display(Name = "Nome dentista: ")]
        [Required(ErrorMessage = "Campo Nome Obrigátorio", AllowEmptyStrings = false)]
        public string nome { get; set; }

        [Column("telefone ")]

        [Display(Name = "telefone dentista: ")]
        [Required(ErrorMessage = "Campo Telefone Obrigátorio", AllowEmptyStrings = false)]
        public string telefone { get; set; }

        [Column("email  ")]
        [Display(Name = "email  dentista: ")]
        [Required(ErrorMessage = "Campo Email Obrigátorio", AllowEmptyStrings = false)]
        public string email { get; set; }


    }
}
