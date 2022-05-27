

namespace SquareMeter
{
    internal interface IPolygonalMeter : IMeter
    {
        float this[int sideI] { get; set; }

        /// <summary>
        /// If side index is wrong, throws exception.
        /// </summary>
        /// <param name="sideI"></param>
        void CheckSideI(int sideI);
    }
}
