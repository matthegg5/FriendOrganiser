from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.future import select
from models.friend_model import Friend

# Create a friend
async def create_friend(db: AsyncSession, name: str):
    new_user = Friend(name=name)
    db.add(new_user)
    await db.commit()
    await db.refresh(new_user)
    return new_user

# Get friends
async def get_friends(db: AsyncSession, skip: int = 0, limit: int = 10):
    result = await db.execute(select(Friend).offset(skip).limit(limit))
    return result.scalars().all()

# Get friend by ID
async def get_friend_by_id(db: AsyncSession, friend_id: int):
    result = await db.execute(select(Friend).filter(Friend.id == friend_id))
    return result.scalar_one_or_none()
