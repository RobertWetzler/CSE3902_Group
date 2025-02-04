﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System.Collections.Generic;

namespace Project
{
    class SnakeEnemySprite : ISprite
    {
        private Texture2D snakeSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        SpriteEffects spriteEffects;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public SnakeEnemySprite(Texture2D snakeSpriteSheet, List<Rectangle> sourceFrames, Facing dir)
        {
            this.snakeSpriteSheet = snakeSpriteSheet;
            this.sourceFrames = sourceFrames;
            switch (dir)
            {
                case Facing.Right:
                    spriteEffects = SpriteEffects.None;
                    break;
                case Facing.Left:
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle(
              (int)position.X, (int)position.Y,
                source.Width * 4, source.Height * 4);
            spriteBatch.Draw(snakeSpriteSheet, destRectangle, source, color, 0f, Vector2.Zero, spriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                currentFrame++;
                currentFrame %= sourceFrames.Count;
            }
        }
    }
}
