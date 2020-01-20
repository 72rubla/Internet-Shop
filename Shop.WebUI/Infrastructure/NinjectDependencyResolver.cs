using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Ninject;
using Moq;
using System.Web.Mvc;
using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using Shop.Domain.Concrete;
using Shop.WebUI.Infrastructure.Abstract;
using Shop.WebUI.Infrastructure.Concrete;

namespace Shop.WebUI.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            // Здесь размещаются привязки
            //Mock<IWareRepository> mock = new Mock<IWareRepository>();
            //mock.Setup(m => m.Wares).Returns(new List<Ware>
            //{

            //    new Ware {Name="11", Description="12", Category="13",Price=14},
            //    new Ware {Name="21", Description="22", Category="23",Price=14},
            //    new Ware {Name="31", Description="32", Category="33",Price=14},
            //});
            //kernel.Bind<IWareRepository>().ToConstant(mock.Object);
            //kernel.Bind<IWareRepository>().To<EFWareRepository>();

            kernel.Bind<IUserRepository>().To<EFUserRepository>();

            kernel.Bind<IWareRepository>().To<EFWareRepository>();

            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();

            kernel.Bind<IOrderWaresRepository>().To<EFOrderWaresRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager
                    .AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>()
                .WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IAuthProvider>().To<FormAuthProvider>();           
        }
    }
}