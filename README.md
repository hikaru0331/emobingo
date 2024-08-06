<div id="top"></div>

## 使用技術一覧

<!-- シールド一覧 -->
<!-- 該当するプロジェクトの中から任意のものを選ぶ-->
<p style="display: inline">
  <!-- フロントエンド一覧 -->
  <img src="https://img.shields.io/badge/-Unity-000000.svg?logo=unity&style=plastic">
  <!-- バックエンドのフレームワーク一覧 -->
  <!-- バックエンドの言語一覧 -->
　<img src="https://img.shields.io/badge/-Python-3776AB.svg?logo=python&style=plastic">
  <!-- ミドルウェア一覧 -->
  <img src="https://img.shields.io/badge/-Cosmos%20DB-0078D7.svg?logo=azure-devops&style=plastic">
  <!-- インフラ一覧 -->
  <img src="https://img.shields.io/badge/-Azure-0078D7.svg?logo=azure&style=plastic">
  <img src="https://img.shields.io/badge/-Github-181717.svg?logo=github&style=plastic">

</p>

## 目次

1. [プロジェクトについて](#プロジェクトについて)
2. [環境](#環境)
3. [ディレクトリ構成](#ディレクトリ構成)
4. [開発環境構築](#開発環境構築)
5. [ライセンス](#ライセンス)


<!-- プロジェクト名を記載 -->

## プロジェクト名

エモビンゴ

<!-- プロジェクトについて -->

## プロジェクトについて
### 概要
エモビンゴは顔写真を用いたオンラインのビンゴゲームです。
確定新入生歓迎会に焦点を当て、参加者同士の名前と顔、パーソナリティの共有を促進させます。
### 実行環境
3~20人での使用を想定しています。
Webブラウザで動作する2DゲームでUnityroomで公開していますが、スマホでの動作に対応できていません。
ローカル実行のみに対応しています。
フロントはUnity
バックエンドはPython


<p align="right">(<a href="#top">トップへ</a>)</p>

## 環境

<!-- 言語、フレームワーク、ミドルウェア、インフラの一覧とバージョンを記載 -->

| 言語・フレームワーク  | バージョン |
| --------------------- | ----------  |
| Python                | 3.10.11     |
| Unity                 | 2022.3.23f1 |      


その他のパッケージのバージョンは ./Packages/manifest.json またはバックエンドリポジトリの ./requirements.txt を参照してください

### バックエンドのエンドポイント
<p><a href ="https://github.com/plmwa/emobingo-backend">バックエンドのGitHubリポジトリ</a></p>
<p><a href ="https://oval-accordion-b2b.notion.site/9d049a9ce606467f9ccfa592bfd807b6">設計資料</a></p>

Functions:

    create_rooms: [POST] https://die-webapi.azurewebsites.net/api/rooms

    create_users: [POST] https://die-webapi.azurewebsites.net/api/users

    delete_users: [DELETE] https://die-webapi.azurewebsites.net/api/users/{user_id}

    get_rooms: [GET] https://die-webapi.azurewebsites.net/api/rooms/{room_id}

    get_users: [GET] https://die-webapi.azurewebsites.net/api/users/{user_id}

<p align="right">(<a href="#top">トップへ</a>)</p>

## ディレクトリ構成

<!-- Treeコマンドを使ってディレクトリ構成を記載 -->

❯ cd Assets
❯ tree -L 2
<pre>
Assets
├── Font
│   ├── MPLUS1-Black SDF.asset
│   ├── MPLUS1-Black SDF.asset.meta
│   ├── MPLUS1-Black SDF.mat
│   ├── MPLUS1-Black SDF.mat.meta
│   ├── MPLUS1-Black.ttf
│   └── MPLUS1-Black.ttf.meta
├── Font.meta
├── Images
│   ├── CameraButton.png
│   ├── CameraButton.png.meta
│   ├── TitleRogo.png
│   ├── TitleRogo.png.meta
│   ├── Triangle.png
│   ├── Triangle.png.meta
│   ├── button_mini.png
│   ├── button_mini.png.meta
│   ├── button_title.png
│   ├── button_title.png.meta
│   ├── noButton.png
│   ├── noButton.png.meta
│   ├── roomin.png
│   ├── roomin.png.meta
│   ├── roommake.png
│   ├── roommake.png.meta
│   ├── アセット 1.png
│   └── アセット 1.png.meta
├── Images.meta
├── Photon
│   ├── PhotonChat
│   ├── PhotonChat.meta
│   ├── PhotonLibs
│   ├── PhotonLibs.meta
│   ├── PhotonNetworking-Documentation.chm
│   ├── PhotonNetworking-Documentation.chm.meta
│   ├── PhotonRealtime
│   ├── PhotonRealtime.meta
│   ├── PhotonUnityNetworking
│   └── PhotonUnityNetworking.meta
├── Photon.meta
├── Plugins
│   ├── Demigiant
│   └── Demigiant.meta
├── Plugins.meta
├── Prefabs
│   ├── Bullet.prefab
│   └── Bullet.prefab.meta
├── Prefabs.meta
├── Resources
│   ├── Avatar.prefab
│   ├── Avatar.prefab.meta
│   ├── DOTweenSettings.asset
│   ├── DOTweenSettings.asset.meta
│   ├── test_backend
│   └── test_backend.meta
├── Resources.meta
├── Scenes
│   ├── BINGO.unity
│   ├── BINGO.unity.meta
│   ├── PUN2Test.unity
│   ├── PUN2Test.unity.meta
│   ├── SampleScene.unity
│   ├── SampleScene.unity.meta
│   ├── TESTBINGO.unity
│   ├── TESTBINGO.unity.meta
│   ├── TestAPI.unity
│   ├── TestAPI.unity.meta
│   ├── TitleScene.unity
│   └── TitleScene.unity.meta
├── Scenes.meta
├── Scripts
│   ├── Animation
│   ├── Animation.meta
│   ├── BINGO
│   ├── BINGO.meta
│   ├── Backend
│   ├── Backend.meta
│   ├── OnlineSynchronization
│   ├── OnlineSynchronization.meta
│   ├── PUN2Sample
│   ├── PUN2Sample.meta
│   ├── UI
│   └── UI.meta
├── Scripts.meta
├── TextMesh Pro
│   ├── Documentation
│   ├── Documentation.meta
│   ├── Fonts
│   ├── Fonts.meta
│   ├── Resources
│   ├── Resources.meta
│   ├── Shaders
│   ├── Shaders.meta
│   ├── Sprites
│   └── Sprites.meta
└── TextMesh Pro.meta
</pre>

<p align="right">(<a href="#top">トップへ</a>)</p>

## 開発環境構築

<!-- コンテナの作成方法、パッケージのインストール方法など、開発環境構築に必要な情報を記載 -->
### key.csの配置
Azure Functionsのエンドポイントへの認証keyが記述されたkey.csをAssets以下のどこかに配置する。

### 動作確認
1. git clone git@github.com:hikaru0331/emobingo.git
2. Unityでプロジェクトを開く
3. Title Sceneに移動し実行

### ライセンス
#### フォント
このプロジェクトでは以下のフォントを使用しています：

フォント名：M PLUS 1p
デザイナー：森下浩司
配布元：Google Fonts (https://fonts.google.com/specimen/M+PLUS+1p)
ライセンス：SIL Open Font License, Version 1.1

ライセンスの全文は以下のURLで確認できます：
https://scripts.sil.org/OFL

M PLUS 1p は SIL Open Font License の下で配布されており、このプロジェクトでの使用が許可されています。

<p align="right">(<a href="#top">トップへ</a>)</p>