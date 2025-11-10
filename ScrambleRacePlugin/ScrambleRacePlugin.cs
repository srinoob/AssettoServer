using AssettoServer.Network.Tcp;
using AssettoServer.Server;
using AssettoServer.Server.Plugin;
using AssettoServer.Shared.Network.Packets.Shared;
using AssettoServer.Shared.Services;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ScrambleRacePlugin;

public class ScrambleRacePlugin : CriticalBackgroundService, IAssettoServerAutostart
{
    private readonly ScrambleRaceConfiguration _configuration;
    private readonly EntryCarManager _entryCarManager;

    private bool _countdownActive = false;

    public ScrambleRacePlugin(ScrambleRaceConfiguration configuration, EntryCarManager entryCarManager, IHostApplicationLifetime applicationLifetime) : base(applicationLifetime)
    {
        _configuration = configuration;
        _entryCarManager = entryCarManager;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Log.Debug("Scramble plugin autostart called");
        return Task.CompletedTask;
    }

    internal void OnScrambleCommand(ACTcpClient client)
    {
        if (_countdownActive)
        {
            client.SendPacket(new ChatMessage { SessionId = 255, Message = "Countdown already running!" });
            return;
        }

        _ = StartCountdownAsync();
    }

    private async Task StartCountdownAsync()
    {
        _countdownActive = true;      
        
        for (int i = 5; i >= 0; i--)
        {
            if (i > 0)
            {
                _entryCarManager.BroadcastPacket(new ChatMessage { SessionId =255, Message = $"Countdown: {i}" });
            }
            else
            {
                _entryCarManager.BroadcastPacket(new ChatMessage { SessionId = 255, Message = "GO!" });
            }
            await Task.Delay(1000);
        }

        var destination = _configuration.Destinations[new Random().Next(_configuration.Destinations.Count)];
        _entryCarManager.BroadcastPacket(new ChatMessage { SessionId = 255, Message = $"Race to {destination}!" });

        _countdownActive = false;
    }

}
