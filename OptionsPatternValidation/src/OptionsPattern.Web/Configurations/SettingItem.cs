using System.ComponentModel.DataAnnotations;

namespace OptionsPattern.Web.Configurations;

public class SettingItem
{
    [Required]
    public required string Name { set; get; }

    [Required]
    public required string Value { set; get; }
}
