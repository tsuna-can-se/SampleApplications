using Microsoft.Extensions.Options;

namespace OptionsPattern.Web.Configurations;

// OptionsValidator 属性をつけて以下のように実装しておくと、
// ソースジェネレーターにより検証のためのコードが自動生成される。
// ValidateObjectMembers 属性や ValidateEnumeratedItems 属性をつけたプロパティがある場合、
// それらのクラスに対応する IValidateOptions<TOption> クラスは作成しなくてよい。
// ネスト元のオプションのクラスに対する IValidateOptions<TOption> があれば、
// その中で使われているクラスの IValidateOptions<TOption> クラスもソースジェネレーターにより生成される。
[OptionsValidator]
public partial class OptionsPatternSettingsValidator : IValidateOptions<OptionsPatternSettings>
{
}
