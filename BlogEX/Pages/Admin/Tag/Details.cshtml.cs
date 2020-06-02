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
    public class DetailsModel : PageModel
    {
        private readonly BlogEX.Data.RazorPageBlogContext _context;

        public DetailsModel(BlogEX.Data.RazorPageBlogContext context)
        {
            _context = context;
        }

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
    }
}
