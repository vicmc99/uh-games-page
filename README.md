# uh-games-page
Página oficial de los Juegos Caribes


Para realizar una migración utilizar el comando
```
dotnet ef migrations add <migration_name> -p DataAccess/DataAccess.csproj -s Api/Api.csproj
```
Para Eliminar la última migracion 

```
 dotnet ef migrations remove  -p DataAccess/DataAccess.csproj -s Api/Api.csproj

```
Para actualizar la migración 
````
dotnet ef migrations script  
````