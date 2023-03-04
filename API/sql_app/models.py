from sqlalchemy import Boolean, Column, ForeignKey, Integer, String, DateTime
from sqlalchemy.orm import relationship

from .database import Base


class User(Base):
    __tablename__ = "users"


    user_id = Column(Integer, primary_key=True, index=True)
    username  = Column(String, index=True)
    password = Column(String)
    salt = Column(String)
    high_score = Column(Integer)
    high_score_date = Column(DateTime)

