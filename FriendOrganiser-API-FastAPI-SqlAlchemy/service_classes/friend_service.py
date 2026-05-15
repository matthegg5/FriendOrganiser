from sqlalchemy.ext.asyncio import AsyncSession
from sqlalchemy.future import select
from models.friend_model import Friend
from schemas import FriendCreate, FriendUpdate

async def create_friend(
    db: AsyncSession,
    friend_create: FriendCreate
):
    new_friend = Friend(
        FirstName=friend_create.FirstName.strip(),
        LastName=friend_create.LastName.strip(),
        EmailAddress=friend_create.EmailAddress.lower()
    )

    db.add(new_friend)

    await db.commit()
    await db.refresh(new_friend)

    return new_friend

async def get_friends(db: AsyncSession, skip: int = 0, limit: int = 10):
    result = await db.execute(select(Friend).offset(skip).limit(limit))
    return result.scalars().all()

async def get_friend_by_id(db: AsyncSession, friend_id: int):
    result = await db.execute(select(Friend).filter(Friend.id == friend_id))
    return result.scalar_one_or_none()

async def update_friend(db: AsyncSession, friend_update: FriendUpdate):
    
    result = await db.execute(
        select(Friend).filter(Friend.Id == friend_update.Id)
    )
    
    friend = result.scalar_one_or_none()

    if friend is None:
        return None

    friend.FirstName = friend_update.FirstName
    friend.LastName = friend_update.LastName
    friend.EmailAddress = friend_update.EmailAddress

    await db.commit()
    await db.refresh(friend)

    return friend
