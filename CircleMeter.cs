using System;


namespace SquareMeter
{
    public struct CircleMeter : IMeter
    {
        public float _radius;

        public CircleMeter(float radius)
        {
            _radius = radius;
        }

        public float GetSquare()
        {
            return (float)Math.PI * _radius * _radius;
        }
    }
}