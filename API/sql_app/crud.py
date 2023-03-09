from sqlalchemy.orm import Session
from . import models, schemas

def get_user(db: Session, user_id: int):
    return db.query(models.User).filter(models.User.user_id==user_id).first()

def get_user_by_name(db: Session, user_name: str):
    return db.query(models.User).filter(models.User.username==user_name).first()



def create_user(db: Session, user:schemas.UserCreate):
    db_user = models.User(username = user.username, password = user.password, salt = user.salt)
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    return db_user
