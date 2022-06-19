using MvcFlashCards.Models;
using System.Collections.Generic;

namespace MvcFlashCards.ViewModels
{
    public class FlashCardListViewModel
    {
        public IEnumerable<FlashCard> FlashCards { get; set; }
        public string CategoriaAtual { get; set; }
        public string MsgFrente { get; set; }
        public string MsgVerso { get; set; }
    }
}
