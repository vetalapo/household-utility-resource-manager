using System;
using System.Collections.Generic;

using Autofac;

using AutoMapper;

using HurManager.App.Common.Monads;

namespace HurManager.App.DI
{
    public class AutomapperModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .Register(context => new MapperConfiguration(cfg =>
                {
                    var profiles = context.Resolve<IEnumerable<Profile>>();
                    foreach (var profile in profiles)
                    {
                        cfg.AddProfile(profile);
                    }

                    cfg.ForAllMaps(
                        (map, exp) =>
                        {
                            var names = map.GetUnmappedPropertyNames();
                            Array.ForEach(
                                names,
                                name => exp.ForMember(name, o => o.Ignore()));
                        });

                    cfg.ForAllMaps((map, exp) => exp.MaxDepth(4));
                }).Do(x => x.CompileMappings()))
                .AsSelf()
                .SingleInstance();

            builder.Register(x => x.Resolve<MapperConfiguration>().CreateMapper())
                .As<IMapper>()
                .SingleInstance();
        }
    }
}
