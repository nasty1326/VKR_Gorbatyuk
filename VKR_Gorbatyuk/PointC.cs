using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace VKR_Gorbatyuk
{
    /// <summary>
    /// Точка
    /// </summary>
    public class PointC
    {
        public double x, y, z;
        /// <summary>
        /// Точка
        /// </summary>
        /// <param name="_x">ширина</param>
        /// <param name="_y">глубина</param>
        /// <param name="_z">высота</param>
        public PointC(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public PointC() 
        {           
        }

    }
}
