from sqlalchemy import Boolean, Column, ForeignKey, Integer, String, DateTime, Table
from sqlalchemy.orm import relationship, Mapped
from typing import List
from .database import Base


class User(Base):
    __tablename__ = "users"

    user_id = Column(Integer, primary_key=True, index=True)
    username  = Column(String, index=True)
    password = Column(String)
    salt = Column(String)
    high_score = Column(Integer)
    high_score_date = Column(DateTime)

    following = relationship(
        'User', lambda: following,
        primaryjoin=lambda: User.user_id == following.c.follows,
        secondaryjoin=lambda: User.user_id == following.c.followed,
        backref='followers'
    )




following = Table(
    'following', Base.metadata,
    Column('follows', Integer, ForeignKey(User.user_id), primary_key=True),
    Column('followed', Integer, ForeignKey(User.user_id), primary_key=True)
)

