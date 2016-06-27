#!/bin/bash
docker build -t leanix/leanix-csharp-sdk .
docker run --rm leanix/leanix-csharp-sdk sh /var/build.sh
docker rmi leanix/leanix-csharp-sdk