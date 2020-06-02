using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogEX.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using X.PagedList;


namespace BlogEX.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RazorPageBlogContext _context;
        public IEnumerable<MyClass> Article { get; set; }


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

        public void OnGet(string q, int? p)
        {
            var pageIndex = p.HasValue ? p.Value < 1 ? 1 : p.Value : 1;
            var query = _context.Articles.AsQueryable();
            if (string.IsNullOrWhiteSpace(q) == false)
            {
                query = query.Where(d => d.Title.Contains(q));
            }
            Article = query.Select(d => 
                new MyClass
                    {
                        Id = d.Id,
                        CoverPhoto = d.CoverPhoto,
                        Title = d.Title,
                        Body = d.Body.Substring(0, 200),
                        CreateDate = d.CreateDate,
                        Tags = d.Tags
                    })
                .ToPagedList(pageIndex, 5);

        }

        public void OnGetTag(string tag, int? p)
        {
            //包含分頁與標籤的文章列表
            var pageIndex = p.HasValue ? p.Value < 1 ? 1 : p.Value : 1;
            var query = _context.Articles.AsQueryable();
            if (string.IsNullOrWhiteSpace(tag) == false)
            {
                query = query.Where(d => d.Tags.Contains(tag));
            }

            Article = query
                     .Select(d => new MyClass
                     {
                         Id = d.Id,
                         CoverPhoto = d.CoverPhoto,
                         Title = d.Title,
                         Body = d.Body.Substring(0, 200),
                         CreateDate = d.CreateDate,
                         Tags = d.Tags
                     })
                     .ToPagedList(pageIndex, 5);
        }
    }
}
