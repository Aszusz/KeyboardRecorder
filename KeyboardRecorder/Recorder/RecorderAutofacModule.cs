using Autofac;
using KeyboardAPI.APIs;

namespace Recorder
{
    public class RecorderAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Keyboard>().As<IKeyboard>().SingleInstance();
            builder.RegisterType<KeyCombinationListener>().SingleInstance();
        }
    }
}