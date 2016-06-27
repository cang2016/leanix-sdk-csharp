#!/bin/bash
cd /var/src
echo "Installing nuget dependencies..."
nuget install LeanIX/packages.config -OutputDirectory packages

echo "Compiling leanix-sdk-csharp..."
# No warnings: xbuild LeanIX.sln /p:WarningLevel=0
xbuild LeanIX.sln

echo "Compiling example project..."
cd /var/samples/client
xbuild LeanIX.sln /p:WarningLevel=0
