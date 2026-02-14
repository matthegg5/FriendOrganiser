# crud.py
from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.future import select
from models import User

# Create a user
async def create_user(db: AsyncSession, name: str):
    new_user = User(name=name)
    db.add(new_user)
    await db.commit()
    await db.refresh(new_user)
    return new_user

# Get users
async def get_users(db: AsyncSession, skip: int = 0, limit: int = 10):
    result = await db.execute(select(User).offset(skip).limit(limit))
    return result.scalars().all()

# Get user by ID
async def get_user_by_id(db: AsyncSession, user_id: int):
    result = await db.execute(select(User).filter(User.id == user_id))
    return result.scalar_one_or_none()
