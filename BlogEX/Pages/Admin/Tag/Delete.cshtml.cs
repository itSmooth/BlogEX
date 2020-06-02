using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogEX.Data;

namespace BlogEX.Pages.Admin.Tag
{
    public class DeleteModel : PageModel
    {
        private readonly BlogEX.Data.RazorPageBlogContext _context;

        public DeleteModel(BlogEX.Data.RazorPageBlogContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TagCloud TagCloud { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TagCloud = await _context.TagCloud.FirstOrDefaultAsync(m => m.Id == id);

            if (TagCloud == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TagCloud = await _context.TagCloud.FindAsync(id);

            if (TagCloud != null)
            {
                _context.TagCloud.Remove(TagCloud);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
