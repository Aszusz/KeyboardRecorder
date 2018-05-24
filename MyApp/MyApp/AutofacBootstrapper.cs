using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using Autofac;
using Caliburn.Micro;
using ViewModels;
using Views;

namespace Infrastructure
{
    public class AutofacBootstrapper : BootstrapperBase
    {
        private IContainer _container;

        public AutofacBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WindowManager>().As<IWindowManager>().SingleInstance();
            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterAssemblyModules(typeof(ViewModelsAutofacModule).Assembly);
            builder.RegisterAssemblyModules(typeof(ViewsAutofacModule).Assembly);

            _container = builder.Build();
        }

        protected override object GetInstance(Type service, string key)
        {
            return key == null
                ? _container.Resolve(service)
                : _container.ResolveNamed(key, service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            var collectionType = typeof(IEnumerable<>).MakeGenericType(service);
            return (IEnumerable<object>) _container.Resolve(collectionType);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainWindowViewModel>();
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[]
            {
                typeof(ViewModelsAutofacModule).Assembly,
                typeof(ViewsAutofacModule).Assembly
            };
        }
    }
}