using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace VKR_Gorbatyuk
{
    public class SearchXYOpt
    {
        
        /// <summary>
            /// Массив для массы шагом 100 кг 
            /// </summary>
            private double[] mgr;

        /// <summary>
        /// Массив для длины контейнера с шагом 10 см.
        /// </summary>
        private double[] sx;

        /// <summary>
        /// Расстояние от центра тяжести груза до задней оси полуприцепа в мм
        /// </summary>
        private double ar;
        public double searchYopt(Form1 f1)
        {
            Series ser= new Series();
            
            ClassPOsi nOsi = new ClassPOsi();
            //f1.fr.Show();
            mgr = new double[(int)f1.pp.MaxGruzPP /100];
            double n = 100;
            for (int i = 0; i < mgr.Length; i++)
            {
                mgr[i] = n;
                n = n + 100;
            }

            sx = new double[(int)f1.pp.SPP / 100];
            n = 100;
            for (int i = 0; i < sx.Length; i++)
            {
                sx[i] = n;
                n = n + 100;
            }

            double Nn1 = 0;
            double Nn = 0;
            double Nn2 = 0;
            double Nn3 = 0;
            double s = 0;
            double maxX = 0;
            List<double> optX = new List<double>();
            double[] massN;
            for (int i = 0; i < sx.Length; i++) // i- расстояние от начала контейнера 
            {
                ar = f1.pp.SPP - f1.pp.SPP2 - sx[i];

                for (int j = 0; j < mgr.Length; j++) // j - вес
                {

                    Nn = nOsi.N(f1,mgr[j], ar);

                    if (Nn >= f1.pp.MaxPppT)
                    {
                        s = mgr[j - 1];
                        break;
                    }

                    Nn3 = nOsi.N3(f1,mgr[j], Nn);
                    if (Nn3 >= f1.pp.MaxPpp1)
                    {
                        s = mgr[j - 1];
                        break;
                    }

                    Nn2 = nOsi.N2(f1,Nn);
                    if (Nn2 >= f1.t.MaxPT2)
                    {
                        s = mgr[j - 1];
                        break;
                    }
                    Nn1 = nOsi.N1(f1, Nn, Nn2);
                    if (Nn1 >= f1.t.MaxPT1)
                    {
                        s = mgr[j - 1];
                        break;
                    }
                    s = mgr[j];

                    if (maxX <= mgr[j])
                    {
                        maxX = mgr[j];
                    }
                }

                
                   // chart.Series[0].Points.AddXY(sx[i]/1000, s/100);


                if (s >= f1.massGr)
                {
                    
                     // chart.Series[0].Points[i].Color = Color.Green;
                    
                
                    double m = sx[i];
                    optX.Add(m);
                }

            }
            optX[0] = Math.Round(optX[0], 2);
            optX[optX.Count - 1] = Math.Round(optX[optX.Count - 1], 2);
            return (optX[0] + optX[optX.Count - 1]) / 2;
        }
        /// <summary>
        /// Поиск Х для размещения первого груза в контейнер
        /// </summary>
        /// <param name="f1">Форма с данными</param>
        /// <param name="c">Первый груз</param>
        /// <returns></returns>
        public double searchXOneRect(Form1 f1, RectagleC c)
        {
            return (c.w / 2);
        }

        //public Chart PaintChart (Chart _chart)
        //{
        //    _chart.Series[0] = chart.Series[0];
        //    return _chart;
        //}
        public void PaintsDiagramm (Form1 f1)
        {
            Series ser = new Series();
            ClassPOsi nOsi = new ClassPOsi();
            //f1.fr.Show();
            mgr = new double[(int)f1.pp.MaxGruzPP / 100];
            double n = 100;
            for (int i = 0; i < mgr.Length; i++)
            {
                mgr[i] = n;
                n = n + 100;
            }

            sx = new double[(int)f1.pp.SPP / 100];
            n = 100;
            for (int i = 0; i < sx.Length; i++)
            {
                sx[i] = n;
                n = n + 100;
            }

            double Nn1 = 0;
            double Nn = 0;
            double Nn2 = 0;
            double Nn3 = 0;
            double s = 0;
            double maxX = 0;
            List<double> optX = new List<double>();
            double[] massN;
            for (int i = 0; i < sx.Length; i++) // i- расстояние от начала контейнера 
            {
                ar = f1.pp.SPP - f1.pp.SPP2 - sx[i];

                for (int j = 0; j < mgr.Length; j++) // j - вес
                {

                    Nn = nOsi.N(f1, mgr[j], ar);

                    if (Nn >= f1.pp.MaxPppT)
                    {
                        s = mgr[j - 1];
                        break;
                    }

                    Nn3 = nOsi.N3(f1, mgr[j], Nn);
                    if (Nn3 >= f1.pp.MaxPpp1)
                    {
                        s = mgr[j - 1];
                        break;
                    }

                    Nn2 = nOsi.N2(f1, Nn);
                    if (Nn2 >= f1.t.MaxPT2)
                    {
                        s = mgr[j - 1];
                        break;
                    }
                    Nn1 = nOsi.N1(f1, Nn, Nn2);
                    if (Nn1 >= f1.t.MaxPT1)
                    {
                        s = mgr[j - 1];
                        break;
                    }
                    s = mgr[j];

                    if (maxX <= mgr[j])
                    {
                        maxX = mgr[j];
                    }
                }


                f1.fr.chartMaxPpp.Series[0].Points.AddXY(sx[i]/1000, s/10);


                if (s > f1.massGr)
                {

                    f1.fr.chartMaxPpp.Series[0].Points[i].Color = Color.Green;


                    double m = sx[i];
                    optX.Add(m);
                }

            }
            optX[0] = Math.Round(optX[0], 2);
            optX[optX.Count - 1] = Math.Round(optX[optX.Count - 1], 2);
        }

    }
}
            
    
        
    

