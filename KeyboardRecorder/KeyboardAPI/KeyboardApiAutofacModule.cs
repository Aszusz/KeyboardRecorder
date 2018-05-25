using Autofac;
using AutoMapper;
using KeyboardAPI.APIs;

namespace KeyboardAPI
{
    public class KeyboardApiAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<Keyboard>()
                .As<IKeyboard>()
                .SingleInstance();

            builder
                .RegisterInstance(Mapping.GetConfiguredMapper())
                .As<IMapper>()
                .SingleInstance();
        }
    }
}