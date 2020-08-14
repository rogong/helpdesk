using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CallogApp.Data;
using CallogApp.Models;
using CallogApp.Utility;

namespace CallogApp.Areas.User.Controllers
{
    [Area("User")]
    public class UserCommentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User/UserComment
        public async Task<IActionResult> Index()
        {
            return View(
                await _context.Comments

                .ToListAsync()
                );
        }

        // GET: User/UserComment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: User/UserComment/Create
        public IActionResult Create(int RequestId)
        {
            
           
            ViewBag.Id = RequestId;
            ViewBag.CreatedDate = DateTime.Now;
            return View();
        }

        // POST: User/UserComment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Content,UserId,CreatedDate")] Comment comment)
        {

            var UserId = User.Identity.Name;


            if (ModelState.IsValid)
            {
                comment.UserId = UserId;
                _context.Add(comment);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Success));
            }
            return View(comment);
        }

        // GET: User/UserComment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: User/UserComment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RequestId,UserId,Content,CreatedDate")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    comment.CreatedDate = DateTime.Now;
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Success));

            }
            return View(comment);
        }

        // GET: User/UserComment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: User/UserComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }

        public IActionResult Success()
        {
            return View();
        }

        public async Task<IActionResult> GetAllCommentsByRequest(int? id)
        {
            var UserId = User.Identity.Name;
            var lists = await _context.Comments
                .Where(c => c.Id == id && c.UserId == UserId)
                .ToListAsync();
            return View(lists);
          
        }
    }
}
