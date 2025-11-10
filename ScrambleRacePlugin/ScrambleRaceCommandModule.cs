using AssettoServer.Commands;
using Qmmands;

namespace ScrambleRacePlugin;


public class ScrambleRaceCommandModule : ACModuleBase
{
    private readonly ScrambleRaceConfiguration _configuration;
    private readonly ScrambleRacePlugin _scrambleRace;

    public ScrambleRaceCommandModule(ScrambleRaceConfiguration configuration, ScrambleRacePlugin scrambleRace)
    {
        _configuration = configuration;
        _scrambleRace = scrambleRace;
    }

    [Command("scramble")]
    public void ScrambleCommand()
    {
        _scrambleRace.OnScrambleCommand(Client!);
    }
}
