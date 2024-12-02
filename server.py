import requests
from flask import Flask, jsonify, request

app = Flask(__name__)

file = open("api.txt", "r")

access_token = file.readline()
api_version = "5.199"

file.close()

def get_user_data(user_id, fields):
    response = requests.get(f'https://api.vk.com/method/users.get?user_ids={user_id}&fields={fields}&access_token={access_token}&v={api_version}') 
    return response.json()

@app.route('/get_user_info', methods=['GET'])
def get_user_info():
    user_id = request.args.get('user_id')
    user_fields = (
                    "activities,about,books,bdate,"
                    "career,connections,contacts,city,domain,education,exports,"
                    "followers_count,has_photo,has_mobile,home_town,"
                    "sex,schools,screen_name,status,verified,games,interests,"
                    "last_seen,maiden_name,"
                    "military,movies,music,nickname,occupation,online,personal,"
                    "relation,relatives,timezone,tv,"
                    "universities,is_verified,counters")
    user_data = get_user_data(user_id, user_fields)

    if "error" in user_data:
        return jsonify({"error" : user_data["error"]["error_msg"]}), 400
    return jsonify(user_data)
    
if __name__ == '__main__':
    app.run(debug=True, host='0.0.0.0', port=5000)  # Сервер будет доступен на http://localhost:5000