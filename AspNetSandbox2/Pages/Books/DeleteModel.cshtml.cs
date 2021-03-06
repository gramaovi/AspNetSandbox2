using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace AspNetSandbox2.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly AspNetSandbox2.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;

        public DeleteModel(AspNetSandbox2.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await context.Book.FindAsync(id);

            if (Book != null)
            {
                context.Book.Remove(Book);
                await context.SaveChangesAsync();
                await hubContext.Clients.All.SendAsync("DeletedBook", Book);
            }

            return RedirectToPage("./Index");
        }
    }
}
