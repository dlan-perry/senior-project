from fastapi import Depends, FastAPI, HTTPException, status
from sqlalchemy.orm import Session
import uvicorn
from . import crud, models, schemas
from .database import SessionLocal, engine
from fastapi.security import OAuth2PasswordBearer, OAuth2PasswordRequestForm
from sqlalchemy import Integer
import bcrypt
models.Base.metadata.create_all(bind=engine)

app = FastAPI()

def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()
#staple72

oauth2_scheme = OAuth2PasswordBearer(tokenUrl="token")

async def get_current_user( db: Session = Depends(get_db), token: str = Depends(oauth2_scheme)):
    user = crud.get_user_by_name(db, token)
    if not user:
        raise HTTPException(
            status_code=status.HTTP_401_UNAUTHORIZED,
            detail="Invalid authentication credentials",
            headers={"WWW-Authenticate": "Bearer"},
        )
    return user

async def get_current_active_user(current_user: schemas.User = Depends(get_current_user)):
    if current_user.disabled:
        raise HTTPException(status_code=400, detail="Inactive user")
    return current_user

@app.get("/users/me")
async def read_users_me(current_user: schemas.User = Depends(get_current_active_user)):
    return current_user


@app.post("/users/", response_model=schemas.UserCreate)
def create_user(user:schemas.UserCreate, db: Session= Depends(get_db)):
    salt = bcrypt.gensalt()
    hashed = bcrypt.hashpw(user.password.encode('utf-8'), salt)
    user.password = hashed
    user.salt = salt
    db_user = crud.get_user_by_name(db, user.username)
    if db_user:
        raise HTTPException(status_code=400, detail="Name already registered")
    return crud.create_user(db=db, user=user)

@app.get("/users/{user_id}", response_model=schemas.User)
def read_user(user_id: int, db: Session = Depends(get_db)):
    db_user = crud.get_user(db, user_id=user_id)
    if db_user is None:
        raise HTTPException(status_code=404, detail="User not found")
    return db_user

@app.post("/token")
async def login(form_data:OAuth2PasswordRequestForm = Depends(),  db: Session = Depends(get_db)):
    user = crud.get_user_by_name(db, form_data.username)
    if not user:
        raise HTTPException(status_code=400, detail="Incorrect username or password")
    #hashed_password = bcrypt.hashpw(form_data.password.encode('utf-8'), user.salt)
    if not bcrypt.checkpw(form_data.password.encode('utf-8'), user.password.encode('utf-8')):
        raise HTTPException(status_code=400, detail="Incorrect username or password")

    return {"access_token": user.username, "token_type": "bearer"}

@app.get("/score/{user_id}/{score}")
def score(user_id: int, score: int,db:Session = Depends(get_db)):
    crud.update_score(user_id, score, db)

if __name__ == "__main__":
    uvicorn.run(app, host="127.0.0.1", port=8000)