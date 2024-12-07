This is a WPF Windows Desktop application that initially followed an online tutorial for the "Friend Organiser" use case, but I extended the tutorial to convert the WPF Desktop App to use an API service for its data persistence instead of local ORM direct to database. I've also recreated the server endpoint in Python using Flask, and Ruby On Rails using Active Record, for no reason whatsoever.

*Buzzwords - UI*\
WPF\
.NET 8.0 C#\
Autofac Dependency Injection container\
Prism EventAggregator (Pub-Sub Events between View Models)\
Model-View-ViewModel (MVVM)\
TPL Async\
WebAPI client

*Buzzwords - API*\
.NET 8.0 C#\
WebAPI Service\
TPL Async\
MediatR\
Automapper\
Fluent Validation\
Command-Query-Responsibility-Segregation\
Entity Framework Core



Frequently used commands (for the .NET backend)\

Create a data migration

```dotnet ef migrations add InitialCreate --project ./Core/FriendOrganiser.Persistence/FriendOrganiser.Persistence.csproj --startup-project ./API/FriendOrganiser.API/FriendOrganiser.API.csproj```

Run migrations against the database

```dotnet ef database update --project ./Core/FriendOrganiser.Persistence/FriendOrganiser.Persistence.csproj --startup-project ./API/FriendOrganiser.API/FriendOrganiser.API.csproj```

(For the Python backend)

Set up a MariaDB instance and use the "create-and-seed-database.sql" file to initialise the database. The connection details can be maintained in the ExecuteDatabaseStatement.py file

(For the Ruby backend)
Version required: 3.3.6

rails db:create
rails db:migrate
rails db:seed
rails server --binding=0.0.0.0 --port=7020
