using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace OptionsPattern.Web.Configurations;

public class OptionsPatternSettings
{
    public const string ConfigurationSectionName = nameof(OptionsPatternSettings);

    [Required]
    public required string Setting1 { get; set; }

    // ネストした設定のクラスに検証属性をつける場合は、
    // 参照元のオプションのクラスに ValidateObjectMembers 属性をつける。
    [ValidateObjectMembers]
    public SubSettings SubSettings { get; set; } = new();

    // ネスト下設定のクラスがリストや配列になる場合は、
    // 参照元のオプションのクラスに ValidateEnumeratedItems 属性をつける。
    [ValidateEnumeratedItems]
    public IList<SettingItem> SettingItems { get; set; } = [];
}