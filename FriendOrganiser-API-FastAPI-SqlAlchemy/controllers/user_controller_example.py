# controllers/user_controller.py
from fastapi import APIRouter, HTTPException, Depends
from sqlalchemy.ext.asyncio import AsyncSession
from crud import create_user, get_users, get_user_by_id
from schemas import UserCreate, User
from database import SessionLocal

router = APIRouter()  # This is where we define the controller routes

# Dependency to get DB session
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()

# Create a user (Controller)
@router.post("/users/", response_model=User)
async def create_user_controller(user: UserCreate, db: AsyncSession = Depends(get_db)):
    return await create_user(db=db, name=user.name)

# Get all users (Controller)
@router.get("/users/", response_model=list[User])
async def get_users_controller(skip: int = 0, limit: int = 10, db: AsyncSession = Depends(get_db)):
    return await get_users(db=db, skip=skip, limit=limit)

# Get a user by ID (Controller)
@router.get("/users/{user_id}", response_model=User)
async def get_user_controller(user_id: int, db: AsyncSession = Depends(get_db)):
    user = await get_user_by_id(db=db, user_id=user_id)
    if user is None:
        raise HTTPException(status_code=404, detail="User not found")
    return user
