﻿using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Commands.PlayerCommandClasses.WeaponCommands;

namespace Project.Utilities
{

    public static class ControllerUtilities
    {

        public static KeyboardController GetKeyboardController(Game1 game)
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

            //Key to show HUD
            keyboardController.RegisterCommand(Keys.V, new SelectItemCommand(game));

            //Cycle Items in the item selector box
            keyboardController.RegisterCommand(Keys.F, new ItemSelectionCommand(game));

            keyboardController.RegisterCommand(Keys.I, new TestRoomTransitionUpCommand(game));
            keyboardController.RegisterCommand(Keys.J, new TestRoomTransitionLeftCommand(game));
            keyboardController.RegisterCommand(Keys.K, new TestRoomTransitionDownCommand(game));
            keyboardController.RegisterCommand(Keys.L, new TestRoomTransitionRightCommand(game));

            //A and B items
            keyboardController.RegisterCommand(Keys.Z, new PlayerUseItemACommand());
            keyboardController.RegisterCommand(Keys.X, new PlayerUseItemBCommand());

            //Set A & B items
            keyboardController.RegisterCommand(Keys.B, new GetAItemCommand(game));
            keyboardController.RegisterCommand(Keys.G, new GetBItemCommand(game));

            //Toggle shader
            keyboardController.RegisterCommand(Keys.T, new ToggleShaderCommand());

            return keyboardController;
        }

    }
}
