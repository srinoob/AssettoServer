using AssettoServer.Server.Configuration;
using JetBrains.Annotations;

namespace ScrambleRacePlugin;

[UsedImplicitly(ImplicitUseKindFlags.Assign, ImplicitUseTargetFlags.WithMembers)]
public class ScrambleRaceConfiguration : IValidateConfiguration<ScrambleRaceConfigurationValidator>
{
    public List<string> Destinations { get; init; } = new();
}
