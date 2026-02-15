# schemas.py
from pydantic import BaseModel

class FriendBase(BaseModel):
    FirstName: str
    LastName: str
    EmailAddress: str

class FriendCreate(FriendBase):
    pass

class Friend(FriendBase):
    FirstName: str
    LastName: str
    EmailAddress: str

    class Config:
        orm_mode = True
