using GameEngine.GameData;
using Microsoft.Xna.Framework;

namespace GameEngine.Components.Main
{
    public class Transform : Component
    {
        /// <summary>
        /// Позиция в игре
        /// </summary>
        private Vector2 _position;
        /// <summary>
        /// Поворот
        /// </summary>
        private float _rotation;
        public float Rotation { get => _rotation; set => _rotation = value; }
        public Vector2 Position { get => _overlay ? _position : _position - Camera.position; set => _position = value; }

        public Vector2 RealPosition { get => _position; set => _position = value; }

        /// <summary>
        /// Относительно камеры
        /// </summary>
        private bool _overlay;
        public bool overlay { get => _overlay; set => _overlay = value; }


        public Transform(Vector2 position, float rotation = 0, bool overlay = false)
        {
            _position = position;
            _rotation = rotation;
            _overlay = overlay;
        }

        public Transform(float x, float y, float rotation = 0, bool overlay = false)
        {
            _position = new Vector2(x, y);
            _rotation = rotation;
            _overlay = overlay;
        }

        public Transform()
        {
            _position = new Vector2(0, 0);
            _rotation = 0;
            _overlay = false;
        }

        public Transform(bool overlay)
        {
            _position = new Vector2(0, 0);
            _rotation = 0;
            _overlay = overlay;
        }

        public void Move(Vector2 pos)
        {
            this._position += pos;
        }

        public void Move(float x, float y)
        {
            _position += new Vector2(x, y);
        }
    }
}
