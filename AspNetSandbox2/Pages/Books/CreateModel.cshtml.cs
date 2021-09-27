using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetSandbox2.Data;
using AspNetSandbox2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;

namespace AspNetSandbox2.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly AspNetSandbox2.Data.ApplicationDbContext context;
        private readonly IHubContext<MessageHub> hubContext;

        public CreateModel(AspNetSandbox2.Data.ApplicationDbContext context, IHubContext<MessageHub> hubContext)
        {
            this.context = context;
            this.hubContext = hubContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Book.Add(Book);
            await context.SaveChangesAsync();
            await hubContext.Clients.All.SendAsync("CreatedBook", Book);

            return RedirectToPage("./Index");
        }
    }
}
