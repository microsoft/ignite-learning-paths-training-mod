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
apt install npm nodejs -y

sleep .5

# Export Vars

export apiUrl=/api/v1
export ApiUrlShoppingCart=/api/v1
export MongoConnectionString=""
export SqlConnectionString=""

sleep .5

# Publish and start application

cd /tailwind/Source/Tailwind.Traders.Web
dotnet publish -c Release
dotnet bin/Release/netcoreapp2.1/publish/Tailwind.Traders.Web.dll &

sleep .5

#nginx

git clone https://github.com/neilpeterson/tailwind-reference-deployment.git
apt-get install nginx -y
service nginx start
rm /etc/nginx/sites-available/default
curl https://raw.githubusercontent.com/neilpeterson/tailwind-reference-deployment/master/deployment-artifacts-standalone-vm/default > /etc/nginx/sites-available/default
nginx -t
nginx -s reload
