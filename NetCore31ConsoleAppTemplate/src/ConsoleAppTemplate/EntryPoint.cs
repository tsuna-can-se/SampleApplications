using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ConsoleAppTemplate
{
    /// <summary>
    ///  コンソールアプリケーションのエントリーポイントとなるクラスです。
    ///  アプリケーションの処理ロジックは、この中に実装します。
    /// </summary>
    internal class EntryPoint
    {
        private readonly ILogger logger;

        /// <summary>
        ///  <see cref="EntryPoint"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="logger">ロギング用のオブジェクト。</param>
        public EntryPoint(ILogger<EntryPoint> logger)
        {
            this.logger = logger;
        }

        /// <summary>
        ///  コンソールアプリケーションのエントリーポイントです。
        ///  処理ロジックをこの中に実装してください。
        /// </summary>
        /// <param name="args">起動引数。</param>
        /// <returns>コンソールアプリケーションの終了コード。</returns>
        internal Task<int> StartProcessAsync(string[] args)
        {
            this.logger.LogInformation($"起動引数: {string.Join(',', args)}");

            // TODO: ここにアプリケーションの処理ロジックを実装します。

            return Task.FromResult(0);
        }
    }
}
