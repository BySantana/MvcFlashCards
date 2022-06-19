using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcFlashCards.Context;
using MvcFlashCards.Models;
using MvcFlashCards.Repositories;
using MvcFlashCards.Repositories.Interfaces;
using MvcFlashCards.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcFlashCards.Controllers
{
    public class FlashCardController : Controller
    {
        private readonly IFlashCardRepository _flashCardRepository;
        private readonly AppDbContext _context;

        public FlashCardController(IFlashCardRepository flashCardRepository, AppDbContext context)
        {
            _flashCardRepository = flashCardRepository;
            _context = context;
        }

        public IActionResult List(string searchString, string user)
        {

            var flashCard = _flashCardRepository.GetFlashCards(AccountController.UsuarioID);

            if (!string.IsNullOrEmpty(searchString))
            {
                flashCard = flashCard.Where(s => s.Categoria.ToLower().Contains(searchString.ToLower()));
            }

            return View(flashCard);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FlashCardId, MsgFrente, MsgVerso, Categoria")] FlashCard flashCard)
        {
            
            flashCard.UserId = AccountController.UsuarioID;
            if (flashCard.UserId != "")
            {
                if (ModelState.IsValid)
                {
                    _context.FlashCards.Add(flashCard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(List));
                }
                return View(flashCard); 
            }
            return RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashCard = await _context.FlashCards.FindAsync(id);
            if (flashCard == null)
            {
                return NotFound();
            }

            return View(flashCard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FlashCardId, MsgFrente, MsgVerso, Categoria")] FlashCard flashCard)
        {
            flashCard.UserId = AccountController.UsuarioID;

            if (id != flashCard.FlashCardId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flashCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                        return NotFound();
                }

                return RedirectToAction(nameof(List));
            }
           
            return View(flashCard);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashCard = await _context.FlashCards
                .FirstOrDefaultAsync(m => m.FlashCardId == id);
            if (flashCard == null)
            {
                return NotFound();
            }

            return View(flashCard);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var livro = await _context.FlashCards.FindAsync(id);
            _context.FlashCards.Remove(livro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

       
    }
}
