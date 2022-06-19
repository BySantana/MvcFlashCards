using MvcFlashCards.Models;
using System.Collections.Generic;

namespace MvcFlashCards.Repositories.Interfaces
{
    public interface IFlashCardRepository
    {
        IEnumerable<FlashCard> GetFlashCards(string usuarioId);
        IEnumerable<FlashCard> GetFlashCardsCategoria(int usuarioId, string categoria);
    }
}
