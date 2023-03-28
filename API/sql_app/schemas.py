from typing import List, Union
from sqlalchemy import DateTime
from pydantic import BaseModel
from datetime import date


class UserBase(BaseModel):
    username: str

class UserCreate(UserBase):
    password: str
    salt: str
    pass

    class Config:
        orm_mode = True

class User(UserBase):
    user_id: int
    password: str
    salt: str
    high_score: int | None = None
    high_score_date: date | None = None

    class Config:
        orm_mode = True
        arbitrary_types_allowed = True


class UserLogin(UserBase):
    password: str


class ScoreSchema(BaseModel):
    user_id:int
    score: int

class FollowSchema(BaseModel):
    user_id: int
    follow_id: int