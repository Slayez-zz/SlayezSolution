using GameEngine.Components.Main;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.Systems.UI
{
    public abstract class UserInterfaceElement : IUserInterfaceElement
    {
        public Transform transform { get => _position; set => _position = value; }
        public EAlignUI Align { get; set; }

        public float DepthLayer { get => _depthLayer; set => _depthLayer = value; }
        private float _depthLayer = 0.5f;

        public Vector2 GetBound;

        private Transform _position = new Transform(true);
        public enum EAlignUI {none, top, leftTop, rightTop, left, center, right, leftBottom, bottom, rightBottom }

        public abstract void Draw();
        public abstract void Update();
    }
}
