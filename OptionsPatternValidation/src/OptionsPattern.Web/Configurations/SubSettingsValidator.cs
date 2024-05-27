using Microsoft.Extensions.Options;

namespace OptionsPattern.Web.Configurations;

[OptionsValidator]
public partial class SubSettingsValidator : IValidateOptions<SubSettings>
{
}
