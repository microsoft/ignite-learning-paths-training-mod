# Deployment

## Getting Started

We'll use these to prep before we go into the session.  Fully build the application at least before the session. Always keep a preview copy ready to go and build what you can as a demonstration live.  You will demonstrate building the databases live, but well remind the audience we're using "cooking show rules."  

Mostly all steps in pre-session will be done again during the demo. We want a version already up & running so you don't need to wait when doing the demo.

Again, you'll be creating the application twice... once completely before the session (just run the create databases script, create the VM and then exectue bash deploy.sh

You will show the process of creating these databases.

- Open your favorite shell. It could be local or shell.azure.com, as long as you have Azure CLI and that you are connected to your subscription. 

Let's start by creating our Resource Group

```
az group create  --name ignitemod10 --location eastus
```

> During the demo you could just do an incremented name is just to keep it easy to follow. What I will create live: resource group creation notes in [hints-for-presentation.md](hints-for-presentation.md)
>
>```
>az group create  --name 001ignitemod10 --location eastus
>```
> 

Create your VNET - You'll do the same incrementing on the name:

```
az network vnet create --name ignitemod10vnet  --resource-group groupname --subnet-name default

```


## Creating Resource Group and Databases.

Ensure you have cloned this repository already as per the instructions in the main [README](https://github.com/microsoft/ignite-learning-paths-training-mod#do-the-demos) so you have the scripts locally and can edit them.

Within [create-db.sh](https://github.com/microsoft/ignite-learning-paths-training-mod/blob/master/mod10/create-db.sh) there are a few bash variables to change.

```
#!/bin/bash
set -e

# Credentials
azureResourceGroup=ignitemod10
adminUser=twtadmin
adminPassword=__STRONGPASSWORD__
subname=__MySubscriptionName__
location=eastus

# DB Name

cosmosdbname=apps30twtnosql
sqldbname=apps30twtsql
```

I do the same incrementing of the name for the "live" version.  I create these before hand but then demonstrate how to create from portal.  The versions I do from portal I do not "deploy" - before I "create and deploy" I explain for time we've already created our DB's with Azure SQL and Cosmos DB.

Example:

Live Version - 

```
#!/bin/bash
set -e

# Credentials
azureResourceGroup=ignitemod10
adminUser=example
adminPassword=__STRONGPASSWORD__
subname=__MySubscriptionName__
location=eastus

# DB Name

cosmosdbname=001apps30twtnosql
sqldbname=001apps30twtsql
```

Once you've edited the script, execute it.

```
bash create-db.sh
```

This should take about 15 minutes for both DBs to create.

> !! Note both connection strings `MongoConnectionString` and `SqlConnectionString`. We will need them later in our deployment script. Note that the SQL connection string will have placeholders for the user ID and password - make sure to replace them with the 'adminUser' and 'adminPassword' (in a production scenario _do not_ use admin credentials like this!)

## Creating the Web Server VM

Live, you'll want to create the VM using the steps in [demo.md](./demo.md) for portal VM creation - before though you'll want to use this:

```
az vm create  --resource-group ignitemod10 --name twtweb --public-ip-address-dns-name twtweb --image UbuntuLTS --admin-username ubuntu --generate-ssh-keys --vnet-name ignitemod10vnet --size Standard_DS3_v2
```

Open Network Ports to allow web and SSH traffic

```
az vm open-port  --resource-group ignitemod10 --name twtweb --port 80 --priority "201" --subsscription "Ignite the Tour

az vm open-port  --resource-group ignitemod10 --name twtweb --port 443 --priority "202" --subsscription "Ignite the Tour

az vm open-port  --resource-group ignitemod10 --name twtweb --port 22  --priority "203" --subsscription "Ignite the Tour
```

## SSH in and begin installing our dependencies

Once the VM is up and running you will need to connect to it to copy the code. We will achieve this by 
using SSH (the VM is running Linux Ubuntu). You can get the ssh command via the Azure Portal by clicking the *Connect* button in the VM blade. Execute it in your shell.

```bash
ssh ubuntu@twtweb.eastus.cloudapp.azure.com
```

Once connected you should get a greeting message like this: 

> Welcome to Ubuntu 18.04.3 LTS (GNU/Linux 5.0.0-1027-azure x86_64)

## Update and execute the Deployment script

The next step is to download the deployment script to the VM, update it, and finally execute it as super user. This script will clone the web application content from GitHub and install NGINX as the web server.

To elevate the current user as super and get the script `deploy.sh` execute the following commands.

```bash
sudo su
curl https://raw.githubusercontent.com/microsoft/ignite-learning-paths-training-mod/master/mod10/deploy.sh >deploy.sh
```

Now, remember the connectionstrings `MongoConnectionString` and `SqlConnectionString` you noted? It's time to use them. You need to open `deploy.sh` update lines 28/29, and set `MongoConnectionString` and `SqlConnectionString` equal to the value return noted.

> To edit in a Linux VM you can use nano (or any editor available if your prefer). Execute `nano deploy.sh` with the arrows navigate thru the document and update the values. When ready use [Ctrl+X], to exit. Confirm that you want to save and that the name of the file is indeed `deploy.sh`.

It should look like:

```bash
export SqlConnectionString="Server=tcp:mod10twtsql.database.windows.net,1433;Database=tailwind;User ID=__USERNAME__;Password=__PASSWORD__;Encrypt=true;Connection Timeout=30;"
export MongoConnectionString="mongodb://mod10twtnosql:xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx==@mod10twtnosql.documents.azure.com:10255/?ssl=true&replicaSet=globaldb"
```

The script is ready, execute it with:

```bash
bash deploy.sh
```

This should take a few minutes to complete.

You have now deployed all the resources required to do the demos. The only step missing, if you did not already do it is to prepare a version of 'create-db.sh' for the live demo.  


## Final

Go through the opening of the talk with the application fully built in the background.  Keep two portals up, one with the "complete" version of the app, one of the resource group you're going to build live.  You'll want to show them the difference and how you're creating the resources live as you're explaining each part.
