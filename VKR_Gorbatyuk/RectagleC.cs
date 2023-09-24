using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Gorbatyuk
{
    /// <summary>
    /// Груз
    /// </summary>
    public class RectagleC
    {
        /// <summary>
        /// Высота груза
        /// </summary>
        public double h;
        /// <summary>
        /// Ширина груза
        /// </summary>
        public double w;
        /// <summary>
        /// Глубина груза
        /// </summary>
        public double d;
        /// <summary>
        /// Левый дальний нижный угол груза
        /// </summary>
        public PointC leftUpD1Point;
        /// <summary>
        /// Правый дальний нижний угол груза
        /// </summary>
        public PointC rightUpD1Point;
        /// <summary>
        /// Левый ближний нижний угол груза
        /// </summary>
        public PointC leftDownD1Point;
        /// <summary>
        /// Правый ближний нижний угол груза
        /// </summary>
        public PointC rightDownD1Point;
        /// <summary>
        /// Левый дальний верхний угол груза
        /// </summary>
        public PointC leftUpD2Point;
        /// <summary>
        /// Правый дальний верхний угол груза
        /// </summary>
        public PointC rightUpD2Point;
        /// <summary>
        /// Левый ближний верхний угол груза
        /// </summary>
        public PointC leftDownD2Point;
        /// <summary>
        /// Правый ближний верхний угол груза
        /// </summary>
        public PointC rightDownD2Point;
        /// <summary>
        /// Номер груза
        /// </summary>
        public int number;
        /// <summary>
        /// Масса груза
        /// </summary>
        public double massRect;
        public PointC CT;
        public Vertex VleftUpD1Point;
        public Vertex VrightUpD1Point;
        public Vertex VleftDownD1Point;
        public Vertex VrightDownD1Point;
        public Vertex VleftUpD2Point;
        public Vertex VrightUpD2Point;
        public Vertex VleftDownD2Point;
        public Vertex VrightDownD2Point;

        public RectagleC()
        {
            h = 0;
            w = 0;
            d = 0;
            number = 0;
            massRect = 0;
            leftUpD1Point = null;
            rightUpD1Point = null;
            leftDownD1Point = null;
            rightDownD1Point = null;
            leftUpD2Point = null;
            rightUpD2Point = null;
            leftDownD2Point = null;
            rightDownD2Point = null;
            CT= null;
        }
        /// <summary>
        /// Груз
        /// </summary>
        /// <param name="_w">Ширина груза</param>
        /// <param name="_h">Высота груза</param>
        /// <param name="_d">Глубина груза</param>
        /// <param name="number">Порядковый номер груза</param>
        /// <param name="mass">Масса груза</param>
        public RectagleC(double _w, double _h, double _d, int number, double mass)
        {
            this.h = _h;
            this.w = _w;
            this.d = _d;
            this.massRect = mass;
            leftUpD1Point = null;
            rightUpD1Point = null;
            leftDownD1Point = null;
            rightDownD1Point = null;
            leftUpD2Point = null;
            rightUpD2Point = null;
            leftDownD2Point = null;
            rightDownD2Point = null;
            this.number = number;
            CT = null;
        }
        /// <summary>
        /// Метод, позволяющий вычислить расположение вершин параллелепипеда в контейнере от центра тяжести
        /// </summary>
        /// <param name="ct"></param>
        public void ArrangeCoordinatesPointCT(PointC ct, double z)
        {
            leftUpD1Point = new PointC(ct.x - w / 2, ct.y - d / 2, z);
            rightUpD1Point = new PointC(ct.x + w / 2, ct.y - d / 2, z);
            leftDownD1Point = new PointC(ct.x - w / 2, ct.y + d / 2, z);
            rightDownD1Point = new PointC(ct.x + w / 2, ct.y + d / 2, z);
            leftUpD2Point = new PointC(ct.x - w / 2, ct.y - d / 2, z+h);
            rightUpD2Point = new PointC(ct.x + w / 2, ct.y - d / 2, z+h);
            leftDownD2Point = new PointC(ct.x - w / 2, ct.y + d / 2,z+ h);
            rightDownD2Point = new PointC(ct.x + w / 2, ct.y + d / 2,z+ h);

            this.CT = ct;
        }

        public void SearchCT()
        {
            PointC ct=new PointC(leftUpD1Point.x+w/2, leftUpD1Point.y+d/2, 0);
            this.CT = ct;
        }

        public void GetVertex()
        {
            VleftUpD1Point= new Vertex((float)(leftUpD1Point.y/1000), (float)(leftUpD1Point.z / 1000),(float)(leftUpD1Point.x / 1000));
            VrightUpD1Point = new Vertex((float)(rightUpD1Point.y / 1000), (float)(rightUpD1Point.z / 1000), (float)(rightUpD1Point.x / 1000));
            VleftDownD1Point = new Vertex((float)(leftDownD1Point.y / 1000), (float)(leftDownD1Point.z / 1000), (float)(leftDownD1Point.x / 1000));
            VrightDownD1Point = new Vertex((float)(rightDownD1Point.y / 1000), (float)(rightDownD1Point.z / 1000), (float)(rightDownD1Point.x / 1000));
            VleftUpD2Point = new Vertex((float)(leftUpD2Point.y / 1000), (float)(leftUpD2Point.z / 1000), (float)(leftUpD2Point.x / 1000));
            VrightUpD2Point = new Vertex((float)(rightUpD2Point.y / 1000), (float)(rightUpD2Point.z / 1000), (float)(rightUpD2Point.x / 1000));
            VleftDownD2Point = new Vertex((float)(leftDownD2Point.y / 1000), (float)(leftDownD2Point.z / 1000), (float)(leftDownD2Point.x / 1000));
            VrightDownD2Point = new Vertex((float)(rightDownD2Point.y / 1000), (float)(rightDownD2Point.z / 1000), (float)(rightDownD2Point.x / 1000));
        }
    }

}
