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
    Id: str


class Friend(FriendBase):
    Id: str

    class Config:
        from_attributes = True