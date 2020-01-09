﻿using GameEngine.GameData;
using GameEngine.GameObjects;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GameEngine.Systems.Main
{
    public static class SystemManager
    {
        // List of all systems used
        private static List<AbstractSystem> _systems = new List<AbstractSystem>();
        public static float deltaTime;
        public static GameObjectList gameObjects { get => GameObjectManager.gameObjects; }

        public static bool[,,] map = new bool[65, 65, 20];
        public static bool[,,] rm = new bool[65, 65, 20];

        public static Vector3 player = new Vector3(0, 0, 0);

        public static void Initialize()
        {
            //map = CaveGenerator.Generate(50, 50, 50);

            // Добавляем системы в движок и инициализируем их   
            RegisterSystem(new InputSystem());
            RegisterSystem(new SpawnerSystem());
            RegisterSystem(new LifetimeSystem());
            RegisterSystem(new ParticleSystem());
            RegisterSystem(new StatsSystem());
            RegisterSystem(new AISystem());
            RegisterSystem(new EntitySystem());
            RegisterSystem(new UISystem());
            RegisterSystem(new RenderSystem());
            InitializeSystems();
        }

        public static void InitializeSystems()
        {
            foreach (AbstractSystem system in _systems)
            {
                system.Initialize();
            }
        }

        public static void Update()
        {
            foreach (AbstractSystem system in _systems)
            {
                if (system.GetType() != typeof(RenderSystem))
                    system.Update();
            }
            Camera.Update();
        }

        public static void DestroyObject(GameObject obj)
        {
            for (int i = 0; i < SystemManager.gameObjects.Count; i++)
                if (SystemManager.gameObjects[i] == obj)
                {
                    SystemManager.gameObjects.RemoveAt(i);
                    break;
                }
        }

        public static void DestroyObject(int index)
        {
            SystemManager.gameObjects.RemoveAt(index);
        }

        public static void RegisterSystem(AbstractSystem system)
        {
            AddSystem(system);
        }

        private static void AddSystem(AbstractSystem system)
        {
            _systems.Add(system);
        }

        public static T System<T>() where T : class
        {
            var systems = from system in _systems
                          where system is T
                          select system;

            if (systems.Any())
            {
                return systems.First() as T;
            }
            return null;
        }
    }
}
