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
