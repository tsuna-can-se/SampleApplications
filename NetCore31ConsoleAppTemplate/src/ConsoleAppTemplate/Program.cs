using System;
using System.IO;
using ConsoleAppTemplate.Resources;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleAppTemplate
{
    /// <summary>
    ///  エントリーポイントを提供します。
    /// </summary>
    internal class Program
    {
        private static IConfigurationRoot? configuration;
        private static ILogger? logger;

        /// <summary>
        ///  このアプリケーションのエントリーポイントです。
        /// </summary>
        /// <param name="args">起動引数。</param>
        /// <returns>コンソールアプリケーションの終了コード。</returns>
        internal static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            configuration = LoadConfiguration();
            using (var provider = CreateServiceProvider())
            {
                logger = provider.GetRequiredService<ILogger<Program>>();
                var entryPoint = provider.GetRequiredService<EntryPoint>();
                return entryPoint.StartProcessAsync(args).GetAwaiter().GetResult();
            }
        }

        /// <summary>
        ///  <paramref name="services"/> に指定された <see cref="IServiceCollection"/> オブジェクトを構築します。
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/> オブジェクト。</param>
        private static void ConfigureService(IServiceCollection services)
        {
            if (configuration == null)
            {
                throw new InvalidOperationException();
            }

            // TODO: ILoggerの設定を行います。
            //       必要に応じて、ファイルやイベントログなどの Logger を追加するように実装してください。
            //       Microsoft.Extensions.Logging.Xxxx という名前の NuGet パッケージを検索すると、いろいろ見つかります。
            services.AddLogging(configure =>
            {
                configure.ClearProviders();
                configure.AddConfiguration(configuration.GetSection("Logging"))
                    .AddConsole();
            });

            // TODO: ここで引数に指定する IServiceCollection オブジェクトを構築します。
        }

        /// <summary>
        ///  <see cref="ServiceProvider"/> オブジェクトを生成します。
        /// </summary>
        /// <returns><see cref="ServiceProvider"/> オブジェクト。</returns>
        private static ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            ConfigureService(services);
            services.AddSingleton<EntryPoint>();
            return services.BuildServiceProvider(true);
        }

        /// <summary>
        ///  appsettings.json から <see cref="IConfigurationRoot"/> を読み込みます。
        /// </summary>
        /// <returns>appsettings.json から読み込んだ <see cref="IConfigurationRoot"/> オブジェクト。</returns>
        private static IConfigurationRoot LoadConfiguration()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile(path: "appsettings.json", true)
               .AddJsonFile(path: $"appsettings.{environmentName}.json", true)
               .AddEnvironmentVariables(prefix: "DOTNET_");
            return builder.Build();
        }

        /// <summary>
        ///  未処理の例外が発生したときに起動するイベントハンドラーです。
        /// </summary>
        /// <param name="sender">送信元。</param>
        /// <param name="e">イベントデータ。</param>
        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var ex = e.ExceptionObject as Exception;
            var log = logger;
            if (log != null)
            {
                log.LogError(ex, Messages.UnhandledExceptionIsOccurs);
            }
            else
            {
                // Logger がない場合はコンソールに出力する。
                Console.WriteLine(Messages.UnhandledExceptionIsOccurs);
                Console.WriteLine(ex);
            }
        }
    }
}