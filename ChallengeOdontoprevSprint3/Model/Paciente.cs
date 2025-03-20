using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ChallengeOdontoprevSprint3.Model
{
    [Table("Api_Dotnet_Pacientes")]
    public class Paciente
    {


        [Key]
        // public int id { get; set; }
        public int id_paciente { get; set; }
        [Column("cpf_cnpj")]
        [Display(Name = "Cpf ou Cnpj paciente: ")]
        [Required(ErrorMessage = "Campo CPF ou CNPJ Obrigátorio", AllowEmptyStrings = false)]
        public string cpf_cnpj { get; set; }


        [Column("nome")]
        [Display(Name = "Nome paciente: ")]
        [Required(ErrorMessage = "Campo Nome Obrigátorio", AllowEmptyStrings = false)]
        public string nome { get; set; }
        [Column("endereco")]
        [Display(Name = "Endereco paciente: ")]
        [Required(ErrorMessage = "Campo Endereço Obrigátorio", AllowEmptyStrings = false)]
        public string endereco { get; set; }

        [Display(Name = "Telefone paciente: ")]
        [Required(ErrorMessage = "Campo Telefone Obrigátorio", AllowEmptyStrings = false)]
        public string telefone { get; set; }

        [Display(Name = "Email paciente: ")]
        [Required(ErrorMessage = "Campo email Obrigátorio", AllowEmptyStrings = false)]
        public string email { get; set; }


        [Display(Name = "Digite F ou J (fisico ou juridico): ")]
        [Required(ErrorMessage = "Campo Fisico ou Juridico Obrigátorio", AllowEmptyStrings = false)]
        public string tipo_paciente { get; set; }


        [Display(Name = "Senha paciente: ")]
        [Required(ErrorMessage = "Campo Senha Obrigátorio", AllowEmptyStrings = false)]
        public string senha { get; set; }
    }
}
