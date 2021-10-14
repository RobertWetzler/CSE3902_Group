﻿using Microsoft.Xna.Framework.Input;
using Project.Factory;
using Project.NPC.Merchant;
using Project.NPC.OldMan;
using Project.NPC.Flame;
using Project.Sprites.BlockSprites;
using Project.Sprites.ItemSprites;
using System.Collections.Generic;
using Project.Items;

namespace Project.Utilities
{
    public static class Sprint2Utilities
    {
        public static void SetBlockList(List<IBlock> blocks)
        {
            blocks.Add(BlockSpriteFactory.Instance.CreatePlainBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreatePyramidBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateRightFacingDragonBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLeftFacingDragonBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBlackBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateDottedBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateDarkBlueBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateStairBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateBrickBlockSprite());
            blocks.Add(BlockSpriteFactory.Instance.CreateLayeredBlockSprite());
        }

        public static void SetItemList(List<IItems> items)
        {
            items.Add(new Fairy());
            items.Add(new Arrow());
            items.Add(new BlueArrow());
            items.Add(new Boomerang());
            items.Add(new BlueBoomerang());
            items.Add(new Bomb());
            items.Add(new Heart());
            items.Add(new Bow());
            items.Add(new Sword());
            items.Add(new WhiteSword());
            items.Add(new Meat());
            items.Add(new Ring());
            items.Add(new BlueRing());
            items.Add(new Bottle());
            items.Add(new BlueBottle());
            items.Add(new HeartContainer());
            items.Add(new Candle());
            items.Add(new BlueCandle());
            items.Add(new OneRupee());
            items.Add(new FiveRupee());
            items.Add(new Key());
            items.Add(new Flute());
            items.Add(new Clock());
            items.Add(new Compass());
            items.Add(new Map());
        }
        public static void SetKeyboardControllers(List<IController> controllers, Game1 game)
        {
            KeyboardController keyboardController = new KeyboardController();

            //Register player damage command
            keyboardController.RegisterCommand(Keys.E, new PlayerDamageCommand(game));

            //Register both WASD and Arrows
            ICommand upCommand = new PlayerMoveUpCommand(game);
            keyboardController.RegisterCommand(Keys.W, upCommand);
            keyboardController.RegisterCommand(Keys.Up, upCommand);

            ICommand leftCommand = new PlayerMoveLeftCommand(game);
            keyboardController.RegisterCommand(Keys.A, leftCommand);
            keyboardController.RegisterCommand(Keys.Left, leftCommand);

            ICommand rightCommand = new PlayerMoveRightCommand(game);
            keyboardController.RegisterCommand(Keys.D, rightCommand);
            keyboardController.RegisterCommand(Keys.Right, rightCommand);

            ICommand downCommand = new PlayerMoveDownCommand(game);
            keyboardController.RegisterCommand(Keys.S, downCommand);
            keyboardController.RegisterCommand(Keys.Down, downCommand);

            ICommand swordCommand = new PlayerUseSwordCommand(game);
            keyboardController.RegisterCommand(Keys.Z, swordCommand); //Use sword with Z
            keyboardController.RegisterCommand(Keys.N, swordCommand); //Use sword with N

            keyboardController.RegisterCommand(Keys.D1, new PlayerUseBombCommand(game)); //Use bomb with 1
            keyboardController.RegisterCommand(Keys.D2, new PlayerUseArrowCommand(game)); //Use arrow with 2
            keyboardController.RegisterCommand(Keys.D3, new PlayerUseBlueArrowCommand(game)); //Use blue arrow with 3
            keyboardController.RegisterCommand(Keys.D4, new PlayerUseBoomerangCommand(game)); //Use boomerang with 4
            keyboardController.RegisterCommand(Keys.D5, new PlayerUseBlueBoomerangCommand(game)); //Use blue boomerang with 5
            keyboardController.RegisterCommand(Keys.D6, new PlayerUseFlameCommand(game)); //Use flame with 6

            //Register reset and quit command
            ICommand resetCommand = new ResetCommand(game);
            keyboardController.RegisterCommand(Keys.R, resetCommand);
            keyboardController.RegisterCommand(Keys.Q, new QuitCommand(game));

            //Register idle command as default
            keyboardController.RegisterDefaultCommand(new PlayerStopMovingCommand(game));

            //Cycle thru sprites commands
            keyboardController.RegisterCommand(Keys.T, new GetPreviousBlockCommand(game));
            keyboardController.RegisterCommand(Keys.Y, new GetNextBlockCommand(game));
            keyboardController.RegisterCommand(Keys.O, new GetPreviousEnemyCommand(game));
            keyboardController.RegisterCommand(Keys.P, new GetNextEnemyCommand(game));
            keyboardController.RegisterCommand(Keys.I, new GetPreviousItemCommand(game));
            keyboardController.RegisterCommand(Keys.U, new GetNextItemCommand(game));

            controllers.Add(keyboardController);
        }
        public static void SetNPCList(List<INPC> npcsList)
        {
            npcsList.Add(new Flame());
            npcsList.Add(new OldMan());
            npcsList.Add(new Merchant());
        }
    }
}
