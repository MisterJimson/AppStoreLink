# Mj.AppStoreLink
Simple cross platform librray that lets you link to the native store app on Android, iOS and UWP

## Platforms
* Android
* iOS
* Windows UWP

## How To Use
Using your Android package id, iTunes App Store id, and Window Store id we can open the native app store for each platform. We get the Android package id automatically, but need you to pass in the iTunes App Store id and the Windows Store id. Pass null for any platform you don't support.

Init your store information for the App Store and the Windows Store.
```csharp
AppStoreLinkService.Instance.Init("284815942",
                                  "9wzdncrfj2gk");
```
Then you can open the native app store page for your app with the following call.
```csharp
AppStoreLinkService.Instance.OpenMyAppStorePage();
```
You can also open any other app store page with the following call.
```csharp
AppStoreLinkService.Instance.OpenAppStorePage("com.google.android.googlequicksearchbox",
                                              "284815942",
                                              "9wzdncrfj2gk");
```

## Install
Install from Nuget https://www.nuget.org/packages/Mj.AppStoreLink
