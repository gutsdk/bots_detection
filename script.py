import requests

file = open("api.txt", "r")

access_token = file.readline()
api_version = "5.199"

file.close()

def get_user_data(user_id, fields):
    response = requests.get(f'https://api.vk.com/method/users.get?user_ids={user_id}&fields={fields}&access_token={access_token}&v={api_version}') 
    return response.json()

user_id = '1'
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
print(user_data)