using Microsoft.Extensions.Options;

namespace OptionsPattern.ValidationTiming.Configurations;

[OptionsValidator]
public partial class SubSettingsValidator : IValidateOptions<SubSettings>
{
}
