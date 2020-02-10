## Hints File 

These are commands to run, fill in the location of your location and other details from [deployment.md]

# CREATE YOUR GROUP LIVE - 

az group create --subscription "Ignite the Tour" --name groupname --location eastus

az network vnet create --name ignitemod10vnet --subscription  "Ignite The Tour" --resource-group groupname    --subnet-name default

CREATE VM FROM PORTAL

ssh into VM!!! 

sudo su -  

curl https://raw.githubusercontent.com/microsoft/ignite-learning-paths-training-mod/master/mod10/deploy.sh >deploy.sh

# HAVE YOUR CONNECTION STRINGS READY BEFORE

from [create-db.sh]

```
export SqlConnectionString=
export MongoConnectionString=
```
