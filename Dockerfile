FROM mono:3.10
COPY build.sh /var/build.sh
COPY src /var/src
COPY samples /var/samples
CMD [ "mono", "/var/src/LeanIX.sln" ]