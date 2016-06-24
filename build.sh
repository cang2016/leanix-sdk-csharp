#!/bin/bash
echo "Compiling leanix-sdk-csharp..."
cd /var/src
nuget install LeanIX/packages.config -OutputDirectory packages
# No warnings: xbuild LeanIX.sln /p:WarningLevel=0
xbuild LeanIX.sln

# Compile sample
cd /var/samples/client
xbuild LeanIX.sln /p:WarningLevel=0
