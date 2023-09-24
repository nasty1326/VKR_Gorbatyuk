using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR_Gorbatyuk
{
    public class ParamT
    {
        /// <summary>
        /// Количество осей тягача
        /// </summary>
        public int osT;
        /// <summary>
        /// Масса тягача
        /// </summary>
        public double massT;
        /// <summary>
        /// Расстояние между осями тягача
        /// </summary>
        public double ST;
        /// <summary>
        /// Расстояние от передней оси тягача до седла
        /// </summary>
        public double ST1ct;
        /// <summary>
        /// Расстояние от седла до задней оси тягача
        /// </summary>
        public double STct2;
        /// <summary>
        /// Нагрузка на переднюю ось тягача
        /// </summary>
        public double PT1;
        /// <summary>
        /// Нагрузка на заднюю ось тягача
        /// </summary>
        public double PT2;
        /// <summary>
        /// Максимально допустимая нагрузка на переднюю ось тягача
        /// </summary>
        public double MaxPT1;
        /// <summary>
        /// Максимально допустимая нагрузка на заднюю ось тягача
        /// </summary>
        public double MaxPT2;

        public string name;
    }
}
