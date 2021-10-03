﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Goriya
{
    class Goriya : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Goriya()
        {
            currentState = new GoriyaWalkEast(this);
            xPos = 400;
            yPos = 100;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}