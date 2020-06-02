﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlogEX.Data;

namespace BlogEX.Pages.Admin.Article
{
    public class DetailsModel : PageModel
    {
        private readonly BlogEX.Data.RazorPageBlogContext _context;

        public DetailsModel(BlogEX.Data.RazorPageBlogContext context)
        {
            _context = context;
        }

        public Articles Articles { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Articles = await _context.Articles.FirstOrDefaultAsync(m => m.Id == id);

            if (Articles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
