import requests

url = "http://127.0.0.1:8000/token"

payload={'username': 'Dylan',
'password': 'test'}
files=[

]
headers = {}

response = requests.request("POST", url, headers=headers, data=payload, files=files)

print(response.text)