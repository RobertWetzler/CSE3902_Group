﻿using Microsoft.Xna.Framework;
using Project.Rooms.Doors;
using Project.Sound;
using Project.Utilities;

namespace Project.Collision.CollisionHandlers.Doors
{
    class DoorPlayerCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable doorCollidable, ICollidable playerCollidable, CollisionSide side)
        {
            IDoor door = doorCollidable as IDoor;
            IPlayer player = playerCollidable as IPlayer;
            if (door.DoorType == DoorType.KEY_CLOSED && player.Inventory.GetItemCount(ItemType.Key) > 0)
            {
                HandleUnlock(player, door);
            }
            else if (door.IsClosed)
            {
                new PlayerBlockCollisionHandler().HandleCollision(playerCollidable, doorCollidable, CollisionUtils.Opposite(side));
            }
            else if (IsPlayerHittingEdge(player) || door is HiddenDoor)
            {
                switch (door)
                {
                    case NorthDoor northDoor:
                        Game1.Instance.GameStateMachine.RoomTransition(GameState.Direction.Up);
                        break;
                    case SouthDoor southDoor:
                        Game1.Instance.GameStateMachine.RoomTransition(GameState.Direction.Down);
                        break;
                    case EastDoor eastDoor:
                        Game1.Instance.GameStateMachine.RoomTransition(GameState.Direction.Right);
                        break;
                    case WestDoor westDoor:
                        Game1.Instance.GameStateMachine.RoomTransition(GameState.Direction.Left);
                        break;
                    case HiddenDoor hiddenDoor:
                        Game1.Instance.GameStateMachine.RoomTransition(GameState.Direction.Right);
                        break;
                }
            }
        }
        private bool IsPlayerHittingEdge(IPlayer player)
        {
            Rectangle roomBounds = RoomManager.Instance.CurrentRoom.Background.Bounds;
            return !roomBounds.Contains(player.BoundingBox.Center);
        }
        private void HandleUnlock(IPlayer player, IDoor door)
        {
            door.Unlock();
            player.Inventory.RemoveItem(ItemType.Key);
            SoundManager.Instance.CreateDoorUnlockSound();
        }
    }
}
