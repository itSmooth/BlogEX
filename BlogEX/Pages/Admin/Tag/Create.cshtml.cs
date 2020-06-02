using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BlogEX.Data;

namespace BlogEX.Pages.Admin.Tag
{
    public class CreateModel : PageModel
    {
        private readonly BlogEX.Data.RazorPageBlogContext _context;

        public CreateModel(BlogEX.Data.RazorPageBlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TagCloud TagCloud { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.TagCloud.Add(TagCloud);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
