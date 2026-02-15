# main.py
from fastapi import FastAPI
from controllers.friend_controller import router as friend_router

app = FastAPI()

# Include the User controller routes
app.include_router(friend_router)

@app.get("/")
def root():
    return {"status": "ok"}
