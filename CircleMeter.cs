using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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