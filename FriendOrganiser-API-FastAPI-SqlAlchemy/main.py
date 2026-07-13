from fastapi import FastAPI
from contextlib import asynccontextmanager
from controllers.friend_controller import router as friend_router
from database import engine, Base

@asynccontextmanager
async def lifespan(app: FastAPI):
    # Startup code
    async with engine.begin() as conn:
        await conn.run_sync(Base.metadata.create_all)
    print("Database and tables created (if not already present).")
    yield

app = FastAPI(lifespan=lifespan)

app.include_router(friend_router)

@app.get("/")
def root():
    return {"status": "ok"}