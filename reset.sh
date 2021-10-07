rm db/app.db
rm -rf Migrations
dotnet ef migrations add Initial
dotnet ef database update
sqlite3 db/app.db ".schema" > sql/schema.sql
sqlite3 db/app.db "insert into users (username) values ('bob')"
sqlite3 db/app.db "insert into users (username) values ('amy')"
sqlite3 db/app.db "insert into users (username) values ('alice')"
sqlite3 db/app.db "insert into messages (fromuserid, touserid, text) values (1, 2, 'hello')"
sqlite3 db/app.db "insert into messages (fromuserid, touserid, text) values (1, 2, 'hey')"
sqlite3 db/app.db "insert into messages (fromuserid, touserid, text) values (1, 3, 'hi')"
sqlite3 db/app.db "insert into messages (fromuserid, touserid, text) values (2, 3, 'morning')"
sqlite3 db/app.db "insert into messages (fromuserid, touserid, text) values (2, 3, 'night')"
