# models.py
from sqlalchemy import Column, Integer, String
from database import Base  # Make sure 'Base' is correctly imported

class User(Base):
    __tablename__ = "users"

    id = Column(Integer, primary_key=True, index=True)
    name = Column(String, index=True)
