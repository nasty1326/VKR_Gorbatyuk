using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR_Gorbatyuk
{
    public class ClassPOsi 
    {
       // public ClassPOsi(Form1 f1)
       // {
            double HppC2 (double Pppt, double Spp1,double mpp)
            {
                return (Pppt * Spp1) / mpp;
            }
            double HT1C(double Pt2, double St, double mt)
            {
                return (Pt2 * St) / mt;
            }
            /// <summary>
            /// Нагрузка на седло в тоннах
            /// </summary>
            /// <param name="mg">Масса груза в тоннах</param>
            /// <param name="a">Расстояние от центра тяжести груза до задней оси полуприцепа в мм</param>
            /// <returns></returns>
            public double N(Form1 f1, double mg, double a)
            {
                return ((mg * a + f1.pp.massPP * HppC2(f1.pp.PTPP,f1.pp.SPP1,f1.pp.massPP)) / f1.pp.SPP1);
            }

            /// <summary>
            /// Нагрузка на заднюю ось полуприцепа в тоннах
            /// </summary>
            /// <param name="mg">Масса груза в тоннах</param>
            /// <param name="n">Нагрузка на седло в тоннах</param>
            /// <returns></returns>
            public double N3(Form1 f1,double mg, double n)
            {
                return (mg + f1.pp.massPP - n);
            }

            /// <summary>
            /// Нагрузка на заднюю ось тягача в тоннах
            /// </summary>
            /// <param name="n">Нагрузка на седло в тоннах</param>
            /// <returns></returns>
            public double N2(Form1 f1,double n)
            {
                return ((f1.t.massT * HT1C(f1.t.PT2,f1.t.ST,f1.t.massT) + n * f1.t.ST1ct) / f1.t.ST);
            }

            /// <summary>
            /// Нагрузка на переднюю ось тягача в тоннах
            /// </summary>
            /// <param name="n">Нагрузка на седло в тоннах</param>
            /// <param name="n2">Нагрузка на заднюю ось тягача в тоннах</param>
            /// <returns></returns>
            public double N1(Form1 f1, double n, double n2)
            {
                return (f1.t.massT + n - n2);
            }
       // }
       
    }
}
