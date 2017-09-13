using Ninject;
using Ninject.Syntax;
using Projeto.Pizzaria.Dao.Data;
using Projeto.Pizzaria.Dao.Interface;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Projeto.Pizzaria.Web.App_Start
{
    public class IocConfig
    {
        public static void ConfigurarDependencias()
        {
            //Cria o Container 
            IKernel kernel = new StandardKernel();

            //Instrução para mapear a interface IPessoa para a classe concreta Pessoa
            kernel.Bind<IDaoCategoriaProduto>().To<DaoCategoriaProduto>();
            kernel.Bind<IDaoProduto>().To<DaoProduto>();

            //Registra o container no ASP.NET
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }

    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;

        public NinjectDependencyResolver(IResolutionRoot kernel)
        {
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);
        }
    }
}