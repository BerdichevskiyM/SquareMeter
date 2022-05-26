using System;


namespace SquareMeter
{
    public struct TriangleMeter : IPolygonalMeter
    {
        readonly float[] _sizeArray;

        public TriangleMeter(float side1, float side2, float side3)
        {
            _sizeArray = new float[3] { side1, side2, side3 };
            for (int i = 0; i < 3; i++)
                CheckSideSize(i, _sizeArray[i]);
        }

        public float this[int sideI]
        {
            get
            {
                CheckSideI(sideI);
                return _sizeArray[sideI];
            }
            set
            {
                CheckSideI(sideI);
                CheckSideSize(sideI, value);
                _sizeArray[sideI] = value;
            }
        }

        public void CheckSideI(int sideI)
        {
            try
            {
                _ = _sizeArray[sideI];
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exception("Side index is outside the bounds of the allowable side count.");
            }
        }

        void CheckSideSize(int sideI, float size)
        {
            float otherSideSum = 0f;
            for (int i = 0; i < 3; i++)
            {
                if (i != sideI)
                    otherSideSum += _sizeArray[i];
            }
            if (otherSideSum < size)
                throw new Exception("Impossible set side size: triangle inequality doesn't work.");
        }

        /// <summary>
        /// Biggest side is standed on last array cell.
        /// </summary>
        /// <returns></returns>
        float[] GetSorthingSidesOnBiggest()
        {
            float[] sizeArray = new float[3];
            _sizeArray.CopyTo(sizeArray, 0);
            float timePerem;
            if (sizeArray[0] > sizeArray[1])
            {
                timePerem = sizeArray[1];
                sizeArray[1] = sizeArray[0];
                sizeArray[0] = timePerem;
            }
            if (sizeArray[1] > sizeArray[2])
            {
                timePerem = sizeArray[2];
                sizeArray[2] = sizeArray[1];
                sizeArray[1] = timePerem;
            }
            return sizeArray;
        }

        public float GetSquare()
        {
            float[] sizeArray = GetSorthingSidesOnBiggest();
            float aSize = sizeArray[0];
            float bSize = sizeArray[1];
            float cSize = sizeArray[2]; // biggest side
            if (cSize * cSize == aSize * aSize + bSize * bSize) // right triangle checking
                return 1f / 2f * aSize * bSize;
            float perimeterHalf = (aSize + bSize + cSize) * 1f / 2f;
            return (float)Math.Sqrt(perimeterHalf * (perimeterHalf - cSize) * (perimeterHalf - aSize) * (perimeterHalf - bSize));
        }
    }
}
