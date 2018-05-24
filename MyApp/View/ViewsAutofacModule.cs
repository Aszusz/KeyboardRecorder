using Autofac;

namespace Views
{
    public class ViewsAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainWindowView>();
        }
    }
}