#!/bin/bash
docker build -t leanix-csharp-sdk .
docker run --rm leanix-csharp-sdk sh /var/build.sh
docker rmi leanix-csharp-sdk