using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareMeter
{
    internal interface IPolygonalMeter : IMeter
    {
        float this[int sideI] { get; set; }

        /// <summary>
        /// If side index is wrong, throw exception.
        /// </summary>
        /// <param name="sideI"></param>
        void CheckSideI(int sideI);
    }
}
