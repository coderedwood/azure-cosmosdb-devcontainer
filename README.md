# azure_cosmosdb_practice_devcontainer
## Commands
```
az login
```
```
az group create --location eastus2 --name az-204--cosmosdb-rg-237
```
```
az cosmosdb create --name az204-cosmosdb-practice --resource-group az-204--cosmosdb-rg-237
```
### Copy Json output and note the document endpoint value contained within
```
az cosmosdb keys list --name az204-cosmosdb-practice --resource-group az-204--cosmosdb-rg-237
```
### Copy the json output and make note of the keys

```
mkdir az204-cosmos
```
```
cd az204-cosmos
```
```
dotnet new console
```
```
dotnet add package Microsoft.Azure.Cosmos
```
### Use the data explorer in the browser to try add the new item below to the container in the cosmosdb and save
```
{
"id": "1",
"category": "personal",
"name": "groceries",
"description": "Pick up apples and strawberries.",
"isComplete": false
}
```
### Delete the resource group when finished to avoid any charges.

```
az group delete --name az-204--cosmosdb-rg-237 --no-wait -y
```