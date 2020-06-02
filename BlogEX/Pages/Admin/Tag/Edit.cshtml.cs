using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogEX.Data;

namespace BlogEX.Pages.Admin.Tag
{
    public class EditModel : PageModel
    {
        private readonly BlogEX.Data.RazorPageBlogContext _context;

        public EditModel(BlogEX.Data.RazorPageBlogContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TagCloud).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagCloudExists(TagCloud.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TagCloudExists(Guid id)
        {
            return _context.TagCloud.Any(e => e.Id == id);
        }
    }
}
