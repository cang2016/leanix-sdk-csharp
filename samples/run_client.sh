#!/bin/bash
echo "Building leanix-sdk-csharp client example..."
cd /var/samples/client
nuget install ../../src/LeanIX/packages.config -OutputDirectory ../../src/packages
xbuild LeanIX.sln /p:WarningLevel=0

echo "Running leanix-sdk-csharp client example..."
echo ""
echo ""
cd SampleClient/bin/Debug
mono SampleClient.exe
echo ""
echo ""
echo "Done!"
