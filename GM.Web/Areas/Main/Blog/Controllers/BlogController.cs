using GM.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GM.Web.Models;
using GM.Domain.Entities;
using GM.Web.Areas.Main.Blog.Models;

namespace GM.Web.Areas.Main.Blog.Controllers
{
    public class BlogController : Controller
    {
        private IBlogPostRepository m_blogPostRepository;

        public BlogController(IBlogPostRepository blogPostRepository) {
            this.m_blogPostRepository = blogPostRepository;
        }

        public ViewResult Index() {

            List<BlogPostViewer> blogPostViewers = new List<BlogPostViewer>();

            foreach (BlogPost blogPost in m_blogPostRepository.BlogPosts.OrderByDescending(bp => bp.Created)) {
                blogPostViewers.Add(new BlogPostViewer { BlogPost = blogPost });
            }

            BlogIndex model = new BlogIndex {
                BlogPostViewers = blogPostViewers
            };

            return View(model);
        }
    }
}
