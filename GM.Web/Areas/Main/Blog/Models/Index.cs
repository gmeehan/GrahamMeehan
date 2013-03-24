using System.Collections.Generic;
using GM.Domain.Entities;
using System.Collections;

namespace GM.Web.Areas.Main.Blog.Models {
    public class BlogIndex {

        public IEnumerable<BlogPostViewer> BlogPostViewers { get; set; }
    }
}