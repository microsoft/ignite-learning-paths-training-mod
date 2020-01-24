#!/usr/bin/env bash

echo "Arguments for updating:"
echo " - iOS App Center: $IOS_APP_CENTER"
echo " - Android App Center: $ANDROID_APP_CENTER"

# Updating ids

AppCenterConstantsFile=$BUILD_REPOSITORY_LOCALPATH/mod30/src/Mod30Mobile/TailwindTraders.Mobile/TailwindTraders.Mobile.Core/Helpers/AppCenterConstants.cs

sed -i '' "s/< ENTER YOUR APP CENTER IOS SECRET HERE >/$IOS_APP_CENTER/g" $AppCenterConstantsFile
sed -i '' "s/< ENTER YOUR APP CENTER ANDROID SECRET HERE >/$ANDROID_APP_CENTER/g" $AppCenterConstantsFile

# Print out file for reference
cat $AppCenterConstantsFile

echo "Updated App Center Constants"

GoogleJsonFile=$BUILD_REPOSITORY_LOCALPATH/mod30/src/Mod30Mobile/TailwindTraders.Mobile/TailwindTraders.Mobile.Android/google-services.json

sed -i '' "s/< PROJECT NUMBER >/$GOOGLE_PROJ_NUMBER/g" $GoogleJsonFile
sed -i '' "s/< MOBILE SDK APP ID >/$GOOGLE_MOBILE_SDK_APP_ID/g" $GoogleJsonFile
sed -i '' "s/< CLIENT ID >/$GOOGLE_CLIENT_ID/g" $GoogleJsonFile
sed -i '' "s/< CURRENT KEY >/$GOOGLE_CURRENT_KEY/g" $GoogleJsonFile
sed -i '' "s/< SECOND CLIENT ID >/$GOOGLE_SECOND_CLIENT_ID/g" $GoogleJsonFile