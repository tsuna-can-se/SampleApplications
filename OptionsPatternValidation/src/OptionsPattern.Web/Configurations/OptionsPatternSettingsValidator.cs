using Microsoft.Extensions.Options;

namespace OptionsPattern.Web.Configurations;

// OptionsValidator ���������Ĉȉ��̂悤�Ɏ������Ă����ƁA
// �\�[�X�W�F�l���[�^�[�ɂ�茟�؂̂��߂̃R�[�h���������������B
// ValidateObjectMembers ������ ValidateEnumeratedItems �����������v���p�e�B������ꍇ�A
// �����̃N���X�ɑΉ����� IValidateOptions<TOption> �N���X�͍쐬���Ȃ��Ă悢�B
// �l�X�g���̃I�v�V�����̃N���X�ɑ΂��� IValidateOptions<TOption> ������΁A
// ���̒��Ŏg���Ă���N���X�� IValidateOptions<TOption> �N���X���\�[�X�W�F�l���[�^�[�ɂ�萶�������B
[OptionsValidator]
public partial class OptionsPatternSettingsValidator : IValidateOptions<OptionsPatternSettings>
{
}
