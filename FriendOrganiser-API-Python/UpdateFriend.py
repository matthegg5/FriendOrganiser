from flask import jsonify
import ExecuteDatabaseStatement

def command(firstname,lastname,email,id):
	command = "UPDATE friends SET FirstName = %s, LastName = %s, EmailAddress = %s WHERE id = %s"
	params = { "FirstName": firstname, "LastName": lastname, "Email": email, "Id": id }
	result = ExecuteDatabaseStatement.execute_command(command, params)
	return jsonify(result), 200

