using System;
using System.Web.Mvc;
using System.Web.Routing;
using GM.Domain.Concrete;
using GM.Domain.Abstract;
using Ninject;
using Moq;
using GM.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GM.Web.Infrastructure {

    public class NinjectControllerFactory : DefaultControllerFactory {

        private IKernel ninjectKernel;

        public NinjectControllerFactory() {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType) {
            return controllerType == null
                ? null
                : ( IController )ninjectKernel.Get(controllerType);
        }

        private void AddBindings() {
            //put bindings here


            /*
            //CREATE TEST WHERE DATABASE IS NOT USED
            Mock <IBlogPostRepository> mock = new Mock<IBlogPostRepository>();
            mock.Setup(m => m.BlogPosts).Returns(new List<BlogPost> {
                new BlogPost { 
                    Id = 1, 
                    Title = "This Is Blog Post 1", 
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vestibulum augue non justo aliquam venenatis. Donec quis ante mi, ut facilisis nulla. Praesent sit amet gravida sapien. Morbi mauris lacus, bibendum pharetra ullamcorper vitae, egestas vel lorem. Aliquam eu odio leo. Integer et massa id neque pharetra aliquet ac eu tellus. Sed mattis, lorem sed iaculis auctor, tellus nisi sodales massa, eget pharetra ante mi non risus. Nunc faucibus lectus id justo porta id rutrum dui cursus. Cras magna nulla, laoreet in iaculis sit amet, pulvinar placerat mauris. Nunc malesuada ullamcorper laoreet. Aliquam venenatis adipiscing hendrerit. Pellentesque id arcu sapien.<br /><br />Mauris aliquet, nunc sit amet pellentesque tristique, sapien purus ultrices diam, et rutrum purus est vitae lacus. In hac habitasse platea dictumst. Sed non mauris tortor, id porta risus. Phasellus varius, est ut mattis porttitor, sem tellus faucibus sem, et malesuada neque lectus ut ipsum. Etiam vel sem leo. Donec vitae tincidunt orci. Phasellus sollicitudin tellus non nibh tempus ornare. Ut sagittis, erat a eleifend sagittis, purus odio rhoncus est, sit amet suscipit eros erat mollis orci. Mauris nec massa id nunc bibendum ullamcorper quis vitae mauris. Phasellus pulvinar suscipit dapibus. Donec erat purus, egestas non imperdiet posuere, feugiat et urna. Quisque quis ligula ullamcorper dui euismod rhoncus sit amet at lorem. Nam bibendum aliquam enim, nec tristique ante mattis porttitor. Maecenas imperdiet mollis faucibus.",
                    Created = DateTime.Now.AddDays(-10),
                    Modified = DateTime.Now.AddDays(-10)
                },
                new BlogPost { 
                    Id = 2, 
                    Title = "This Is Blog Post 2", 
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vestibulum augue non justo aliquam venenatis. Donec quis ante mi, ut facilisis nulla. Praesent sit amet gravida sapien. Morbi mauris lacus, bibendum pharetra ullamcorper vitae, egestas vel lorem. Aliquam eu odio leo. Integer et massa id neque pharetra aliquet ac eu tellus. Sed mattis, lorem sed iaculis auctor, tellus nisi sodales massa, eget pharetra ante mi non risus. Nunc faucibus lectus id justo porta id rutrum dui cursus. Cras magna nulla, laoreet in iaculis sit amet, pulvinar placerat mauris. Nunc malesuada ullamcorper laoreet. Aliquam venenatis adipiscing hendrerit. Pellentesque id arcu sapien.<br /><br />Mauris aliquet, nunc sit amet pellentesque tristique, sapien purus ultrices diam, et rutrum purus est vitae lacus. In hac habitasse platea dictumst. Sed non mauris tortor, id porta risus. Phasellus varius, est ut mattis porttitor, sem tellus faucibus sem, et malesuada neque lectus ut ipsum. Etiam vel sem leo. Donec vitae tincidunt orci. Phasellus sollicitudin tellus non nibh tempus ornare. Ut sagittis, erat a eleifend sagittis, purus odio rhoncus est, sit amet suscipit eros erat mollis orci. Mauris nec massa id nunc bibendum ullamcorper quis vitae mauris. Phasellus pulvinar suscipit dapibus. Donec erat purus, egestas non imperdiet posuere, feugiat et urna. Quisque quis ligula ullamcorper dui euismod rhoncus sit amet at lorem. Nam bibendum aliquam enim, nec tristique ante mattis porttitor. Maecenas imperdiet mollis faucibus.",
                    Created = DateTime.Now.AddDays(-5),
                    Modified = DateTime.Now.AddDays(-5)
                },
                new BlogPost { 
                    Id = 3, 
                    Title = "This Is Blog Post 3", 
                    Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Ut vestibulum augue non justo aliquam venenatis. Donec quis ante mi, ut facilisis nulla. Praesent sit amet gravida sapien. Morbi mauris lacus, bibendum pharetra ullamcorper vitae, egestas vel lorem. Aliquam eu odio leo. Integer et massa id neque pharetra aliquet ac eu tellus. Sed mattis, lorem sed iaculis auctor, tellus nisi sodales massa, eget pharetra ante mi non risus. Nunc faucibus lectus id justo porta id rutrum dui cursus. Cras magna nulla, laoreet in iaculis sit amet, pulvinar placerat mauris. Nunc malesuada ullamcorper laoreet. Aliquam venenatis adipiscing hendrerit. Pellentesque id arcu sapien.<br /><br />Mauris aliquet, nunc sit amet pellentesque tristique, sapien purus ultrices diam, et rutrum purus est vitae lacus. In hac habitasse platea dictumst. Sed non mauris tortor, id porta risus. Phasellus varius, est ut mattis porttitor, sem tellus faucibus sem, et malesuada neque lectus ut ipsum. Etiam vel sem leo. Donec vitae tincidunt orci. Phasellus sollicitudin tellus non nibh tempus ornare. Ut sagittis, erat a eleifend sagittis, purus odio rhoncus est, sit amet suscipit eros erat mollis orci. Mauris nec massa id nunc bibendum ullamcorper quis vitae mauris. Phasellus pulvinar suscipit dapibus. Donec erat purus, egestas non imperdiet posuere, feugiat et urna. Quisque quis ligula ullamcorper dui euismod rhoncus sit amet at lorem. Nam bibendum aliquam enim, nec tristique ante mattis porttitor. Maecenas imperdiet mollis faucibus.",
                    Created = DateTime.Now,
                    Modified = DateTime.Now
                },
            }.AsQueryable());

            ninjectKernel.Bind<IBlogPostRepository>().ToConstant(mock.Object);
            */

            //USE ACTUAL DATABASE
            ninjectKernel.Bind<IBlogPostRepository>().To<EFBlogPostRepository>();

        }

    }
}