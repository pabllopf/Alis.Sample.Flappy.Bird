// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DeathZone.cs
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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component;
using Alis.Core.Ecs.Component.Audio;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity.GameObject;
using Alis.Core.Physic.Dynamics;

namespace Alis.Sample.Flappy.Bird
{
    /// <summary>
    ///     The death zone class
    /// </summary>
    /// <seealso cref="Component" />
    public class DeathZone : Component
    {
        /// <summary>
        ///     The is death
        /// </summary>
        public static bool isDeath;

        /// <summary>
        ///     The time delta
        /// </summary>
        public static float timeDelta = 10.0f;

        /// <summary>
        ///     Ons the init
        /// </summary>
        public override void OnInit()
        {
            isDeath = false;
            timeDelta = 100f;
        }

        /// <summary>
        ///     Ons the update
        /// </summary>
        public override void OnUpdate()
        {
            if (isDeath)
            {
                timeDelta -= 0.01f;
                if (timeDelta <= 0.0f)
                {
                    VideoGame.Instance.SceneManager.LoadScene("Main Menu");
                    Console.WriteLine("RESET LEVEL");
                }
            }
        }

        /// <summary>
        ///     Ons the collision enter using the specified game object
        /// </summary>
        /// <param name="gameObject">The game object</param>
        public override void OnCollisionEnter(IGameObject gameObject)
        {
            if (gameObject.Tag == "Player")
            {
                Console.WriteLine($"Player dead by '{GameObject.Name}'");

                if (gameObject.Contains<BirdController>() && !gameObject.Get<BirdController>().IsDead)
                {
                    gameObject.Get<AudioSource>().AudioClip = new AudioClip(AssetManager.Find("die.wav"));
                    gameObject.Get<AudioSource>().Play();

                    gameObject.Remove(gameObject.Get<BirdController>());
                    Console.WriteLine("Player remove bird controller");

                    gameObject.Get<BoxCollider>().Body.Rotation = 45f;
                    gameObject.Get<BoxCollider>().Body.LinearVelocity = new Vector2(0, 7);
                    gameObject.Get<BoxCollider>().IsTrigger = true;
                    gameObject.Get<BoxCollider>().Body.BodyType = BodyType.Kinematic;

                    gameObject.Remove(gameObject.Get<Animator>());

                    PipelineController.IsStop = true;


                    isDeath = true;
                }
            }
        }
    }
}