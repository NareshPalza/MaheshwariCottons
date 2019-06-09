using MHCotton.Data.IRepositories;
using MHCotton.Data.IRepositories.Core;
using MHCotton.Data.Repositories;
using MHCotton.Data.Repositories.Core;
using MHCotton.Service;
using MHCotton.Service.IServices;
using MHCotton.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace MHCotton.Web.Common
{
    public class BootStrapper
    {
        private static IUnityContainer container;
        public static IUnityContainer Initialise()
        {
            container = new UnityContainer();
            BuildContainer(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static void BuildContainer(IUnityContainer container)
        {
            container.RegisterType<IUserService, UserService>();

            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmailService, EmailService>();
        }
    }
}