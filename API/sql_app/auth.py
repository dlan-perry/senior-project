import time
from typing import Dict

import jwt
from decouple import config
from fastapi import Request
import os
import binascii 

binascii.hexlify(os.urandom(24))



JWT_SECRET = "123" #config("secret")
JWT_ALGORITHM = "HS256" #config("algorithm")

def token_response(token: str):
    return {
        "access_token": token
    }


def signJWT(user_id: int) -> Dict[int,str]:
    payload = {
        "user_id": user_id,
        "expires": time.time()  + 600
    }

    token = jwt.encode(payload, JWT_SECRET, algorithm=JWT_ALGORITHM)
    print("signed")
    return token_response(token)


def decodeJWT(token: str) -> dict:
    try:
        decoded_token = jwt.decode(token, JWT_SECRET, algorithms=[JWT_ALGORITHM])
        return decoded_token if decoded_token["expires"] > time.time() else None
    except:
        return {}
    



def token_from_request(req: Request):
    print("here")
    info_from_request = decodeJWT(req.headers["authorization"].split()[-1])
    print("out")
    return info_from_request
    pass

def check_expiration(tte):
    if time.time() - tte < 600:
        return False
    return True
