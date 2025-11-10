using FluentValidation;
using JetBrains.Annotations;

namespace ScrambleRacePlugin;

// Use FluentValidation to validate plugin configuration
[UsedImplicitly]
public class ScrambleRaceConfigurationValidator : AbstractValidator<ScrambleRaceConfiguration>
{
    public ScrambleRaceConfigurationValidator()
    {
        RuleFor(cfg => cfg.Destinations).NotNull();
    }
}
