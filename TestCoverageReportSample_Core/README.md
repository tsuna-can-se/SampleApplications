## このサンプルについて

.NET Standard 2.0 のクラスライブラリプロジェクトと、.NET Core 3.1 の単体テストプロジェクトからなるサンプルプロジェクトです。
2020/07/25 現在、 Visual Studio 2019 が生成する単体テストプロジェクトを用いて、MSTest による単体テストが実装されています。

またリポジトリ内には Azure Pipelines で実行可能な YAML ファイルが含まれています。
このビルドパイプラインでは、単体テストのカバレッジを [coverlet.collector](https://github.com/coverlet-coverage/coverlet) を用いて収集し、ビルドサマリーとして参照できるように構成しています。

詳細は以下の記事を参照してください。

Azure Pipelines のビルド結果画面にコードカバレッジの結果を表示する（.NET Core）

https://tsuna-can.hateblo.jp/entry/2020/07/27/080000
