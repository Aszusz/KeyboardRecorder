using Autofac;
using KeyboardAPI.APIs;

namespace ViewModels
{
    public class ViewModelsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowViewModel>();

            builder.RegisterType<Keyboard>()
                .As<IKeyboard>()
                .SingleInstance();

            builder.RegisterInstance("My Run Time Title");
        }
    }
}