#!/bin/bash

export apiUrl=/api/v1
export ApiUrlShoppingCart=/api/v1
export MongoConnectionString="mongodb://{yourmongouser}:{yourmongopassword}@{yourmongohostname}:27017/tailwind"
export SqlConnectionString="Server={yoursqlserverhostname},1433;Initial Catalog=tailwind;Persist Security Info=False;User ID={yoursqluser};Password={yoursqlpassword};Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;"
export productImagesUrl="https://raw.githubusercontent.com/microsoft/TailwindTraders-Backend/master/Deploy/tailwindtraders-images/product-detail"

cd /tailwind/Source/Tailwind.Traders.Web
dotnet bin/Release/netcoreapp2.1/publish/Tailwind.Traders.Web.dll
