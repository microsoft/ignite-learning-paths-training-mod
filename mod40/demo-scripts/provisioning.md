# Tailwind Traders Deploy to Azure Buttons

## Instructions

### Standalone

This method deploys the Tailwind Traders website with a SQL DB and Cosmos DB, and does not depend on backend microservices.

- Select `standalone`
- Ensure you select a region where you're allowed to deploy SQL Databases and App Services, each of those services have restrictions for internal subs.
- Use a short name (< 20 characters), that name is used to generate resource names. Each resource has different naming restrictions. Stick to lower case characters, numbers, and dashes.
- Enter a strong password for SQL, but do NOT use `;` (this is a separator in SQL connection strings)

### Frontend Only

This method deploys the Tailwind Traders website and calls backend services hosted somewhere else.

- Select `frontendOnly`
- You can leave the SQL login information blank


## Buttons

### Microsoft/TailwindTraders-Website ([master](https://github.com/anthonychu/TailwindTraders-Website/tree/monolith) branch)

[![Deploy to Azure](https://azuredeploy.net/deploybutton.svg)](https://deploy.azure.com/?repository=https://github.com/Microsoft/TailwindTraders-Website/tree/master)

This is the master branch in the official repo.

<!--

### anthonychu/TailwindTraders-Website ([add-image-classifier](https://github.com/anthonychu/TailwindTraders-Website/tree/add-image-classifier) branch)

[![Deploy to Azure](https://azuredeploy.net/deploybutton.svg)](https://deploy.azure.com/?repository=https://github.com/anthonychu/TailwindTraders-Website/tree/add-image-classifier)

Includes the new image classifier endpoint.

### anthonychu/TailwindTraders-Website ([monolith](https://github.com/anthonychu/TailwindTraders-Website/tree/monolith) branch)

[![Deploy to Azure](https://azuredeploy.net/deploybutton.svg)](https://deploy.azure.com/?repository=https://github.com/anthonychu/TailwindTraders-Website/tree/monolith)

This includes the changes in the add-debug-info and local-product-images branches.
-->

