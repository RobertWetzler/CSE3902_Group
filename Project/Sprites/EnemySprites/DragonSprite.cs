﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sound;
using System.Collections.Generic;

namespace Project
{
    class DragonSprite : ISprite
    {
        private Texture2D dragonSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        private int animationCounter;
        private int animationDelay;
        public bool oneCycleFinished { get; private set; }

        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public DragonSprite(Texture2D dragonSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.dragonSpriteSheet = dragonSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.animationCounter = 0;
            this.animationDelay = 150;
            oneCycleFinished = false;
            SoundManager.Instance.CreateBossScream();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dragonSpriteSheet, destRectangle, source, color);
        }
        public void Update(GameTime gameTime)
        {
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                currentFrame++;
                if (currentFrame >= 2 && !oneCycleFinished)
                {
                    oneCycleFinished = true;
                }
                currentFrame %= sourceFrames.Count;
            }

        }
    }
}
