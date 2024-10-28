Create a data migration

```dotnet ef migrations add InitialCreate --project ./Core/FriendOrganiser.Persistence/FriendOrganiser.Persistence.csproj --startup-project ./API/FriendOrganiser.API/FriendOrganiser.API.csproj```

Run migrations against the database

```dotnet ef database update --project ./Core/FriendOrganiser.Persistence/FriendOrganiser.Persistence.csproj --startup-project ./API/FriendOrganiser.API/FriendOrganiser.API.csproj```