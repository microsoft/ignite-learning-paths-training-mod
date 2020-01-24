#!/usr/bin/env bash

echo "Arguments for updating:"
echo " - iOS App Center: $IOS_APP_CENTER"
echo " - Android App Center: $ANDROID_APP_CENTER"

# Updating ids

AppCenterConstantsFile=$BUILD_REPOSITORY_LOCALPATH/mod30/src/Mod30Mobile/TailwindTraders.Mobile/TailwindTraders.Mobile.Core/Helpers/AppCenterConstants.cs

# echo " - app center file: $AppCenterConstantsFile"

sed -i '' "s/< ENTER YOUR APP CENTER IOS SECRET HERE >/$IOS_APP_CENTER/g" $AppCenterConstantsFile
sed -i '' "s/< ENTER YOUR APP CENTER ANDROID SECRET HERE >/$ANDROID_APP_CENTER/g" $AppCenterConstantsFile

# Print out file for reference
cat $AppCenterConstantsFile

# echo "Updated App Center Constants"

GoogleJsonFile=$BUILD_REPOSITORY_LOCALPATH/mod30/src/Mod30Mobile/TailwindTraders.Mobile/TailwindTraders.Mobile.Android/google-services.json

echo " - google json file: $GoogleJsonFile"
echo " - current google key: $GOOGLE_CURRENT_KEY"

sed -i '' "s/< project number >/$GOOGLE_PROJ_NUMBER/g" $GoogleJsonFile
sed -i '' "s/< sdk app id >/$GOOGLE_MOBILE_SDK_APP_ID/g" $GoogleJsonFile
sed -i '' "s/< client id >/$GOOGLE_CLIENT_ID/g" $GoogleJsonFile
sed -i '' "s/< key >/$GOOGLE_CURRENT_KEY/g" $GoogleJsonFile
sed -i '' "s/< client id two >/$GOOGLE_SECOND_CLIENT_ID/g" $GoogleJsonFile

cat $GoogleJsonFile