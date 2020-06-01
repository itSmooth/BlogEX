using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEX.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BlogEX.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RazorPageBlogContext _context;
        public IList<MyClass> Article { get; set; }

        public class MyClass
        {
            public Guid Id { get; set; }
            public string CoverPhoto { get; set; }
            public string Title { get; set; }
            public string Body { get; set; }
            public string Tags { get; set; }
            public DateTime CreateDate { get; set; }
        }

        public IndexModel(ILogger<IndexModel> logger, RazorPageBlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
            Article = _context.Articles.Select(d => 
                new MyClass
                    {
                        Id = d.Id,
                        CoverPhoto = d.CoverPhoto,
                        Title = d.Title,
                        Body = d.Body.Substring(0, 200),
                        CreateDate = d.CreateDate,
                        Tags = d.Tags
                    })
                .ToList();

        }
    }
}
