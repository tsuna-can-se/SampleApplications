using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace OptionsPattern.ValidationTiming.Configurations;

public class OptionsPatternSettings
{
    public const string ConfigurationSectionName = nameof(OptionsPatternSettings);

    [Required]
    public required string Setting1 { get; set; }

    [ValidateObjectMembers]
    public SubSettings SubSettings { get; set; } = new();
}