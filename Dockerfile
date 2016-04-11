FROM mono:3.10
COPY build.sh /var/build.sh
COPY src /var/src
CMD [ "mono", "/var/src/LeanIX.sln" ]