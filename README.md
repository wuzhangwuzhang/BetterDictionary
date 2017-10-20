BetterDictionary for Unity
===
BetterDictionary/BetterHashSetクラスはSystem.Collections.Generic名前空間のDictionary/HashSetクラスをUnity向けに高速化したものです。  

    ※.NET Core 2.0等では逆に遅くなるのでご注意ください。

特徴
---
- 一部をILで実装したIEqualityComparer\<T\>を使用するDictionary/HashSetクラスです。
  - System.Collections.Generic名前空間のDictionary/HashSetクラスを継承しているため、既存プロジェクトへの導入が容易です。
- .NET 3.5ランタイムにおいて、列挙型・プリミティブ型(intやbyte等)・string型をキーとした場合にパフォーマンスが向上します。
  - 列挙型は\~70%程度、プリミティブ型は\~20%程度、string型は\~15%程度の高速化。
  - 列挙型をキーとした場合にボックス化が発生しません。(IEqualityComparer<T>を実装した場合と同等のパフォーマンスで動作します）
- .NET 4.6ランタイムにおいても、通常のDictionary/HashSetクラスよりは高速に動作します。
  - 列挙型は\~30%程度、プリミティブ型は\~20%程度、string型は\~20%程度の高速化。
- IL2CPP(iOS/Android)でも一応動作します。（※十分に検証できていません）
  - ※IL2CPPが生成するC++コードのコンパイルエラーを強引に回避しているため、将来的にコンパイルが通らなくなる可能性があります。

導入方法
---
1. BetterDictionary.dllをAssets/Plugins以下に配置してください。
1. 追加でBetterDictionaryPatch.csを配置することで、プロジェクトソース内で使用されているDictionary/HashSetクラスをBetterDictionary/BetterHashSet(を継承したグローバル名前空間のDictionary/HashSet)クラスに置き換えることができます。

License
---
This library is under the MIT License.
