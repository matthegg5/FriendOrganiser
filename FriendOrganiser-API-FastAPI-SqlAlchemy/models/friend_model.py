from sqlalchemy import Column, Integer, String
from database import Base
from uuid6 import uuid7

class Friend(Base):
    __tablename__ = "friends"

    Id = Column(String, primary_key=True, default=lambda: str(uuid7()))

    FirstName = Column(String)
    LastName = Column(String)
    EmailAddress = Column(String, unique=True)
