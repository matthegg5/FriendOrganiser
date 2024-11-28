# Module requirements: mysqlclient, flask, sqlalchemy (maybe)

from flask import Flask, jsonify, request
import GetFriendsQuery
import GetFriendByIdQuery
import GetFriendLookup
import UpdateFriend

app = Flask(__name__)

@app.route('/api/friend/all', methods=['GET'])
def get_friends():
	return GetFriendsQuery.query()

@app.route('/api/lookup/friend-lookup', methods=['GET'])
def get_lookup():
	return GetFriendLookup.query()

@app.route('/api/friend/<int:friend_id>', methods=['GET'])
def get_friend(friend_id):
	return GetFriendByIdQuery.query(friend_id)
 
@app.route('/api/friend', methods=['PUT'])
def update_friend():
	app.logger.debug(f"Request Body: {request.data}")

	if request.is_json:
		data = request.get_json()
		app.logger.debug(f"Parsed JSON: {data}")
		if data is None:
			return jsonify({"error":"Request body is empty"}), 400

	friend_id = data.get('Id')
	first_name = data.get('FirstName')
	last_name = data.get('LastName')
	email = data.get('Email')
 
	success = UpdateFriend.command(first_name, last_name, email,friend_id)

	if success:
		return jsonify({"message":"Friend updated successfully"}), 200
	else:
		return jsonify({"message": "Failed to update user"}), 500

if __name__ == '__main__':
	app.run(host='0.0.0.0',port=7020,debug=True)
