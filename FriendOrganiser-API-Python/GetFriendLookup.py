from flask import jsonify
import ExecuteDatabaseStatement

def query():
	query = "SELECT id, CONCAT(FirstName,' ',LastName) AS displaymember FROM friends"
	params = []
	result = ExecuteDatabaseStatement.execute_query(query, params)
	return jsonify(result), 200

