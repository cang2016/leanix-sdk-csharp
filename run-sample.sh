#!/bin/bash
docker build -t leanix-csharp-sdk .
docker run --rm leanix-csharp-sdk sh /var/samples/run_client.sh
docker rmi leanix-csharp-sdk