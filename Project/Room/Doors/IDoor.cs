﻿using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    public interface IDoor : ICollidable
    {
        bool IsClosed { get; }
        bool CanBeBombed { get; set; }
        DoorType DoorType { get; }
        void Draw(SpriteBatch spriteBatch);
    }
}
