using GameEngine.Components.Main;

namespace GameEngine.Components
{
    public class ObjSprite : Component
    {
        private string _texture;
        public string Texture { get => _texture; set => _texture = value; }

        public ObjSprite(string texture)
        {
            _texture = texture;
        }

        public ObjSprite()
        {
        }
    }
}
