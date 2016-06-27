#!/bin/bash
docker build -t leanix/leanix-csharp-sdk .
docker run --rm leanix/leanix-csharp-sdk sh /var/samples/run_client.sh
docker rmi leanix/leanix-csharp-sdk