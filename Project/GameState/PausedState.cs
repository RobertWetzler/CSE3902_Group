﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.HUD;
using Project.Sound;
using Project.Utilities;
using System.Collections.Generic;

namespace Project.GameState
{
    class PausedState : IGameState
    {
        private Game1 game;
        private IHUD smallHUD;
        private ISprite spriteA, spriteD, spriteE, spriteP, spriteS, spriteU;
        private List<ISprite> textList = new List<ISprite>();
        private int textLinePosX = 420;
        private int textLinePosY = 500;

        int shift = 30;
        public PausedState(Game1 game)
        {
            this.game = game;
            smallHUD = new SmallHUD(false);
            SoundManager.Instance.backgroundInstance.Pause();
            spriteA = TextSpriteFactory.Instance.CreateASprite();
            spriteD = TextSpriteFactory.Instance.CreateDSprite();
            spriteE = TextSpriteFactory.Instance.CreateESprite();
            spriteP = TextSpriteFactory.Instance.CreatePSprite();
            spriteS = TextSpriteFactory.Instance.CreateSSprite();
            spriteU = TextSpriteFactory.Instance.CreateUSprite();

            textList.Add(spriteP);
            textList.Add(spriteA);
            textList.Add(spriteU);
            textList.Add(spriteS);
            textList.Add(spriteE);
            textList.Add(spriteD);
        }

        public void Update(GameTime gameTime, Rectangle bounds)
        {
            PauseController.controller.Update();
            smallHUD.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawingUtilities.DrawGameScreen(spriteBatch, gameTime, smallHUD);
            Game1.Instance.GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            int i = 0;
            foreach (var text in textList)
            {
                text.Draw(spriteBatch, new Vector2(textLinePosX + i, textLinePosY));
                i += shift;
            }
            spriteBatch.End();
        }


    }
}
