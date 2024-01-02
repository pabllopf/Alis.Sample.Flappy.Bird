// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: BirdController.cs
// 
//  Author: Pablo Perdomo Falcón
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

using System;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The bird controller class
    /// </summary>
    /// <seealso cref="Component" />
    public class BirdController : Component
    {
        /// <summary>
        ///     The audio source
        /// </summary>
        private AudioSource audioSource;

        /// <summary>
        /// The box collider
        /// </summary>
        private BoxCollider boxCollider;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            audioSource = GameObject.Get<AudioSource>();
            boxCollider = GameObject.Get<BoxCollider>();
        }

        /// <summary>
        ///     Ons the press key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        public override void OnPressKey(SdlKeycode key)
        {
            if (key == SdlKeycode.SdlkSpace)
            {
                boxCollider.Body.LinearVelocity = new Vector2(0, -17f);
                Console.WriteLine("Go up!");
            }
        }
    }
}