from flask import jsonify
import ExecuteDatabaseStatement

def query(friend_id):
	query = "SELECT id AS Id, FirstName, LastName, EmailAddress AS Email FROM friends WHERE id = %s"
	result = ExecuteDatabaseStatement.execute_query(query, (friend_id,))
	return jsonify(result), 200
