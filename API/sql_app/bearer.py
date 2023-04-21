from fastapi import Request, HTTPException
from fastapi.security import HTTPBearer, HTTPAuthorizationCredentials

from .auth import decodeJWT


class JWTBearer(HTTPBearer):

    def __init__(self, auto_error: bool=True):
        super(JWTBearer, self).__init__(auto_error=auto_error)

    async def __call__(self, request: Request):
        
        credentials: HTTPAuthorizationCredentials = await super(JWTBearer, self).__call__(request)
        print(credentials.scheme)
        if credentials:
            if not credentials.scheme == "Bearer":
                print("Bad Auth")
                raise HTTPException(status_code=403, detail="Invalid Authentication")
            if not self.verify_jwt(credentials.credentials):
                print("Not valid token")
                raise HTTPException(status_code=403, detail="Invalid token or Expried Token.")
            return credentials.credentials
        else:
            raise HTTPException(status_code=403, detail="Invalid Authorization Code")
        

    
    def verify_jwt(self, jwtoken: str) -> bool:
        isTokenValid: bool = False

        try:
            payload = decodeJWT(jwtoken)
        except:
            payload = None
        
        if payload:
            isTokenValid = True
            print(payload)
        
        return isTokenValid