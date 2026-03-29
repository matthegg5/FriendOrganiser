# controllers/user_controller.py
from fastapi import APIRouter, HTTPException, Depends
from sqlalchemy.ext.asyncio import AsyncSession
from service_classes.friend_service import create_friend, get_friend_by_id, get_friends
from schemas import FriendCreate, Friend
from database import AsyncSessionLocal, get_db

router = APIRouter()  # This is where we define the controller routes

# Create a friend (Controller)
@router.post("/friend/", response_model=Friend)
async def create_friend_controller(friend: FriendCreate, db: AsyncSession = Depends(get_db)):
    return await create_friend(db=db, first_name=friend.FirstName, last_name=friend.LastName, email=friend.EmailAddress)

# Get all friends (Controller)
@router.get("/friend/", response_model=list[Friend])
async def get_friends_controller(skip: int = 0, limit: int = 10, db: AsyncSession = Depends(get_db)):
    return await get_friends(db=db, skip=skip, limit=limit)

# Get a friend by ID (Controller)
@router.get("/friend/{friend_id}", response_model=Friend)
async def get_friend_controller(friend_id: int, db: AsyncSession = Depends(get_db)):
    user = await get_friend_by_id(db=db, friend_id=friend_id)
    if user is None:
        raise HTTPException(status_code=404, detail="Friend not found")
    return user
