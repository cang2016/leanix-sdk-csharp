#!/bin/bash
echo "Compiling leanix-sdk-csharp..."
cd /var/src
nuget install LeanIX/packages.config -OutputDirectory packages
xbuild LeanIX.sln