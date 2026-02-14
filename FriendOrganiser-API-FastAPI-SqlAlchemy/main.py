# main.py
from fastapi import FastAPI
from controllers.user_controller_example import router as user_router

app = FastAPI()

# Include the User controller routes
app.include_router(user_router)

@app.get("/")
def root():
    return {"status": "ok"}
