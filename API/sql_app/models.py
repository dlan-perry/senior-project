from sqlalchemy import Boolean, Column, ForeignKey, Integer, String, DateTime
from sqlalchemy.orm import relationship

from .database import Base


class User(Base):
    __tablename__ = "users"


    id = Column(Integer, primary_key=True, index=True)
    name  = Column(String, index=True)
    topScore = Column(Integer, index=True)
    scoreDate = Column(DateTime(timezone=True), index=True)