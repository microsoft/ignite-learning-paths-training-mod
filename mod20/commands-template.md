# Template for commands and secrets

This template can be prepared as described here, and used during the presentations.

Save a copy of this file and replace the expressions in `[]` below according to the notes.

> **IMPORTANT**: Do not commit this file in any Github public repo after you edit it. Connection strings and other secrets should never be committed to a public repository.

## Preparation before the demos:

### Credentials

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
Username: [USERNAME]
Password: [PASSWORD]
```

### Mongo VM connection string

> Replace `[MONGOIP]` with the Public IP address of the MongoDB virtual machine. You can find this value by navigating to the `mod20[prefix]mongovm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

```
mongodb://[MONGOIP]:27017
```

### SQL Server 2012 connection string

> Replace `[SQLIP]` with the Public IP address of the SQL virtual machine. You can find this value by navigating to the `mod20[prefix]sqlvm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
Server=tcp:[SQLIP],1433;Initial Catalog=tailwindsql;Persist Security Info=False;User ID=[USERNAME];Password=[PASSWORD];MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;
```

### Mongo DB VM

> Replace `[MONGOIP]` with the Public IP address of the MongoDB virtual machine. You can find this value by navigating to the `mod20[prefix]mongovm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
ssh [USERNAME]@[MONGOIP]
password: [PASSWORD]
```

### Remote desktop SQL Server VM

> Replace `[SQLIP]` with the Public IP address of the SQL virtual machine. You can find this value by navigating to the `mod20[prefix]sqlvm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
IP address: [SQLIP]
Username: [USERNAME]
Password: [PASSWORD]
```

### Tailwindtraders website

```
Username: cxa@microsoft.com
Password: [any password works]
```

### Azure SQL DB

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
Username: [USERNAME]
Password: [PASSWORD]
```

## Demo 1: MongoDB to CosmosDB migration

### Mongo DB VM

> Replace `[MONGOIP]` with the Public IP address of the MongoDB virtual machine. You can find this value by navigating to the `mod20[prefix]mongovm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
ssh [USERNAME]@[MONGOIP]
password: [PASSWORD]
```

### Tailwindtraders website

```
Username: cxa@microsoft.com
Password: [any password works]
```

### Source connection string

> Replace `[MONGOIP]` with the Public IP address of the MongoDB virtual machine. You can find this value by navigating to the `mod20[prefix]mongocvm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

```
mongodb://[MONGOIP]:27017
```

### Target connection string

> Replace `[COSMOSCONNECTIONSTRING]` with the PRIMARY CONNECTION STRING of the CosmosDB instance. You can find this value by navigating to the `mod20[prefix]mongo` resource in the Azure Portal. The PRIMARY CONNECTION STRING is listed on the Connection String tab.

```
[COSMOSCONNECTIONSTRING]
```

### BAK Mongo DB connection string

> Replace `[BAKCOSMOSCONNECTIONSTRING]` with the PRIMARY CONNECTION STRING of the backup CosmosDB instance. You can find this value by navigating to the `mod20[prefix]mongo-bak` resource in the Azure Portal. The PRIMARY CONNECTION STRING is listed on the Connection String tab.

```
[BAKCOSMOSCONNECTIONSTRING]
```

### Cart item:

> Nothing to replace here

```
{
	"_id" : "5d665a5689c79d19d44b4799",
	"productId" : 99,
	"email" : "cxa@microsoft.com",
	"imageUrl" : "https://github.com/ashleymcnamara/Developer-Advocate-Bit/blob/master/BitDevAdvocate.png?raw=true",
	"name" : "Cloud Advocate Mascot",
	"price" : "999",
	"qty" : 3,
	"id" : "f2729f14-090d-4b40-8e45-e5dcdb58c0a2"
}
```

## Demo 2: SQL to Azure SQL DB migration

### Source SQL

> Replace `[SQLIP]` with the Public IP address of the SQL virtual machine. You can find this value by navigating to the `mod20[prefix]sqlvm` resource in the Azure Portal. The Public IP address is listed on the Overview tab.

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
IP: [SQLIP]
Username: [USERNAME]
Password: [PASSWORD]
```

### Target SQL credentials (for Database migration service)

> Replace `[SQLSERVERNAME]` with the Server name of the Azure SQL database. You can find this value by navigating to the `mod20[prefix]sqldb` resource in the Azure Portal. The Server name is listed on the Overview tab.

> Replace `[USERNAME]` and `[PASSWORD]` with the values prepared [as described here](./01-preparation.md#credentials).

```
Host name: [SQLSERVERNAME]
Username: [USERNAME]
Password: [PASSWORD]
```

### Target SQL Connection string

> Replace `[AZURESQLCONNECTIONSTRING]` with the ADO.NET connection string of the Azure SQL Database instance. You can find this value by navigating to the `mod20[prefix]sqldb` resource in the Azure Portal. The ADO.NET connection string is listed on the Connection strings tab.

> After copying the ADO.NET connection string from the Azure Portal, make sure to replace the placeholder `{your_username}` with the username prepared [as described here](./01-preparation.md#credentials); then replace the placeholder `{your_password}` with the password prepared [as described here](./01-preparation.md#credentials)

```
[AZURESQLCONNECTIONSTRING]
```

### Target BAK SQL Connection string

> Replace `[BAKAZURESQLCONNECTIONSTRING]` with the ADO.NET connection string of the backup Azure SQL Database instance. You can find this value by navigating to the `mod20[prefix]sqldb-bak` resource in the Azure Portal. The ADO.NET connection string is listed on the Connection strings tab.

> After copying the ADO.NET connection string from the Azure Portal, make sure to replace the placeholder `{your_username}` with the username prepared [as described here](./01-preparation.md#credentials); then replace the placeholder `{your_password}` with the password prepared [as described here](./01-preparation.md#credentials)

```
[BAKAZURESQLCONNECTIONSTRING]
```
