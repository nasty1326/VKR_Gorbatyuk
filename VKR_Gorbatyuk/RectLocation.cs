using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Gorbatyuk
{
    /// <summary>
    /// Особь 
    /// </summary>
    public class RectLocation
    {
        /// <summary>
        /// Лист груза
        /// </summary>
        public List<RectagleC> rects = new List<RectagleC>();
        /// <summary>
        /// Расстояние до точки оптимального размещения
        /// </summary>
        public PointC CentrSumMass;
        /// <summary>
        /// Удачное ли размещение
        /// </summary>
        
        public bool lucky=true;

        public double kEff;
        public RectLocation()
        {
        }
        public void SortRect()
        {

            List<RectagleC> rectsOneLvL = new List<RectagleC>();
            List<RectagleC> rectsOtherLvL = new List<RectagleC>();
            for (int i = 0;i < rects.Count; i++)
            {
                if (rects[i].leftUpD1Point.z == 0)
                {
                    rectsOneLvL.Add(rects[i]);
                }else
                {
                    rectsOtherLvL.Add(rects[i]);
                }
            }

            
            RectagleC temp = new RectagleC();
            if (rectsOneLvL.Count > 1)
            {
                for (int i = 0; i < rectsOneLvL.Count; i++)
                {
                    for (int j = i + 1; j < rectsOneLvL.Count; j++)
                    {
                        if (rectsOneLvL[i].leftUpD1Point.y > rectsOneLvL[j].leftUpD1Point.y)
                        {
                            temp = rectsOneLvL[i];
                            rectsOneLvL[i] = rectsOneLvL[j];
                            rectsOneLvL[j] = temp;
                        }
                    }
                }
            }
            

            if (rectsOtherLvL.Count > 1)
            {
                for (int i = 0; i < rectsOtherLvL.Count; i++)
                {
                    for (int j = i + 1; j < rectsOtherLvL.Count; j++)
                    {
                        if (rectsOtherLvL[i].leftUpD1Point.z > rectsOtherLvL[j].leftUpD1Point.z)
                        {
                            temp = rectsOtherLvL[i];
                            rectsOtherLvL[i] = rectsOtherLvL[j];
                            rectsOtherLvL[j] = temp;
                        }
                    }
                }
            }

            rectsOneLvL.AddRange(rectsOtherLvL);
            rects=rectsOneLvL;
           
        }
        public void GetVertexRects()
        {
            for (int i=0; i<rects.Count; i++)
            {
                rects[i].GetVertex();
            }
        }

        public void putRectagle(Form1 f1)
        {

            List<PointC> BaseNode = new List<PointC>(); // список базовых узлов
            List<PointC> AdaptNode = new List<PointC>(); // список адаптивных узлов
            List<PointC> NodeLevel1LimitationPP = new List<PointC>(); // список узлов, прошедших ограничения контейнера
            List<PointC> NodeLevel1NotIntersection = new List<PointC>(); // список узлов, прошедших ограничения контейнера и условие непересекаемости
            List<RectagleC> UpGruzInPP = new List<RectagleC>(); // список груза в контейнере, на котором ничего не находиться
            List<RectagleC> UpGruzInPPMoreAreal = new List<RectagleC>(); // список груза в контейнере, на котром ничего не находится и меньшей площади
            List<RectagleC> GruzInPP = new List<RectagleC>();// список груза, помещенного в контейнер

            PointC pointCMSum = new PointC(); // точка найденного центра массы всей расстановки 

            // ставим первый груз в контейнер
            PointC ct = new PointC(f1.searchXY.searchXOneRect(f1, rects[0]), f1.yOpt, 0);
            rects[0].ArrangeCoordinatesPointCT(ct, 0);
            GruzInPP.Add(rects[0]);
            UpGruzInPP.Add(rects[0]);
            BaseNode.Add(rects[0].leftUpD1Point);
            BaseNode.Add(rects[0].leftDownD1Point);
            BaseNode.Add(rects[0].rightDownD1Point);
            BaseNode.Add(rects[0].rightUpD1Point);

            for (int i = 1; i < rects.Count; i++)
            {
                double MinSCTxyopt = 10000000; // минимальное расстояние от центра суммарной тяжести груза до оптимальной точки
                int jmin = 0;
                double SCTxyopt;

                //Формируем список адаптивных узлов
                for (int j = 0; j < BaseNode.Count; j++)
                {
                    PointC adap1 = new PointC(BaseNode[j].x - rects[i].w, BaseNode[j].y, 0);
                    PointC adap2 = new PointC(BaseNode[j].x, BaseNode[j].y - rects[i].d, 0);
                    PointC adap3 = new PointC(BaseNode[j].x - rects[i].w, BaseNode[j].y - rects[i].d, 0);
                    AdaptNode.Add(adap1);
                    AdaptNode.Add(adap2);
                    AdaptNode.Add(adap3);
                }

                //Проеверяем на ограничения по границам контейнера список адаптивных и базовых узлов 
                for (int j = 0; j < BaseNode.Count; j++)
                {
                    if (BaseNode[j].x >= f1.pp.minW && BaseNode[j].x <= f1.pp.maxW && BaseNode[j].y >= f1.pp.minD && BaseNode[j].y <= f1.pp.maxD)
                    {
                        if (BaseNode[j].x + rects[i].w >= f1.pp.minW && BaseNode[j].x + rects[i].w <= f1.pp.maxW && BaseNode[j].y >= f1.pp.minD && BaseNode[j].y <= f1.pp.maxD)
                        {
                            if (BaseNode[j].x >= f1.pp.minW && BaseNode[j].x <= f1.pp.maxW && BaseNode[j].y + rects[i].d >= f1.pp.minD && BaseNode[j].y + rects[i].d <= f1.pp.maxD)
                            {
                                if (BaseNode[j].x + rects[i].w >= f1.pp.minW && BaseNode[j].x + rects[i].w <= f1.pp.maxW && BaseNode[j].y + rects[i].d >= f1.pp.minD && BaseNode[j].y + rects[i].d <= f1.pp.maxD)
                                {
                                    NodeLevel1LimitationPP.Add(BaseNode[j]);
                                }
                            }
                        }
                    }
                }

                for (int j = 0; j < AdaptNode.Count; j++)
                {
                    if (AdaptNode[j].x >= f1.pp.minW && AdaptNode[j].x <= f1.pp.maxW && AdaptNode[j].y >= f1.pp.minD && AdaptNode[j].y <= f1.pp.maxD)
                    {
                        if (AdaptNode[j].x + rects[i].w >= f1.pp.minW && AdaptNode[j].x + rects[i].w <= f1.pp.maxW && AdaptNode[j].y >= f1.pp.minD && AdaptNode[j].y <= f1.pp.maxD)
                        {
                            if (AdaptNode[j].x >= f1.pp.minW && AdaptNode[j].x <= f1.pp.maxW && AdaptNode[j].y + rects[i].d >= f1.pp.minD && AdaptNode[j].y + rects[i].d <= f1.pp.maxD)
                            {
                                if (AdaptNode[j].x + rects[i].w >= f1.pp.minW && AdaptNode[j].x + rects[i].w <= f1.pp.maxW && AdaptNode[j].y + rects[i].d >= f1.pp.minD && AdaptNode[j].y + rects[i].d <= f1.pp.maxD)
                                {
                                    NodeLevel1LimitationPP.Add(AdaptNode[j]);
                                }
                            }
                        }
                    }
                }
                // Проверяем наличие узлов размещения в контейнере
                if (NodeLevel1LimitationPP.Count == 0) // если узлов в NodeLevel1LimitationPP нет
                {
                    // Ищем грузs большей площади и походящие по условию высоты
                    for (int j = 0; j < UpGruzInPP.Count; j++)
                    {
                        if (UpGruzInPP[j].w >= rects[i].w && UpGruzInPP[j].d >= rects[i].d && (UpGruzInPP[j].leftDownD2Point.z + rects[i].h) <= f1.pp.maxH)
                        {
                            UpGruzInPPMoreAreal.Add(UpGruzInPP[j]);
                        }
                    }

                    // если сверху поставить некуда, признаем размещение провальным
                    if (UpGruzInPPMoreAreal.Count == 0)
                    {
                        lucky = false;
                        CentrSumMass = null;
                        kEff = 100000;
                        return;
                    }
                    else // если есть, ищем лучший вариант 
                    {
                        // для каждого узла верхнего уровня ищеим вариант, в котором центр суммарной тяжести груза будет минимальный
                        for (int j = 0; j < UpGruzInPPMoreAreal.Count; j++)
                        {
                            PointC probCt = UpGruzInPPMoreAreal[j].CT; // центр тяжести нижнего груза
                            PointC CTsumMasGR = CTSumMassGrI(f1.pp, GruzInPP, rects[i], probCt); // точка центра суммарной массы груза в контейнере и груза, поставленного на один подходящий груз в контейнере

                            //расстояние от центра тяжести груза до оптимальной точки суммарной тяжести груза
                            SCTxyopt = Math.Sqrt((f1.XYOpt.x - CTsumMasGR.x) * (f1.XYOpt.x - CTsumMasGR.x) + (f1.XYOpt.y - CTsumMasGR.y) * (f1.XYOpt.y - CTsumMasGR.y));
                            if (SCTxyopt < MinSCTxyopt)  // ищем минимальное расстояние
                            {
                                MinSCTxyopt = SCTxyopt;
                                jmin = j; //запоминимаем номер более подходящего груза из массива UpGruzInPPMoreAreal
                                pointCMSum = CTsumMasGR;
                            }
                        }
                        // добавляем груз в контейнер в лучший узел
                        // ищем координаты вершин верхнего груза от центра тяжести 
                        rects[i].ArrangeCoordinatesPointCT(UpGruzInPPMoreAreal[jmin].CT, UpGruzInPPMoreAreal[jmin].leftDownD2Point.z);
                        AdaptNode.Clear(); // очищаем список адаптивных узлов
                        CentrSumMass = pointCMSum; // обозначаем промежуточный центр суммарной массы груза в контейнере
                        NodeLevel1LimitationPP.Clear(); // очищаем список узлов, прошедших ограничения контейнера

                        NodeLevel1NotIntersection.Clear(); // очищаем список узлов, прошедших ограничения контейнера и условие непересекаемости
                        GruzInPP.Add(rects[i]); // добавляем груз в список грузов в контейнере
                        // ищем в списке грузов со свободным верхом груз, на который поставили данный груз, и заменяем его данным грузом
                        for (int j = 0; j < UpGruzInPP.Count; j++)
                        {
                            if (UpGruzInPP[j].number == UpGruzInPPMoreAreal[jmin].number)
                            {
                                UpGruzInPP.RemoveAt(j);
                                break;
                            }
                        }
                        UpGruzInPPMoreAreal.Clear();
                        UpGruzInPP.Add(rects[i]);
                        // коэффициентом эффективности назначаем расстояние от центра тяжести груза до оптимальной точки
                        kEff = MinSCTxyopt;
                        
                    }

                }
                else// если узлы в NodeLevel1LimitationPP есть
                {
                    // проверяем узлы на условие непересекаемости
                    for (int j = 0; j < NodeLevel1LimitationPP.Count; j++)
                    {
                        RectagleC rect1 = new RectagleC();
                        // создаем условный прямоугольник у узле
                        PointC lud1 = new PointC(NodeLevel1LimitationPP[j].x , NodeLevel1LimitationPP[j].y , 0);
                        PointC rud1 = new PointC(NodeLevel1LimitationPP[j].x + rects[i].w , NodeLevel1LimitationPP[j].y , 0);
                        PointC ldd1 = new PointC(NodeLevel1LimitationPP[j].x , NodeLevel1LimitationPP[j].y + rects[i].d , 0);
                        PointC rdd1 = new PointC(NodeLevel1LimitationPP[j].x + rects[i].w , NodeLevel1LimitationPP[j].y + rects[i].d , 0);
                        rect1.leftUpD1Point = lud1;
                        rect1.rightUpD1Point = rud1;
                        rect1.leftDownD1Point = ldd1;
                        rect1.rightDownD1Point = rdd1;
                        rect1.w = rects[i].w;
                        rect1.d = rects[i].d;
                        bool b = true;
                        // проверяем пересечения с каждым прямоугольником в контейнере
                        for (int k = 0; k < GruzInPP.Count; k++)
                        {
                            Rectangle re1 = new Rectangle((int)GruzInPP[k].leftUpD1Point.x, (int)GruzInPP[k].leftUpD1Point.y, (int)GruzInPP[k].w, (int)GruzInPP[k].d);
                            Rectangle re2 = new Rectangle((int)rect1.leftUpD1Point.x, (int)rect1.leftUpD1Point.y, (int)rect1.w, (int)rect1.d);

                            Rectangle intersection = Rectangle.Intersect(re1, re2);

                            if (intersection.Width*intersection.Height > 0)
                            {
                                b = false;
                                break;
                            }
                            
                        }
                        if (b) // если пересечений нет, добавляем узел в список узлов, прошедших условие непересекаемости
                        {
                            NodeLevel1NotIntersection.Add(NodeLevel1LimitationPP[j]);
                        }
                    }

                    // если узлов в NodeLevel1NotIntersection нет
                    if (NodeLevel1NotIntersection.Count == 0) //смотрим верхние уровни
                    {
                        // Ищем грузs большей площади и походящие по условию высоты
                        for (int j = 0; j < UpGruzInPP.Count; j++)
                        {
                            if (UpGruzInPP[j].w >= rects[i].w && UpGruzInPP[j].d >= rects[i].d && (UpGruzInPP[j].leftDownD2Point.z + rects[i].h) <= f1.pp.maxH)
                            {
                                UpGruzInPPMoreAreal.Add(UpGruzInPP[j]);
                            }
                        }

                        // если сверху поставить некуда, признаем размещение провальным
                        if (UpGruzInPPMoreAreal.Count == 0)
                        {
                            lucky = false;
                            CentrSumMass = null;
                            kEff = 100000;
                            return;
                        }
                        else // если есть, ищем лучший вариант 
                        {
                            // для каждого узла верхнего уровня ищеим вариант, в котором центр суммарной тяжести груза будет минимальный
                            for (int j = 0; j < UpGruzInPPMoreAreal.Count; j++)
                            {
                                PointC probCt = UpGruzInPPMoreAreal[j].CT; // центр тяжести нижнего груза
                                PointC CTsumMasGR = CTSumMassGrI(f1.pp, GruzInPP, rects[i], probCt); // точка центра суммарной массы груза в контейнере и груза, поставленного на один подходящий груз в контейнере

                                //расстояние от центра тяжести груза до оптимальной точки суммарной тяжести груза
                                SCTxyopt = Math.Sqrt((f1.XYOpt.x - CTsumMasGR.x) * (f1.XYOpt.x - CTsumMasGR.x) + (f1.XYOpt.y - CTsumMasGR.y) * (f1.XYOpt.y - CTsumMasGR.y));
                                if (SCTxyopt < MinSCTxyopt)  // ищем минимальное расстояние
                                {
                                    MinSCTxyopt = SCTxyopt;
                                    jmin = j; //запоминимаем номер более подходящего груза из массива UpGruzInPPMoreAreal
                                    pointCMSum = CTsumMasGR;
                                }
                            }
                            // добавляем груз в контейнер в лучший узел
                            // ищем координаты вершин верхнего груза от центра тяжести 
                            rects[i].ArrangeCoordinatesPointCT(UpGruzInPPMoreAreal[jmin].CT, UpGruzInPPMoreAreal[jmin].leftDownD2Point.z);
                            AdaptNode.Clear(); // очищаем список адаптивных узлов
                            CentrSumMass = pointCMSum; // обозначаем промежуточный центр суммарной массы груза в контейнере
                            NodeLevel1LimitationPP.Clear(); // очищаем список узлов, прошедших ограничения контейнера
                            NodeLevel1NotIntersection.Clear(); // очищаем список узлов, прошедших ограничения контейнера и условие непересекаемости

                            GruzInPP.Add(rects[i]); // добавляем груз в список грузов в контейнере
                                                    // ищем в списке грузов со свободным верхом груз, на который поставили данный груз, и заменяем его данным грузом
                            for (int j = 0; j < UpGruzInPP.Count; j++)
                            {
                                if (UpGruzInPP[j].number == UpGruzInPPMoreAreal[jmin].number)
                                {
                                    UpGruzInPP.RemoveAt(j);
                                    break;
                                }
                            }
                            UpGruzInPPMoreAreal.Clear();
                            UpGruzInPP.Add(rects[i]);
                            // коэффициентом эффективности назначаем расстояние от центра тяжести груза до оптимальной точки
                            kEff = MinSCTxyopt;
                           
                        }
                    }
                    else // если узлы в NodeLevel1NotIntersection есть
                    {
                        // ищем лучший узел для размещения
                        for (int j = 0; j < NodeLevel1NotIntersection.Count; j++) // проходим все узлы
                        {
                            // создаем точку пробного центра тяжести очередного груза 
                            PointC probCt = new PointC(NodeLevel1NotIntersection[j].x + rects[i].w / 2, NodeLevel1NotIntersection[j].y + rects[i].h / 2, 0);
                            PointC CTsumMasGR = CTSumMassGrI(f1.pp, GruzInPP, rects[i], probCt);

                            // получили расстояние от точки суммы тяжести до точки оптимальнго центра тяжести 
                            SCTxyopt = Math.Sqrt((f1.XYOpt.x - CTsumMasGR.x) * (f1.XYOpt.x - CTsumMasGR.x) + (f1.XYOpt.y - CTsumMasGR.y) * (f1.XYOpt.y - CTsumMasGR.y));
                            if (SCTxyopt < MinSCTxyopt)
                            {
                                MinSCTxyopt = SCTxyopt;
                                jmin = j;
                                pointCMSum = CTsumMasGR;
                            }

                        }
                        // добавляем груз в контейнер в лучший узел
                        rects[i].leftUpD1Point = NodeLevel1NotIntersection[jmin];
                        rects[i].rightUpD1Point = new PointC(NodeLevel1NotIntersection[jmin].x + rects[i].w, NodeLevel1NotIntersection[jmin].y, 0);
                        rects[i].leftDownD1Point = new PointC(NodeLevel1NotIntersection[jmin].x, NodeLevel1NotIntersection[jmin].y + rects[i].d, 0);
                        rects[i].rightDownD1Point = new PointC(NodeLevel1NotIntersection[jmin].x + rects[i].w, NodeLevel1NotIntersection[jmin].y + rects[i].d, 0);
                        rects[i].leftUpD2Point = new PointC(NodeLevel1NotIntersection[jmin].x, NodeLevel1NotIntersection[jmin].y, rects[i].h); ;
                        rects[i].rightUpD2Point = new PointC(NodeLevel1NotIntersection[jmin].x + rects[i].w, NodeLevel1NotIntersection[jmin].y, rects[i].h);
                        rects[i].leftDownD2Point = new PointC(NodeLevel1NotIntersection[jmin].x, NodeLevel1NotIntersection[jmin].y + rects[i].d, rects[i].h);
                        rects[i].rightDownD2Point = new PointC(NodeLevel1NotIntersection[jmin].x + rects[i].w, NodeLevel1NotIntersection[jmin].y + rects[i].d, rects[i].h);
                        rects[i].CT = new PointC(NodeLevel1NotIntersection[jmin].x + rects[i].w / 2, NodeLevel1NotIntersection[jmin].y + rects[i].d / 2, 0);

                        AdaptNode.Clear();
                        NodeLevel1LimitationPP.Clear();
                        NodeLevel1NotIntersection.Clear();
                        BaseNode.Add(rects[i].leftUpD1Point);
                        BaseNode.Add(rects[i].rightUpD1Point);
                        BaseNode.Add(rects[i].leftDownD1Point);
                        BaseNode.Add(rects[i].rightDownD1Point);
                        UpGruzInPPMoreAreal.Clear();
                        GruzInPP.Add(rects[i]);
                        UpGruzInPP.Add(rects[i]);
                        kEff = MinSCTxyopt;
                        CentrSumMass = pointCMSum;
                        
                    }
                }
            }
        }

       
        //Функция нахождения точки центра тяжести груза
        private PointC CTSumMassGrI(ParamPP pp, List<RectagleC> GruzInPP, RectagleC rect, PointC ct)
        {
            double x, y;
            // найдем у
            double a = 0;
            // найдем X 
            double ax = 0;
            double mgr = 0;
            double mgrA = 0;
            double mgrAx = 0;
            for (int i = 0; i < GruzInPP.Count; i++)
            {
                mgrA = mgrA + GruzInPP[i].massRect * YiGr(pp, GruzInPP[i].CT);
                mgr = mgr + GruzInPP[i].massRect;
                mgrAx = mgrAx + GruzInPP[i].massRect * XiGr(pp, GruzInPP[i].CT);
            }
            mgrA = mgrA + rect.massRect * YiGr(pp, ct);
            mgrAx = mgrAx + rect.massRect * XiGr(pp, ct);
            mgr = mgr + rect.massRect;
            a = mgrA / mgr; // a - расстояние от оси полуприцепа до центра суммарной тяжести груза
            ax = mgrAx / mgr; // ax - расстояние от вертикальной оси полуприцепа до центра суммарной тяжести груза

            PointC ctmass = new PointC((int)(pp.Wpp / 2 - ax), (int)(pp.SPP - pp.SPP2 - a), 0);
            return ctmass;
        }

        // расстояние от центра тяжести до задней опи пп
        private double YiGr(ParamPP pp,PointC ct)
        {
            return (pp.SPP - pp.SPP2 - ct.y);
        }

        private double XiGr(ParamPP pp,PointC ct)
        {
            return (pp.Wpp / 2 - ct.x);
        }


    }
}
