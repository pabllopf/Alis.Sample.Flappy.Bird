// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BirdIdle.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math;
using Alis.Core.Ecs.Component;
using Alis.Core.Physic;
using Vector2 = Alis.Core.Aspect.Math.Vector.Vector2;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The bird idle class
    /// </summary>
    /// <seealso cref="AComponent" />
    public class BirdIdle : AComponent
    {
        /// <summary>
        ///     The range movement
        /// </summary>
        private const float RangeMovement = 10.0f;
        
        /// <summary>
        ///     The velocity
        /// </summary>
        private const float Velocity = 55f;
        
        /// <summary>
        ///     The default position
        /// </summary>
        private Vector2 defaultPosition;
        
        /// <summary>
        ///     The go down
        /// </summary>
        private bool goDown;
        
        /// <summary>
        ///     The go up
        /// </summary>
        private bool goUp = true;
        
        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            defaultPosition = GameObject.Transform.Position;
        }
        
        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            // get the x position of game object:
            float x = GameObject.Transform.Position.X;
            
            // get the y position of game object:
            float y = GameObject.Transform.Position.Y;
            
            Vector2 scale = GameObject.Transform.Scale;
            
            Rotation rotation = GameObject.Transform.Rotation;
            
            // create a new position:
            Vector2 newPosition;
            
            if (goUp && !goDown)
            {
                float displace = Velocity * Context.TimeManager.DeltaTime;
                newPosition = new Vector2(x, y - displace);
                Transform transform = new Transform
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };
                
                GameObject.Transform = transform;
            }
            else if (goDown && !goUp)
            {
                float displace = Velocity * Context.TimeManager.DeltaTime;
                newPosition = new Vector2(x, y + displace);
                Transform transform = new Transform
                {
                    Position = newPosition,
                    Rotation = rotation,
                    Scale = scale
                };
                
                GameObject.Transform = transform;
            }
            
            if (y < defaultPosition.Y - RangeMovement)
            {
                goUp = false;
                goDown = true;
            }
            
            if (y > defaultPosition.Y + RangeMovement)
            {
                goUp = true;
                goDown = false;
            }
        }
    }
}