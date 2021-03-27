using Autofac;

using AutoMapper;

using HurManager.Core.Services.Session;
using HurManager.Dal.Context;
using HurManager.Dal.Mapping;

namespace HurManager.Dal.DI
{
    public class DalModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Assembly types
            builder.RegisterAssemblyTypes(this.ThisAssembly).AsImplementedInterfaces();

            // Mapper maps
            builder.RegisterType<DalMappingProfile>().As<Profile>();

            // DB context
            builder.RegisterType<HurManagerContext>().AsSelf();

            // Session and its provider
            builder.RegisterType<SessionProvider>().As<ISessionProvider>().InstancePerLifetimeScope();
            builder.Register(ctx => ctx.Resolve<ISessionProvider>().CurrentSession).As<ISession>();
        }
    }
}
