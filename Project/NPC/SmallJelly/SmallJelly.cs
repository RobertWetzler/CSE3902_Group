﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.SmallJelly
{
    class SmallJelly : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public SmallJelly()
        {
            currentState = new SmallJellyWalkEast(this);
            xPos = 400;
            yPos = 100;
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}