using GameEngine.Components.Main;

namespace GameEngine.Components
{
    public class PlayerController : Component
    {
        private bool _canMove;

        public PlayerController()
        {
        }

        public PlayerController(bool value)
        {
            this._canMove = value;
        }

        public bool Get()
        {
            return _canMove;
        }
        public void Set(bool value)
        {
            _canMove = value;
        }

    }
}
