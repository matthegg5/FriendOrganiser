from sqlalchemy import Column, Integer, String
from database import Base

class Friend(Base):
    __tablename__ = "Friend"

    id = Column(Integer, primary_key=True, index=True)
    FirstName = Column(String, index=True)
    LastName = Column(String, index=True)
    EmailAddress = Column(String, index=True)
