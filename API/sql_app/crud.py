from sqlalchemy.orm import Session
from . import models, schemas

def get_user(db: Session, user_id: int):
    return db.query(models.User).filter(models.User.id==user_id).first()

def get_user_by_name(db: Session, user_name: str):
    return db.query(models.User).filter(models.User.name==user_name).first()

def create_user(db: Session, user:schemas.UserCreate):
    db_user = models.User(name = user.name)
    db.add(db_user)
    db.commit()
    db.refresh(db_user)
    return db_user
