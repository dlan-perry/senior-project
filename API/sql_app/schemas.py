from typing import List, Union
from sqlalchemy import DateTime
from pydantic import BaseModel


class UserBase(BaseModel):
    name: str

class UserCreate(UserBase):
    pass

class User(UserBase):
    id: int
    topScore: int | None = None
    scoreDate: DateTime | None = None 

    class Config:
        orm_mode = True
