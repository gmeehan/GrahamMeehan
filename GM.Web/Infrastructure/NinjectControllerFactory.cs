using System;
using System.Web.Mvc;
using System.Web.Routing;
using GM.Domain.Concrete;
using GM.Domain.Abstract;
using Ninject;

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

            ninjectKernel.Bind<IBlogPostRepository>().To<EFBlogPostRepository>();

        }

    }
}