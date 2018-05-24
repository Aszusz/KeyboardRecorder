using System;
using System.Collections.Generic;
using System.Windows;
using Autofac;
using Caliburn.Micro;

namespace MyApp
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

            builder.RegisterType<MainWindowViewModel>().SingleInstance();
            builder.RegisterType<MainWindowView>().SingleInstance();

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

        //        typeof(ViewModule).Assembly
        //        typeof(ViewModelModule).Assembly,
        //    {
        //    return new[]
        //{

        //protected override IEnumerable<Assembly> SelectAssemblies()
        //    };
        //}
    }
}