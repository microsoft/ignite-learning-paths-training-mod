# Installing Xamarin and the Mobile Application

This article will cover the following:

* [How to install Xamarin and configure any emulators](#install)
* [How to run the Tailwind Traders mobile application from code](#code)
* [How to install the Tailwind Traders application from App Center and/or TestFlight](#compile)
* [Tips and tricks to run the demos successfully](#tips)

## Should I Demo the App From Code Or Not?

The first decision that you need to make is whether you'll demo the application using Visual Studio and run the Tailwind Traders mobile application in debug mode _OR_ download a compiled version of the app and demo it running on your personal device.

There are pros and cons of each.

### Running From Code

When running from code you will have to download Visual Studio (either for Windows or Mac OS) and install the Xamarin workload. Then you will need to configure an Android emulator.

Getting this environment setup does involve a bit of time, but once you have it running, it will be stable.

The following are the pros and cons of running from code.

#### Pros

* You will be more familiar with the mobile app's code and be well equipped to answer any questions from attendees.
* You will not need to use your personal mobile device, nor mirror its screen to your laptop during the demos.
* You will not have to rely on the event venue's wifi to connect your device to.

#### Cons

* Getting the Android emulators to work can be difficult in some cases on Windows machines.
* There will be more prep time for the demos to be sure you are familiar with how the emulators work.
* Due to restrictions on iOS push notifications - you cannot demo that portion of the session on iOS

### Running From Compiled

The Tailwind Traders app will also be available for you to download via App Center (Android) or Test Flight (iOS). Going this route will install the application on your device just as if you downloaded it from the various stores.

However, while demoing, you will be using your personal device, so you need to prepare beforehand so attendees do not see any personal information.

The following are the pros and cons of running from compiled.

### Pros

* You do not have to setup a development environment.
* Can demo with a device you are already familiar with.
* No restrictions as to available features.

### Cons

* You will have to screen mirror your device, which involves several moving parts, so you need to be prepared for it failing.
* You will have to rely on the venue's wifi to upload photos - which may be problematic.
* You will not be as familiar with the code for any attendees questions.

### What Is the Recommendation?

The easiest way is to run from a compiled version.

For **MOD30** you should give serious thought of running from [code in Visual Studio](#code). This will help you debug any errors, should they occur. However, demoing a mobile app at the same time as other things can be burdensome.

For **APPS10** you will be find running from the [compiled version](#compile).

## <a name="install"></a>Installing Xamarin and Configuring Emulators

### Windows 

Installing Xamarin on Windows can be done by selecting the _Mobile Development with .NET_ workload from the Visual Studio Installer.

![mobile development with .NET workload](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_600/v1579909568/vs-workload_flmjkj.jpg)

This will get you up and running with the Xamarin development environment. The [full installation documentation can be found here](https://docs.microsoft.com/en-us/xamarin/get-started/installation/windows?WT.mc_id=msignitethetour2019-github-mod30).

It is recommended to only demo Android while running on Windows. Jump ahead to read how to [configure the Android emulators](#emulator).

### Mac OS

Installing Xamarin on Mac OS is done by installing Visual Studio for Mac. There are no additional workloads, Xamarin is installed by default.

The installation will get your environment ready for both Android and iOS development. The [full Mac OS installation documentation can be found here](https://docs.microsoft.com/en-us/visualstudio/mac/installation?view=vsmac-2019&WT.mc_id=msignitethetour2019-github-mod30).

While you can demo on iOS simulators, it is recommended to only use Android to keep the workflow as smooth as possible. Read on to find out how.

### <a name="emulator"></a>Android Emulator Configuration

The Android Emulator can sometimes be finicky to setup.

To find out if yours setup OK. Open Visual Studio and try creating a _Blank Xamarin.Forms_ project. Then try running the Android version of it, by making the Android project the startup project.

If the emulator starts, you're in business. If not, you'll need to follow these directions to help you through it. [Windows troubleshooting](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/troubleshooting?pivots=windows&WT.mc_id=msignitethetour2019-github-mod30). [Mac troubleshooting](https://docs.microsoft.com/en-us/xamarin/android/get-started/installation/android-emulator/troubleshooting?pivots=macos&WT.mc_id=msignitethetour2019-github-mod30).

## <a name="code"></a>Running From Code

### Basic Setup

1. Clone this repository
1. Create a file named `google-services.json` in the root of the Android project.

### Getting and Copying Confidential Keys for Push Notifications

1. Go to [this document](https://microsoft-my.sharepoint.com/:u:/p/masoucou/EUgju-HxAPNLi-RUbVEU5bcBe8Unxtv0irL2xMIK0bNI8w?e=uK1xvT) and copy the JSON into the contents of `google-services.json` (link will only work for internal Microsoft.)
1. Within the `TailwindTraders.Mobile` project. Open the file in the `Helpers` folder called `AppCenterConstants.cs`
1. Replace the value of `AndroidAppSecret` and `iOSAppSecret` with what is [found in this file](https://microsoft-my.sharepoint.com/:t:/p/masoucou/ETGwhnNsN-lOoyFHCtRBv8EBmEaAWzcrBWlt-9jY-I0Vgw?e=o9rQqx).

### Run the Code

1. Select the Android project as the startup project of the solution, by right clicking on it and then picking `Set as Startup Project` from the resulting menu.
1. Make sure an Android Emulator appears in a dropdown at the top of Visual Studio. (If not, follow the [emulator troubleshooting directions](#emulator).)
1. Hit the `Play` button from the toolbar at the top of Visual Studio.
1. The emulator should launch (this may take a while for the first boot).
1. The application will load.
1. Read [tips and tricks](#tips) for additional hints on working the demos.

## <a name="compile"></a>Running From Compile

### Android

1. On your Android device, browse to: https://aka.ms/tailwind-droid - tap the download button.

![droid app center screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/droid-app-center_orx32p.png)

2. Once the download is complete Android will prompt you to open the application, tap **Open**.

![droid open application](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/droid-finish-download_usdp9h.png)

3. You will again get prompted top open the application. Tap **Open** again.

![droid open app](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/droid-open-app_q39pyd.png)

4. You will then get prompted to install the application. Tap **Install**. The application will be installed just like any other application and you can open it from the launcher.

![droid install app screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/droid-install-app_dwjwia.png)

### iOS

1. On your **iOS Phone** (iPad not supported), browse to: https://aka.ms/tailwind-ios. Install the _TestFlight_ application from the iOS App Store.

![test flight screen shot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/ios-testflight-page_p8bf1v.png)

1. The App Store will open, download and install _Test Flight_ as you would any other app.

![iOS App Store for Test Flight installation screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/ios-install-testflight_kzj4as.png)

1. Once installed, go back to the web browser screen from step 1. Tap on the button to install Tailwind Traders.

![tailwind tradrs install screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/ios-testflight-page_p8bf1v.png)

1. The TestFlight application will launch. Follow the instructions on setting TestFlight up.

![testflight setup instructions screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/ios-setup-testflight_mzul8x.png)

1. You will then be presented with a screen to install Tailwind Traders, tap **Install** and the app will be installed as if you downloaded it from the App Store.

![install Tailwind Traders app from testflight screenshot](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/ios-install-tailwind_ilw1sl.png)

## <a name="tips"></a>Tips and Tricks For a Successful Demo

Once the Tailwind application is successully running on your device or emulator, here are some tips to ensure a successful demo.

### Setting Up Function URLs and Storage Account Names

In order for the demos to run successfully, the mobile application needs to have the URL of the Function App and the name of the Storage Account that you are using in your demo.

You can set these from the `Settings` screen.

1. Tap on the Hamburger icon in the upper left corner to make the flyout appear.

![hamburger menu](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/hamburger_swalqh.png)

2. Tap on the `Settings` menu item.
3. Change the `Storage Account Name` entry box to the one you are using for your demo. (The pink highlight below.)
4. Change the `Function App URL` entry box to the one you are using in your demo. (The yellow highlight below.) _NOTE: You must include the url through the `/api` portion. The route to the actual function will be appended by the application._

![urls to change](https://res.cloudinary.com/code-mill-technologies-inc/image/upload/c_scale,e_shadow:40,h_800/v1579909568/settings_y7i9bs.jpg)

> You can leave the `Product Service API URL` setting as-is. That setting is pulling product metadata, and does not affect these demos. If you wish to change it, you first must setup the Tailwind Traders website first.

### Taking or Choosing Photos

You can either take or choose photos to upload to the Function App. Either photo button found on the `Shopping` screen or `Flyout` menu will work.

If you are choosing a photo from a personal device, it is recommended you have some preloaded and ready to go _before_ getting on stage, this way the audience will not see your personal photos.

If you are demoing from an Android emulator. Go to this website via the emulator's web browser (most likely Chrome) and browse to this website. Long press each image with the left mouse button. A menu will appear allowing you to download the image.

* [Door frame photo - https://aka.ms/tw-frames](https://aka.ms/tw-frames)
* [Power drill photo - https://aka.ms/tw-drill](https://aka.ms/tw-drill)
* [Hammer photo - https://aka.ms/tw-hammer](https://aka.ms/tw-hammer)
* [Wrench photo - https://aka.ms/tw-wrench](https://aka.ms/tw-wrench)

**DO THIS BEFORE THE DEMOING ON STAGE**

Then when you select an image while running the app, that image will appear.

The app will give you the option to select more than one image. Only select one. Also, be patient after you select an image, as it takes a second or two for control to be given from the operating system back to the Tailwind Traders application.

### Emulator Launching

It takes a while for the emulator to launch when debugging from code. It is recommended you build the app before starting the talk.

Also, don't start the emulator until after you are already plugged in to the projector. This will make sure the emulator starts at the appropriate resolution.

### Screen Mirroring (On-Device Only)

If you are demoing from your personal device, you will need to mirror the screen from your device to your laptop. This will be accomplished through either [Reflector for iOS](https://www.airsquirrels.com/reflector) or [Vysor for Android](http://www.vysor.io/).

#### iOS with Reflector 

[Reflector can be purchased](https://www.airsquirrels.com/reflector) from Air Squirrels for $15 per license and there is an edition for Windows and Mac OS.

Reflector works via AirPlay. Here are the [setup instructions](https://www.airsquirrels.com/reflector/faq/share-iphone-screen). Reflector is mirror only - all input to your device must occur on your device.

#### Android with Vysor

[Vysor can be purchased](http://www.vysor.io/) to mirror your Android device to your laptop. Vysor installs an application on both your phone and your laptop. Vysor is more full-featured than Reflector in that it also takes keyboard and mouse input from your laptop and communicates that to your phone.
