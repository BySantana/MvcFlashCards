using Microsoft.EntityFrameworkCore;
using MvcFlashCards.Context;
using MvcFlashCards.Models;
using MvcFlashCards.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MvcFlashCards.Repositories
{
    public class FlashCardRepository : IFlashCardRepository
    {
        private readonly AppDbContext _context;

        public FlashCardRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FlashCard> GetFlashCards(string usuario)
        {
            return _context.FlashCards.Where(w => w.User.Id == usuario); 
        }


        public IEnumerable<FlashCard> GetFlashCardsCategoria(int usuarioId, string categoria)
        {
            return _context.FlashCards;
        }
    }
}
