using Microsoft.Extensions.Options;

namespace OptionsPattern.ValidationTiming.Configurations;

[OptionsValidator]
public partial class OptionsPatternSettingsValidator : IValidateOptions<OptionsPatternSettings>
{
}
