import MySQLdb
import sys

def execute_query(query, params):
	connection = MySQLdb.connect(
		user="<user_name>",
		password="<password>",
		host="127.0.0.1",
		port=3306,
		database="FriendOrganiser"
	)

	cursor = connection.cursor()

	cursor.execute(query, params)

	rows = cursor.fetchall()

	columns = [desc[0] for desc in cursor.description]

	if len(rows) == 1:
		result = {columns[i]: rows[0][i] for i in range(len(columns))}
		return result

	elif len(rows) > 1:
		results = [
		{columns[i]: row[i] for i in range(len(columns))}
		for row in rows
		]
		return results
	
	# no records returned, return empty list
	return []

	cursor.close()
	connection.close()

def execute_command(command, params):
	try:
		connection = MySQLdb.connect(
		user="<user_name>",
		password="<password>",
		host="127.0.0.1",
		port=3306,
		database="FriendOrganiser"
		)
	
		cursor = connection.cursor()
		
		values = list(params.values())
		
		cursor.execute(command, values)
		connection.commit()
		
		print(f"Command executed successfully")

	except MySQLdb.MySQLError as e:
		print(f"MariaDB Error: {e}")
		connection.rollback()

	finally:
		cursor.close()
		connection.close()
