CREATE DATABASE FriendOrganiser;

USE FriendOrganiser;

CREATE TABLE friends (
	id INT NOT NULL,
	FirstName NVARCHAR(255) NULL,
	LastName NVARCHAR(255) NULL,
	EmailAddress NVARCHAR(255) NULL
	);

INSERT INTO friends (id, FirstName, LastName, EmailAddress)
VALUES (1, 'apple', 'banana', 'apple@banana.com'),
(2, 'james', 'tiger', 'james@tiger.com'); 

