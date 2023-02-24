from typing import List, Union
from sqlalchemy import DateTime
from pydantic import BaseModel


class UserBase(BaseModel):
    name: str

class UserCreate(UserBase):
    pass

    class Config:
        orm_mode = True

class User(UserBase):
    id: int

    class Config:
        orm_mode = True
        arbitrary_types_allowed = True
