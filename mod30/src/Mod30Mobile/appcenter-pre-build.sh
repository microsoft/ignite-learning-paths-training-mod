#!/usr/bin/env bash

echo "Arguments for updating:"
echo " - iOS App Center: $IOS_APP_CENTER"
echo " - Android App Center: $ANDROID_APP_CENTER"

# Updating ids

AppCenterConstantsFile=$BUILD_REPOSITORY_LOCALPATH/src/TailwindTraders.Mobile/TailwindTraders.Mobile.Core/Helpers/AppCenterConstants.cs

sed -i '' "s/< ENTER YOUR APP CENTER IOS SECRET HERE >/$IOS_APP_CENTER/g" $AppCenterConstantsFile
sed -i '' "s/< ENTER YOUR APP CENTER ANDROID SECRET HERE >/$ANDROID_APP_CENTER/g" $AppCenterConstantsFile

# Print out file for reference
cat $AppCenterConstantsFile

echo "Updated id!"