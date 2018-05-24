using Autofac;

namespace ViewModels
{
    public class ViewModelsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();

            builder.RegisterInstance("My Run Time Title");
        }
    }
}