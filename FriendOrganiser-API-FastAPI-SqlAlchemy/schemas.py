# schemas.py
from pydantic import BaseModel
from typing import Optional


class FriendBase(BaseModel):
    Id: str
    FirstName: str
    LastName: str
    EmailAddress: str


class FriendCreate(FriendBase):
    pass


class FriendUpdate(FriendBase):
    Id: int


class Friend(FriendBase):
    Id: int

    class Config:
        from_attributes = True