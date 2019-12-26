using Microsoft.Xna.Framework;
using System;

namespace GameEngine.Systems.UI
{
    public class TrackBar : UserInterfaceElement
    {

        public float Value { get => _value; set => _value = (value - (value % _step)) / _step; }
        private float _value = 10;
        public float MinValue { get => _minValue; set => _minValue = value < _maxValue ? value : _maxValue - _step; }
        private float _minValue = 0;
        public float MaxValue { get => _maxValue; set => _maxValue = value > _minValue ? value : _maxValue + _step; }
        private float _maxValue = 100;
        public uint Step { get => _step; set => _step = value; }
        private uint _step = 1;

        public Vector2 Size { get => new Vector2(_width, _height); set => value.SetFromVector(out _width, out _height); }
        public float _height = 16;
        public float _width = 300;
        private void CheckValues()
        {            
            Value = _value;
            MinValue = _minValue;
            MaxValue = _maxValue;
        }
        public override void Draw()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
