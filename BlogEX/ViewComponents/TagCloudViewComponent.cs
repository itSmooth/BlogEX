using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEX.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogEX.ViewComponents
{
    public class TagCloudViewComponent: ViewComponent
    {
        private readonly RazorPageBlogContext _context;

        public TagCloudViewComponent(RazorPageBlogContext context)
        {
            _context = context;
        }


        public IViewComponentResult Invoke()
        {
            ViewData.Model = _context.TagCloud.ToDictionary(d => d.Name, d => d.Amount);
            return View();
        }
    }
}
