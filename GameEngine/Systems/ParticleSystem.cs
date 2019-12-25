using GameEngine.Components;
using GameEngine.Components.Main;
using GameEngine.GameObjects;
using GameEngine.Systems.Main;

namespace GameEngine.Systems
{
    public class ParticleSystem : AbstractSystem
    {
        public override void Update()
        {
            foreach (GameObject obj in SystemManager.gameObjects)
            if (obj.HasComponentType(typeof(Particle)))
            {
                    if (obj.HasComponentType(typeof(Transform)))
                    {
                        
                        obj.Component<Transform>().Move(obj.Component<Particle>().Velocity.Multiply(SystemManager.deltaTime).To2d());
                        obj.Component<Transform>().Rotation += obj.Component<Particle>().Velocity.Z * SystemManager.deltaTime;
                        if (obj.Component<Transform>().Rotation >= 360) obj.Component<Transform>().Rotation -= 360;
                    }
            }
        }
    }
}
