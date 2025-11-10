using AssettoServer.Server.Plugin;
using Autofac;

namespace ScrambleRacePlugin;

public class ScrambleRaceModule : AssettoServerModule<ScrambleRaceConfiguration>
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ScrambleRacePlugin>().AsSelf().As<IAssettoServerAutostart>().SingleInstance();
    }
}
