FROM mono:4.2.4.4

# install vim in case of development
#RUN apt-get update && apt-get install -y vim && apt-get clean && rm -rf /var/lib/apt/lists/*
#ENV TERM=xterm

COPY build.sh /var/build.sh
COPY src /var/src
COPY samples /var/samples
CMD [ "mono", "/var/src/LeanIX.sln" ]