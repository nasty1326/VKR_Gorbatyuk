using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Gorbatyuk
{
    public class ParamPP
    {
        /// <summary>
        /// Количество осей в полуприцепе
        /// </summary>
        public int osPP;
        /// <summary>
        /// Полезная глубина полуприцепа
        /// </summary>
        public double SPP;
        /// <summary>
        /// Расстояние от седла до оси полуприцепа
        /// </summary>
        public double SPP1;
        /// <summary>
        /// Расстояние от оси до задней стенки полуприцепа
        /// </summary>
        public double SPP2;
        /// <summary>
        /// Нагрузка на седло
        /// </summary>
        public double PTPP;
        /// <summary>
        /// Нагрузка на ось полуприцепа
        /// </summary>
        public double PPP1;
        /// <summary>
        /// Ширина полуприцепа
        /// </summary>
        public double Wpp;
        /// <summary>
        /// Высота полуприцепа
        /// </summary>
        public double Hpp;
        /// <summary>
        /// Масса полуприцепа
        /// </summary>
        public double massPP;

        /// <summary>
        /// Максимально допустимая нагрузка на седло
        /// </summary>
        public double MaxPppT;
        /// <summary>
        /// Максимально доступная нагрузка на ось полуприцепа
        /// </summary>
        public double MaxPpp1;
        /// <summary>
        /// Максимально допустимая нагрузка на полуприцеп
        /// </summary>
        public double MaxGruzPP;


        /// <summary>
        /// Верхняя граница полуприцепа по ширине от точки оптимального размещения
        /// </summary>
        public double maxW;
        /// <summary>
        /// Нижняя граница полуприцепа по ширине от точки оптимального размещения
        /// </summary>
        public double minW;
        /// <summary>
        /// Нижняя граница полуприцепа по высоте от точки оптимального размещения
        /// </summary>
        public double minH;
        /// <summary>
        /// Верхняя граница полуприцепа по высоте от точки оптимального размещения
        /// </summary>
        public double maxH;
        /// <summary>
        /// Верхняя граница полуприцепа по глубине от точки оптимального размещения
        /// </summary>
        public double maxD;
        /// <summary>
        /// Нижняя граница полуприцепа по глубине от точки оптимального размещения
        /// </summary>
        public double minD;

        public string name;
        public void searchMinMaxPP()
        {
            minH = 0;
            maxH = Hpp;
            minW = 0;
            maxW = Wpp;
            minD = 0;
            maxD = SPP;
        }
    }
}
