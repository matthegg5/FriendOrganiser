# README
A really simple Ruby on Rails app that hosts an example FriendController which is a REST API around a Friend data table, using Active Record for Sqlite3, in this example.

* Ruby version
- 3.3.6
* System dependencies
-- Sqlite3 version 3.45.2

* Configuration
Create a new entity/database table migration: rails g resource <case_sensitive_table_name>


* Database creation \
rails db:create

* Database initialization \
rails db:migrate \
rails db:seed 

(rails db:drop to start over)  

Command to run using port matching Python and C# equivalents:- \
rails server --binding=0.0.0.0 --port=7020
