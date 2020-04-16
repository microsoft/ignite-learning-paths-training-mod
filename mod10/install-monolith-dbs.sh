#!/bin/bash


echo "Downloading Repo"

git clone https://github.com/anthonychu/TailwindTraders-Website.git /tailwind
cd /tailwind
git checkout monolith

sleep .5

# install dotnet and npm

wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
dpkg -i packages-microsoft-prod.deb
add-apt-repository universe
apt-get update
apt-get install apt-transport-https
apt-get install dotnet-sdk-2.2=2.2.102-1 -y
curl -sL https://deb.nodesource.com/setup_10.x | sudo -E bash -
sudo apt-get install -y nodejs


#install postgres
apt-get install postgresql postgresql-contrib -y
systemctl enable postgresql
cd ~postgres
sudo -u postgres psql --command "CREATE USER twtadmin WITH PASSWORD 'test101';"
sudo -u postgres createdb testdb


sleep .5

#install mongodb

wget -qO - https://www.mongodb.org/static/pgp/server-4.2.asc | sudo apt-key add -
echo "deb [ arch=amd64 ] https://repo.mongodb.org/apt/ubuntu bionic/mongodb-org/4.2 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb.list
echo "deb [ arch=amd64,arm64 ] https://repo.mongodb.org/apt/ubuntu bionic/mongodb-org/4.2 multiverse" | sudo tee /etc/apt/sources.list.d/mongodb-org-4.2.list
sudo apt-get update
sudo apt-get install -y mongodb-org
sudo systemctl enable mongod
sudo systemctl restart mongod


sleep .5

# Export Vars

export apiUrl=/api/v1
export ApiUrlShoppingCart=/api/v1
export MongoConnectionString="mongodb://localhost:27017/tailwind"
export SqlConnectionString="User ID=twtadmin;Password=test101;Host=localhost;Port=5432;Database=testdb;Pooling=true;Min Pool Size=0;Max Pool Size=100;Connection Lifetime=0;"
export productImagesUrl="https://raw.githubusercontent.com/microsoft/TailwindTraders-Backend/master/Deploy/tailwindtraders-images/product-detail"

sleep .5

# Publish and start application

cd /tailwind/Source/Tailwind.Traders.Web
sudo sed -i 's/http\:\/\/localhost\:5200\/v1/\/api\/v1/' appsettings.json
sudo sed -i 's/http\:\/\/localhost\:3000/\/api\/v1/' appsettings.json
sudo dotnet publish -c Release
sudo dotnet bin/Release/netcoreapp2.1/publish/Tailwind.Traders.Web.dll 1>/dev/null 2>&1 </dev/null &

sleep .5

#nginx

git clone https://github.com/neilpeterson/tailwind-reference-deployment.git
apt-get install nginx -y
service nginx start
rm /etc/nginx/sites-available/default
curl https://raw.githubusercontent.com/neilpeterson/tailwind-reference-deployment/master/deployment-artifacts-standalone-vm/default > /etc/nginx/sites-available/default
nginx -t
nginx -s reload
