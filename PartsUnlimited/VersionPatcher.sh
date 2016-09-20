#!/bin/bash
echo "setting versions to 1.0.$BUILD_BUILDID"

export PLISTBUDDY="/usr/libexec/PlistBuddy"

export INFO=$BUILD_SOURCESDIRECTORY"/PartsUnlimited/PartsUnlimited/PartsUnlimited.iOS/Info.plist"
$PLISTBUDDY $INFO -c "set :CFBundleShortVersionString 1.0.$BUILD_BUILDID"
$PLISTBUDDY $INFO -c "set :CFBundleVersion 1.0