using GameEngine.Components.Main;
using Microsoft.Xna.Framework;

namespace GameEngine.Components
{
    public class Particle : Component
    {
        private Vector3 _velocity;

        public Vector3 Velocity { get => _velocity; set => _velocity = value; }

        public Particle(Vector3 velocity)
        {
            _velocity = velocity;
        }
        public Particle()
        {
            _velocity = new Vector3(0,0,0);
        }
    }
}
