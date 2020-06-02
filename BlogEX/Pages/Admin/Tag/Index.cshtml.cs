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
    public class IndexModel : PageModel
    {
        private readonly BlogEX.Data.RazorPageBlogContext _context;

        public IndexModel(BlogEX.Data.RazorPageBlogContext context)
        {
            _context = context;
        }

        public IList<TagCloud> TagCloud { get;set; }

        public async Task OnGetAsync()
        {
            TagCloud = await _context.TagCloud.ToListAsync();
        }
    }
}
