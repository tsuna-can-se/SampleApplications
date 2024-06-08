using System.ComponentModel.DataAnnotations;

namespace OptionsPattern.Web.Configurations;

public class SubSettings
{
    [Required]
    [Range(0, 100)]
    public int Level { get; set; } = 0;
}