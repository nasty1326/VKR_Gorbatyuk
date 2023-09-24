using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;


namespace VKR_Gorbatyuk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //for (int i = 0; i < 7; i++)
            //{
            //    dataGridView1.Rows.Add(1200, 500, 1260, 999);
            //}
            //for (int i = 0; i < 7; i++)
            //{
            //    dataGridView1.Rows.Add(1300, 700, 800, 555);
            //}

            //for (int i = 0; i < 7; i++)
            //{
            //    dataGridView1.Rows.Add(1200, 500, 1000, 888);
            //}
            for (int i = 0; i < 22; i++)
            {
                dataGridView1.Rows.Add(1200, 1000, 1260, 999);
            }
        }

        ClassError er = new ClassError();
        public ParamPP pp = new ParamPP();
        public ParamT t = new ParamT();
        public ParamGr gr = new ParamGr();
        public SearchXYOpt searchXY = new SearchXYOpt();
        public FormResult fr;


        public double massGr = 0;
        public double VGr = 0;
        public double Vpp;


        public int okT = 0;
        public int okP = 0;

        public double yOpt;
        /// <summary>
        /// Расстояние от точки оптимального центра тяжести до оси полуприцепа. 
        /// </summary>
        public double sXYoptOs;
        public PointC XYOpt;

        // для генетического алгоритма
        public int maxpop = 100; // максимум в популяции
        public int maxstring = 10; // битовая строк
        public int numpop; // число особей в поколении
        public double pmutation; // вероятность мутации
        public int gen; // номер рассматриваемого поколения
        public int numgen; // число поколений
        public double numCrossof;
        public double[] maxmass;
        public double[] sredmass;


        public int ncub; // количество груза


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) // две оси
            {
                pictureBox1.Image = global::VKR_Gorbatyuk.Properties.Resources.tyagach;
                pictureBoxP2T.Visible = true;
                pictureBox12.Visible = false;
                Point c = new Point(656, 265);
                label11.Location = c;

            }
            if (comboBox1.SelectedIndex == 1) // 3 оси 
            {
                pictureBox1.Image = global::VKR_Gorbatyuk.Properties.Resources.tyagach3;
                pictureBoxP2T.Visible = false;
                pictureBox12.Visible = true;
                Point c = new Point(713, 265);
                label11.Location = c;
            }
        }

        private void btTyagach_Click(object sender, EventArgs e)
        {
            t.name = textBoxNameT.Text;
            t.osT = comboBox1.SelectedIndex + 2;
            t.massT = (double)numMGT.Value;
            t.ST = (double)numST.Value;
            t.ST1ct = (double)numST1CT.Value;
            t.STct2 = (double)numSTCT2.Value;
            t.PT1 = (double)numPT1.Value;
            t.PT2 = (double)numPT2.Value;
            t.MaxPT1 = (double)numMaxPT1.Value;
            t.MaxPT2 = (double)numMaxPT2.Value;
            okT++;
            if (t.ST1ct + t.STct2 != t.ST)
            {
                er.ErrorST();
            }
            if (t.PT1 + t.PT2 != t.massT)
            {
                er.ErrorPT();
            }
            if (t.PT1 >= t.MaxPT1)
            {
                er.ErrorPT1Max();
            }
            if (t.PT2 >= t.MaxPT2)
            {
                er.ErrorPT2Max();
            }
            tabControl1.SelectTab(tabPP);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                pictureBox2.Image = global::VKR_Gorbatyuk.Properties.Resources.PP1;


            }
            if (comboBox2.SelectedIndex == 1)
            {
                pictureBox2.Image = global::VKR_Gorbatyuk.Properties.Resources.PP2;

            }
            if (comboBox2.SelectedIndex == 2)
            {
                pictureBox2.Image = global::VKR_Gorbatyuk.Properties.Resources.PP3;

            }
        }

        private void btPP_Click(object sender, EventArgs e)
        {
            pp.name = textBoxNamePP.Text;
            pp.osPP = comboBox2.SelectedIndex + 1;
            pp.massPP = (double)numMGPP.Value;
            pp.SPP = (double)numSPP.Value;
            pp.SPP1 = (double)numSPP1.Value;
            pp.SPP2 = (double)numSPP2.Value;
            pp.PTPP = (double)numPTPP.Value;
            pp.Wpp = (double)numWpp.Value;
            pp.Hpp = (double)numHpp.Value;
            pp.PPP1 = (double)numPpp1.Value;
            pp.MaxPppT = (double)numMaxPppT.Value;
            pp.MaxPpp1 = (double)numMaxPpp1.Value;
            pp.MaxGruzPP = (double)numMaxGruzPP.Value;
            okP++;
            Vpp = pp.Wpp * pp.Hpp * pp.SPP;
            if (pp.SPP1 + pp.SPP2 > pp.SPP)
            {
                er.ErrorSPP();
            }
            if (pp.PTPP + pp.PPP1 != pp.massPP)
            {
                er.ErrorPpp();
            }
            if (pp.PTPP >= pp.MaxPppT)
            {
                er.ErrorPppTMax();
            }
            if (pp.PPP1 >= pp.MaxPpp1)
            {
                er.ErrorPpp1Max();
            }

            tabControl1.SelectTab(tabGruz);
        }

        RectLocation startPopLoc = new RectLocation();

        // для ГА
        List<RectLocation> oldpop = new List<RectLocation>(); // старое поколение популяции
        List<RectLocation> newpop = new List<RectLocation>(); // новое поколение популяции
        List<RectLocation> intpop = new List<RectLocation>(); // полонение для сортировки 
        RectLocation BestOsob = new RectLocation(); //лучшая особь
        double bestEffect = 1000000; // коэф еффективности лучшей особи

        private void btRun_Click(object sender, EventArgs e)
        {

            int numError = 0;
            if (okT == 0)
            {
                er.ErrorNotData(1);
                numError++;
            }
            if (okP == 0)
            {
                er.ErrorNotData(2);
                numError++;
            }
            if (dataGridView1.Rows.Count == 0)
            {
                er.ErrorNotData(3);
                numError++;
            }

            numpop = (int)numPopulation.Value;
            numgen = (int)numPok.Value;
            numCrossof = (double)numCross.Value;
            pmutation = (double)numMut.Value;

            gr.startPop = new List<RectagleC>();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                RectagleC rct = new RectagleC(Convert.ToInt32(dataGridView1[0, i].Value.ToString()), Convert.ToInt32(dataGridView1[1, i].Value.ToString()), Convert.ToInt32(dataGridView1[2, i].Value.ToString()), i, Convert.ToInt32(dataGridView1[3, i].Value.ToString()));

                if (rct.d > pp.SPP)
                {
                    massGr = 0;
                    VGr = 0;
                    gr.startPop.Clear();
                    er.ErrorDGr();
                    numError++;
                    break;
                }
                if (rct.h > pp.Hpp)
                {
                    massGr = 0;
                    VGr = 0;
                    gr.startPop.Clear();
                    er.ErrorHGr();
                    numError++;
                    break;
                }
                if (rct.w > pp.Wpp)
                {
                    massGr = 0;
                    VGr = 0;
                    gr.startPop.Clear();
                    er.ErrorWGr();
                    numError++;
                    break;
                }
                if (rct.d == 0 || rct.w == 0 || rct.h == 0 || rct.massRect == 0)
                {
                    massGr = 0;
                    VGr = 0;
                    gr.startPop.Clear();
                    er.ErrorGr0();
                    numError++;
                    break;
                }
                massGr = massGr + rct.massRect;
                VGr = VGr + rct.d * rct.h + rct.w;
                gr.startPop.Add(rct);
            }
            if (VGr > Vpp)
            {
                massGr = 0;
                VGr = 0;
                gr.startPop.Clear();
                er.ErrorVGr();
                numError++;
            }
            if (massGr > pp.MaxGruzPP)
            {
                massGr = 0;
                VGr = 0;
                gr.startPop.Clear();
                er.ErrorPGrMax();
                numError++;

            }
            startPopLoc = new RectLocation();
            startPopLoc.rects = gr.startPop;
            yOpt = searchXY.searchYopt(this);
            XYOpt = new PointC(pp.Wpp / 2, yOpt, 0);
            pp.searchMinMaxPP();
            // расстояние оси до оптимального y
            sXYoptOs = (pp.SPP - pp.SPP2) - yOpt;

            
            if (numError == 0)
            {
                if (gr.startPop.Count == 1)
                {
                    BestOsob = new RectLocation();
                    BestOsob.rects = gr.startPop;
                    BestOsob.rects[0].CT = XYOpt;
                    BestOsob.rects[0].ArrangeCoordinatesPointCT(BestOsob.rects[0].CT, 0);
                    BestOsob.CentrSumMass = XYOpt;
                    BestOsob.kEff = 0;
                    fr = new FormResult(BestOsob);
                    searchXY.PaintsDiagramm(this);
                    fr.ReadForm1(this);
                    fr.Show();
                
                }
                else
                {
                    ncub = dataGridView1.Rows.Count - 1;
                
                    double qmax = 1000000;
                    double psred = 0;
                    // НАЧАЛО ГА. ПЕРВОЕ РАЗМЕЩЕНИЕ В STARTPOP
                    Initpop();
                    gen = 0;
                    maxmass = new double[numgen];
                    sredmass = new double[numgen];
                    int p = 0;
                    for (int i = 0; i < numpop; i++)
                    {
                        oldpop[i].putRectagle(this); // коэффициент эффективности  - расстояние до потимальной точки

                        if (oldpop[i].kEff < qmax)
                        {
                            qmax = oldpop[i].kEff;
                            p = i;
                        }
                        psred += oldpop[i].kEff;
                    }
                    sredmass[0] = psred / (double)numpop;
                    maxmass[0] = qmax;
                    bestEffect = qmax;
                    BestOsob = oldpop[p];


                    chart1.Series[0].Points.AddXY(gen, maxmass[0]);
                    chart1.Series[1].Points.AddXY(gen, maxmass[0]);

                    for (int i = 1; i < numgen; i++)
                    {
                        gen++;
                        Console.WriteLine(gen.ToString());
                        generation(); // создаем новое поколение
                                      // chart1.Series[0].Points.AddXY(gen, maxmass[i]);
                        chart1.Series[0].Points.AddXY(gen, bestEffect);
                        chart1.Series[1].Points.AddXY(gen, maxmass[i]);
                        oldpop.Clear();
                        for (int j = 0; j < newpop.Count; j++)
                        {
                            oldpop.Add(newpop[j]);
                        }
                        intpop.Clear();
                        newpop.Clear();
                    }

                    //// КОНЕЦ ГА. РЕЗУЛЬТАТ В FINISHPOP
                    fr = new FormResult(BestOsob);
                    searchXY.PaintsDiagramm(this);
                    fr.ReadForm1(this);
                    fr.Show();
                }
                
            }
        }

        private void btGA_Click(object sender, EventArgs e)
        {
            numpop = (int)numPopulation.Value;
            numgen = (int)numPok.Value;
            numCrossof = (double)numCross.Value;
            pmutation = (double)numMut.Value;
        }
        public void Initpop()
        {
            Random rnd = new Random();
            List<int> n = new List<int>();
            int p;
            for (int i = 0; i < ncub; i++)
            {
                n.Add(i);
            }

            for (int i = 0; i < numpop; i++) // перебираем все варианты размещения
            {
                //Console.WriteLine($"Особь {i}");
                List<RectagleC> q = new List<RectagleC>();
                for (int j = 0; j < ncub; j++)
                {
                    p = rnd.Next(0, n.Count);
                    RectagleC iop = new RectagleC(startPopLoc.rects[n[p]].w, startPopLoc.rects[n[p]].h, startPopLoc.rects[n[p]].d, startPopLoc.rects[n[p]].number, startPopLoc.rects[n[p]].massRect);
                    
                    q.Add(iop);
                    n.RemoveAt(p);
                    //Console.WriteLine($" Прямоугольник {j}. Ширина: {q[j].w}. Высота {q[j].h}");                    
                }
                RectLocation h = new RectLocation();
                h.rects = q;
                oldpop.Add(h);
                n.Clear();
                for (int k = 0; k < ncub; k++)
                {
                    n.Add(k);
                }
            }
        }

        public void generation() // создаем новое поколение
        {
            select(); // сортируем старое поколение, отсортированное поколение в intpop турнирный отбор=2

            for (int i = 0; i < intpop.Count; i += 2) // создаем потомков
            {
                if (i + 1 >= intpop.Count)
                {
                    break;
                }
                crossover(intpop[i], intpop[i + 1]);

            }

            int k = 0;
            while (newpop.Count < numpop) // заполняем новое поколение оставшимися лучшими старыми особями
            {
                newpop.Add(intpop[k]);
                k++;
            }
            int p = 0;
            double effect;
            double qmax = 1000000;
            double psred = 0;

            for (int i = 0; i < numpop; i++)
            {
                newpop[i].putRectagle(this); // коэффициент эффективности 
                                                 //Console.WriteLine($"Особь {i} КЕ {effect}");
                if (newpop[i].kEff< qmax)
                {
                    qmax = newpop[i].kEff;
                    p = i;
                }
                psred += newpop[i].kEff;
            }
            maxmass[gen] = qmax;
            sredmass[gen] = psred / (double)numpop;
            if (bestEffect > qmax)
            {
                bestEffect = qmax;
                BestOsob = newpop[p];
            }

        }

        public void crossover(RectLocation par1, RectLocation par2)
        {
           
            RectLocation child1 = new RectLocation();
            for (int i = 0; i < ncub; i++)
            {
                RectagleC n = new RectagleC();

                child1.rects.Add(n);
            }
            RectLocation child2 = new RectLocation();
            for (int i = 0; i < ncub; i++)
            {
                RectagleC n = new RectagleC();
                child2.rects.Add(n);
            }
            List<RectagleC> listR = new List<RectagleC>();
            Random rnd = new Random();
            int p1, p2;
            double pcross;
            double pmut1;
            double pmut2;
            pcross = rnd.NextDouble();
            int sredncub = 0;
            if (pcross <= numCrossof)
            {

                // выставляем точки кроссовера
                p1 = rnd.Next(1, ncub - 3);
                p2 = rnd.Next(p1 + 1, ncub - 2);

                // создаем 1 потомка

                // заполняем центральные промежуток
                for (int i = p1; i <= p2; i++)
                {

                    child1.rects[i] = par1.rects[i];
                }

                bool inCentr = false;
                // проверяем  оставшиеся элементы второго родителя  на наличие в центре первого потомка
                for (int i = p2 + 1; i < ncub; i++) // проверяем конечный отрезок
                {
                    for (int j = p1; j <= p2; j++)
                    {
                        if (par2.rects[i].number == child1.rects[j].number)
                        {
                            inCentr = true;
                        }
                    }
                    if (!inCentr)
                    {
                        listR.Add(par2.rects[i]);
                    }
                    inCentr = false;
                }
                for (int i = 0; i <= p2; i++) // проверяем начальный и центральный отрезок
                {
                    for (int j = p1; j <= p2; j++)
                    {
                        if (par2.rects[i].number == child1.rects[j].number)
                        {
                            inCentr = true;
                        }
                    }
                    if (!inCentr)
                    {
                        listR.Add(par2.rects[i]);
                    }
                    inCentr = false;
                }
                for (int i = p2 + 1; i < ncub; i++) // заполняем конечный отрезок потомка
                {
                    child1.rects[i] = listR[0];
                    listR.RemoveAt(0);
                }
                for (int i = 0; i <= p1 - 1; i++) // проверяем начальный отрезок
                {
                    child1.rects[i] = listR[0];
                    listR.RemoveAt(0);
                }

                // Создаем 2 потомка

                // заполняем центральные промежуток
                for (int i = p1; i <= p2; i++)
                {
                    child2.rects[i] = par2.rects[i];
                }

                // проверяем  оставшиеся элементы второго родителя  на наличие в центре первого потомка
                for (int i = p2 + 1; i < ncub; i++) // проверяем конечный отрезок
                {
                    for (int j = p1; j <= p2; j++)
                    {
                        if (par1.rects[i].number == child2.rects[j].number)
                        {
                            inCentr = true;
                        }
                    }
                    if (!inCentr)
                    {
                        listR.Add(par1.rects[i]);
                    }
                    inCentr = false;
                }
                for (int i = 0; i <= p2; i++) // проверяем начальный и центральный отрезок
                {
                    for (int j = p1; j <= p2; j++)
                    {
                        if (par1.rects[i].number == child2.rects[j].number)
                        {
                            inCentr = true;
                        }
                    }
                    if (!inCentr)
                    {
                        listR.Add(par1.rects[i]);
                    }
                    inCentr = false;
                }
                for (int i = p2 + 1; i < ncub; i++) // заполняем конечный отрезок потомка
                {
                    child2.rects[i] = listR[0];
                    listR.RemoveAt(0);
                }
                for (int i = 0; i <= p1 - 1; i++) // проверяем начальный и центральный отрезок
                {
                    child2.rects[i] = listR[0];
                    listR.RemoveAt(0);
                }
                pmut1 = rnd.NextDouble();
                if (pmut1 >= pmutation)
                {
                    child1 = mutation(child1);
                }
                pmut2 = rnd.NextDouble();
                if (pmut2 >= pmutation)
                {
                    child2 = mutation(child2);
                }

                RectLocation q1 = new RectLocation();

                for (int i = 0; i < ncub; i++)
                {
                    RectagleC c = new RectagleC(child1.rects[i].w, child1.rects[i].h, child1.rects[i].d, child1.rects[i].number, child1.rects[i].massRect);
                    q1.rects.Add(c);
                }

                RectLocation q2 = new RectLocation();

                for (int i = 0; i < ncub; i++)
                {
                    RectagleC c = new RectagleC(child2.rects[i].w, child2.rects[i].h, child2.rects[i].d, child2.rects[i].number, child2.rects[i].massRect);
                    q2.rects.Add(c);
                }
                newpop.Add(q1);
                newpop.Add(q2);
            }

        }

        public RectLocation mutation(RectLocation osob)
        {
            Random rnd = new Random();
            int p = rnd.Next(0, ncub - 2);
            RectagleC m = new RectagleC();
            m = osob.rects[p];
            osob.rects[p] = osob.rects[p + 1];
            osob.rects[p + 1] = m;
            return (osob);
        }

        //public void select() // сортируем старое поколение
        //{
        //    Random rnd = new Random();
        //    List<int> n = new List<int>();
        //    int p1;
        //    int p2;
        //    RectLocation Osob1 = new RectLocation();
        //    RectLocation Osob2 = new RectLocation();
        //    for (int i = 0; i < numpop; i++)
        //    {
        //        n.Add(i);
        //    }

        //    for (int i = 0; i < numpop; i++)
        //    {
        //        p1 = rnd.Next(0, n.Count - 1); // выбрали случайное число
        //        Osob1 = oldpop[n[p1]]; // выбрали 1 особь под этим номером                    
        //        n.RemoveAt(p1); // удалили номер особи из вариантов 

        //        p2 = rnd.Next(0, n.Count - 1); // выбрали случайное число из оставшихся вариантов
        //        Osob2 = oldpop[n[p2]]; // выбрали 2 особь под этим номером
        //        if ((Osob1.lucky && (Osob2.lucky)))
        //        {
        //            if (Osob1.kEff <= Osob2.kEff)
        //            {
        //                intpop.Add(Osob1);
        //            }
        //            else
        //            {
        //                intpop.Add(Osob2);

        //            }
        //            n.Clear();
        //            for (int k = 0; k < numpop; k++)
        //            {
        //                n.Add(k);
        //            }
        //        }
        //        else
        //        {
        //            if (Osob1.lucky)
        //            {
        //                intpop.Add(Osob1);
        //            }
        //            if (Osob2.lucky)
        //            {
        //                intpop.Add(Osob2);
        //            }
        //            n.Clear();
        //            for (int k = 0; k < numpop; k++)
        //            {
        //                n.Add(k);
        //            }

        //        }

        //    }
        //}

        public void select() // сортируем старое поколение
        {
            List <RectLocation> list = new List <RectLocation>();
            list = oldpop;
            RectLocation temp = new RectLocation();
            
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        if (list[i].kEff < list[i].kEff)
                    {
                            temp = list[i];
                            list[i] = list[j];
                            list[j] = temp;
                        }
                    }
                }
            for (int i=0; i< list.Count-(int)(list.Count/3); i++)
            {
                intpop.Add(list[i]);
            }
        }


    }
}