from flask import jsonify
import ExecuteDatabaseStatement

def query():
	query = "SELECT id, FirstName, LastName, EmailAddress AS Email FROM friends"
	params = []
	result = ExecuteDatabaseStatement.execute_query(query, params)
	return jsonify(result), 200

