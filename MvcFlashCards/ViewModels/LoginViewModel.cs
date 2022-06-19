using System.ComponentModel.DataAnnotations;

namespace MvcFlashCards.ViewModels
{
    public class LoginViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Usuário")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Nome do usuário precisa ter no mínimo 5 dígitos")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
