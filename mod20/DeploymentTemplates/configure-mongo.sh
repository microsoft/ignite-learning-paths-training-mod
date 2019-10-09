#!/bin/bash

wget -qO - https://www.mongodb.org/static/pgp/server-3.4.asc | sudo apt-key add -

echo "deb [ arch=amd64,arm64 ] http://repo.mongodb.org/apt/ubuntu xenial/mongodb-org/3.4 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-3.4.list

sudo apt-get update

sudo apt-get install -y mongodb-org

echo "mongodb-org hold" | sudo dpkg --set-selections
echo "mongodb-org-server hold" | sudo dpkg --set-selections
echo "mongodb-org-shell hold" | sudo dpkg --set-selections
echo "mongodb-org-mongos hold" | sudo dpkg --set-selections
echo "mongodb-org-tools hold" | sudo dpkg --set-selections

sudo sed -i -e "s/127.0.0.1/0.0.0.0/g" /etc/mongod.conf

sudo service mongod start

sleep 2m

sudo mongo tailwind --eval "db.dropUser('twtadmin')"
sudo mongo tailwind --eval "db.createUser({user:'$1',pwd:'$2',roles:[{role:'dbAdmin',db:'tailwind'}]})"