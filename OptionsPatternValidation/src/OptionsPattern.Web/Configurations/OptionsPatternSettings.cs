using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace OptionsPattern.Web.Configurations;

public class OptionsPatternSettings
{
    public const string ConfigurationSectionName = nameof(OptionsPatternSettings);

    [Required]
    public required string Setting1 { get; set; }

    // �l�X�g�����ݒ�̃N���X�Ɍ��ؑ���������ꍇ�́A
    // �Q�ƌ��̃I�v�V�����̃N���X�� ValidateObjectMembers ����������B
    [ValidateObjectMembers]
    public SubSettings SubSettings { get; set; } = new();

    // �l�X�g���ݒ�̃N���X�����X�g��z��ɂȂ�ꍇ�́A
    // �Q�ƌ��̃I�v�V�����̃N���X�� ValidateEnumeratedItems ����������B
    [ValidateEnumeratedItems]
    public IList<SettingItem> SettingItems { get; set; } = [];
}