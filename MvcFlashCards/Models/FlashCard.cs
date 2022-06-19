using Microsoft.AspNetCore.Identity;
using MvcFlashCards.Migrations;
using System.ComponentModel.DataAnnotations;

namespace MvcFlashCards.Models
{
    public class FlashCard
    {
        public int FlashCardId { get; set; }

        [Required(ErrorMessage = "O campo Questão está vazio")]
        [Display(Name = "Questão")]
        public string MsgFrente { get; set; }

        [Required(ErrorMessage = "O campo Resposta está vazio")]
        [Display(Name = "Resposta")]
        public string MsgVerso { get; set; }

        [Required(ErrorMessage = "O campo Categoria está vazio")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }
    }
}
