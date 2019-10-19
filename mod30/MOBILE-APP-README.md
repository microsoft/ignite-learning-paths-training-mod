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

For **MOD30**, I recommend running from code. You already need to have Visual Studio installed. Running from code will reduce the number of moving parts.

If you are only demoing the app as part of **APP10** you can download the compiled version. You will not need to be as familiar with it. However, please try out the screen mirroring beforehand to make sure you are comfortable with that workflow.

## <a name="install"></a>Installing Xamarin and Configuring Emulators

### Windows 

Installing Xamarin on Windows can be done by selecting the _Mobile Development with .NET_ workload from the Visual Studio Installer.

![mobile development with .NET workload](./images/vs-workload.jpg)

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

1. Go to this document and copy the JSON into the contents of `google-services.json` (link will only work for internal Microsoft.)
1. Within the `TailwindTraders.Mobile` project. Open the file in the `Helpers` folder called `AppCenterConstants.cs`
1. Replace the value of `AndroidAppSecret` and `iOSAppSecret` with what is found in this file.

### Run the Code

1. Select the Android project as the startup project of the solution, by right clicking on it and then picking `Set as Startup Project` from the resulting menu.
1. Make sure an Android Emulator appears in a dropdown at the top of Visual Studio. (If not, follow the [emulator troubleshooting directions](#emulator).)
1. Hit the `Play` button from the toolbar at the top of Visual Studio.
1. The emulator should launch (this may take a while for the first boot).
1. The application will load.
1. Read [tips and tricks](#tips) for additional hints on working the demos.

## <a name="compile"></a>Running From Compile

### Android

1. On your Android device, browse to: https://aka.ms/tailwind-droid
1. Follow the directions on screen.
1. You will have to trust.

### iOS

1. On your **iOS Phone** (iPad not supported), browse to: https://aka.ms/tailwind-ios
1. It will prompt you to download the TestFlight application. This is Apple's means of distributing iOS applications without going through the App Store. _We are limited to 10,000 downloads. FYI_
1. Follow the on-screen instructions.

## <a name="tips"></a>Tips and Tricks For a Successful Demo

