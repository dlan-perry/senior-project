from sqlalchemy.orm import Session
from . import models, schemas, database
from datetime import date
from fastapi import HTTPException, status
from typing import Optional
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

def update_score( user_id: int, score: int, db: Session):
    db_user = db.query(models.User).filter(models.User.user_id==user_id).first()
    db_user.high_score = score
    db_user.high_score_date = date.today()
    db.commit()


def get_followers():
    db = database.SessionLocal()
    db_user = db.query(models.User).filter(models.User.user_id==2).first()
    db.commit()
    db.close()

def toggle_following(user_id: int, user_following: int, db: Session):
    db_user= db.query(models.User).filter(models.User.user_id==user_id).first()
    db_follower = db.query(models.User).filter(models.User.user_id==user_following).first()
    found = None
    for x, follower in enumerate(db_user.following):
        if follower.user_id == db_follower.user_id:
            found = [follower, x]
    
    if found:
        print("found it, and removing")
        db_user.following.pop(found[1])
        db.commit()
        return status.HTTP_202_ACCEPTED
    else:
        try:
            db_user.following.append(db.query(models.User).filter(models.User.user_id==user_following).first())
        except:
            return status.HTTP_400_BAD_REQUEST
        db.commit()
        return status.HTTP_201_CREATED
    


def get_top_scores(user_id: Optional[int], db: Session):
    top_ten = []
    if user_id:
        db_user= db.query(models.User.following).filter(models.User.user_id==user_id).order_by(models.User.high_score.desc()).limit(10)
        for user in db_user:
            print([user, user.username, user.user_id])
            top_ten.append([user.username, user.high_score])

    else:
        results = db.query(models.User).order_by(models.User.high_score).limit(10)
        for result in results:
            print([result, result.username, result.user_id])
            top_ten.append([result, result.username, result.user_id])
        
    return top_ten

        


