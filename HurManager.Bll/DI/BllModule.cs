using Autofac;

namespace HurManager.Bll.DI
{
    public class BllModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(this.ThisAssembly).AsImplementedInterfaces();
        }
    }
}
