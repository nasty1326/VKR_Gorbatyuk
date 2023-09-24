using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Assets;
using SharpGL.SceneGraph.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SharpGL.SceneGraph.Lighting;

using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;
using System.IO;

namespace VKR_Gorbatyuk
{
    public partial class FormResult : Form
    {
       
        RectLocation best;
        Form1 f1;
        ClassPOsi osi;

        Camera cam;
        private List<ShapeRenderer> listShape = new List<ShapeRenderer>();

        public FormResult(RectLocation Best)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            best = Best;
          
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            //  A bit of extra initialisation here, we have to enable textures.
            gl.Enable(OpenGL.GL_TEXTURE_2D);

            //  Create our texture object from a file. This creates the texture for OpenGL.
            texture.Create(gl, "Crate.bmp");

            
            Light light = new Light()
            {
                On = true,
                Position = new Vertex(0, 0, 0),
                GLCode = OpenGL.GL_LIGHT0
            };
            

            //Camera numbers set up
            float fov = 70.0f,
                aspect = (float)openGLControl1.Width / (float)openGLControl1.Height,
                zNear = 0.1f,
                zFar = 100.0f;
            Vertex eyeVertex = new Vertex(6.8f, 5.0f, 7.0f);
            Vertex centerVertex = new Vertex(6.8f, 1.35f, 0.0f);
            Vertex upVertex = new Vertex(0.0f, 1.0f, 0.0f);


            cam = new Camera(gl, fov, aspect, zNear, zFar, eyeVertex, centerVertex, upVertex);
            
        }
        //  The texture identifier.
        Texture texture = new Texture();

        public void ReadForm1 (Form1 _f1)
        {
            f1= _f1;
        }
        private void chartMaxPpp_Click_1(object sender, EventArgs e)
        {

        }
        double Nn1 = 0;
        double Nn = 0;
        double Nn2 = 0;
        double Nn3 = 0;
        private void FormResult_Load(object sender, EventArgs e)
        {
            osi = new ClassPOsi();
            Nn = osi.N(f1, f1.massGr, f1.pp.SPP - f1.pp.SPP2 - best.CentrSumMass.y);
            Nn3 = osi.N3(f1, f1.massGr, Nn);
            Nn2 = osi.N2(f1, Nn);
            Nn1 = osi.N1(f1, Nn, Nn2);

            if (f1.t.osT == 2 && f1.pp.osPP == 1)
            {
                pictureBoxResultTPP.Image = VKR_Gorbatyuk.Properties.Resources.t2PP1;
                Point c = new Point(194, 247);
                lbPtt.Location = c;
                c = new Point(257, 247);
                lbT2.Location = c;
                lbT3.Visible = false;
                c = new Point(586, 247);
                lbPP1.Location = c;
                lbPP2.Visible = false;
                lbPP3.Visible = false;


                c = new Point(194, 287);
                lbPttZ.Location = c;
                c = new Point(257, 287);
                lbT2Z.Location = c;
                lbT3Z.Visible = false;
                c = new Point(586, 287);
                lbPP1Z.Location = c;
                lbPP2Z.Visible = false;
                lbPP3Z.Visible = false;

                lbPtt.Text = Math.Round(Nn).ToString();
                lbT1.Text = Math.Round(Nn1).ToString();
                lbT2.Text = Math.Round(Nn2).ToString();
                lbPP1.Text = Math.Round(Nn3).ToString();

                lbPttZ.Text = Math.Round(f1.pp.MaxPppT - Nn).ToString();
                if (f1.pp.MaxPppT - Nn < 0)
                {
                    lbPtt.ForeColor = Color.Red;
                    lbPttZ.ForeColor = Color.Red;
                }
                lbT1Z.Text = Math.Round(f1.t.MaxPT1 - Nn1).ToString();
                if (f1.t.MaxPT1 - Nn1 < 0)
                {
                    lbT1Z.ForeColor = Color.Red;
                    lbT1.ForeColor = Color.Red;
                }
                lbT2Z.Text = Math.Round(f1.t.MaxPT2 - Nn2).ToString();
                if (f1.t.MaxPT2 - Nn2 < 0)
                {
                    lbT2Z.ForeColor = Color.Red;
                    lbT2.ForeColor = Color.Red;
                }
                lbPP1Z.Text = Math.Round(f1.pp.MaxPpp1 - Nn3).ToString();
                if (f1.pp.MaxPpp1 - Nn3 < 0)
                {
                    lbPP1Z.ForeColor = Color.Red;
                    lbPP1.ForeColor = Color.Red;
                }
            }
            if (f1.t.osT == 2 && f1.pp.osPP == 2)
            {
                pictureBoxResultTPP.Image = VKR_Gorbatyuk.Properties.Resources.t2PP2;
                Point c = new Point(194, 247);
                lbPtt.Location = c;
                c = new Point(257, 247);
                lbT2.Location = c;
                lbT3.Visible = false;
                c = new Point(563, 247);
                lbPP1.Location = c;
                c = new Point(627, 247);
                lbPP2.Location = c;
                lbPP3.Visible = false;

                c = new Point(194, 287);
                lbPttZ.Location = c;
                c = new Point(257, 287);
                lbT2Z.Location = c;
                lbT3Z.Visible = false;
                c = new Point(563, 287);
                lbPP1Z.Location = c;
                c = new Point(627, 287);
                lbPP2Z.Location = c;
                lbPP3Z.Visible = false;

                lbPtt.Text = Math.Round(Nn).ToString();
                lbT1.Text = Math.Round(Nn1).ToString();
                lbT2.Text = Math.Round(Nn2).ToString();
                lbPP1.Text = Math.Round(Nn3 / 2).ToString();
                lbPP2.Text = Math.Round(Nn3 / 2).ToString();

                lbPttZ.Text = Math.Round(f1.pp.MaxPppT - Nn).ToString();
                if (f1.pp.MaxPppT - Nn < 0)
                {
                    lbPtt.ForeColor = Color.Red;
                    lbPttZ.ForeColor = Color.Red;
                }
                lbT1Z.Text = Math.Round(f1.t.MaxPT1 - Nn1).ToString();
                if (f1.t.MaxPT1 - Nn1 < 0)
                {
                    lbT1Z.ForeColor = Color.Red;
                    lbT1.ForeColor = Color.Red;
                }
                lbT2Z.Text = Math.Round(f1.t.MaxPT2 - Nn2).ToString();
                if (f1.t.MaxPT2 - Nn2 < 0)
                {
                    lbT2Z.ForeColor = Color.Red;
                    lbT2.ForeColor = Color.Red;
                }
                lbPP1Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 2).ToString();
                if (f1.pp.MaxPpp1 - Nn3 < 0)
                {
                    lbPP1Z.ForeColor = Color.Red;
                    lbPP1.ForeColor = Color.Red;
                    lbPP2Z.ForeColor = Color.Red;
                    lbPP2.ForeColor = Color.Red;
                }
                lbPP2Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 2).ToString();

            }
            if (f1.t.osT == 2 && f1.pp.osPP == 3)
            {
                pictureBoxResultTPP.Image = VKR_Gorbatyuk.Properties.Resources.t2PP3;
                Point c = new Point(194, 247);
                lbPtt.Location = c;
                c = new Point(257, 247);
                lbT2.Location = c;
                lbT3.Visible = false;
                c = new Point(524, 247);
                lbPP1.Location = c;
                c = new Point(592, 247);
                lbPP2.Location = c;
                c = new Point(659, 247);
                lbPP3.Location = c;

                c = new Point(194, 287);
                lbPttZ.Location = c;
                c = new Point(257, 287);
                lbT2Z.Location = c;
                lbT3Z.Visible = false;
                c = new Point(524, 287);
                lbPP1Z.Location = c;
                c = new Point(592, 287);
                lbPP2Z.Location = c;
                c = new Point(659, 287);
                lbPP3Z.Location = c;

                lbPtt.Text = Math.Round(Nn).ToString();
                lbT1.Text = Math.Round(Nn1).ToString();
                lbT2.Text = Math.Round(Nn2).ToString();
                lbPP1.Text = Math.Round(Nn3 / 3).ToString();
                lbPP2.Text = Math.Round(Nn3 / 3).ToString();
                lbPP3.Text = Math.Round(Nn3 / 3).ToString();

                lbPttZ.Text = Math.Round(f1.pp.MaxPppT - Nn).ToString();
                if (f1.pp.MaxPppT - Nn < 0)
                {
                    lbPtt.ForeColor = Color.Red;
                    lbPttZ.ForeColor = Color.Red;
                }
                lbT1Z.Text = Math.Round(f1.t.MaxPT1 - Nn1).ToString();
                if (f1.t.MaxPT1 - Nn1 < 0)
                {
                    lbT1Z.ForeColor = Color.Red;
                    lbT1.ForeColor = Color.Red;
                }
                lbT2Z.Text = Math.Round(f1.t.MaxPT2 - Nn2).ToString();
                if (f1.t.MaxPT2 - Nn2 < 0)
                {
                    lbT2Z.ForeColor = Color.Red;
                    lbT2.ForeColor = Color.Red;
                }
                lbPP1Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 3).ToString();
                if (f1.pp.MaxPpp1 - Nn3 < 0)
                {
                    lbPP1Z.ForeColor = Color.Red;
                    lbPP1.ForeColor = Color.Red;
                    lbPP2Z.ForeColor = Color.Red;
                    lbPP2.ForeColor = Color.Red;
                    lbPP3Z.ForeColor = Color.Red;
                    lbPP3.ForeColor = Color.Red;
                }
                lbPP2Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 3).ToString();
                lbPP3Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 3).ToString();
            }
            if (f1.t.osT == 3 && f1.pp.osPP == 1)
            {
                pictureBoxResultTPP.Image = VKR_Gorbatyuk.Properties.Resources.t3PP1;
                Point c = new Point(175, 247);
                lbPtt.Location = c;
                c = new Point(239, 247);
                lbT2.Location = c;
                c = new Point(309, 247);
                lbT3.Location = c;
                c = new Point(589, 247);
                lbPP1.Location = c;
                lbPP2.Visible = false;
                lbPP3.Visible = false;


                c = new Point(175, 287);
                lbPttZ.Location = c;
                c = new Point(239, 287);
                lbT2Z.Location = c;
                c = new Point(309, 287);
                lbT3Z.Location = c;
                c = new Point(589, 287);
                lbPP1Z.Location = c;
                lbPP2Z.Visible = false;
                lbPP3Z.Visible = false;

                lbPtt.Text = Math.Round(Nn).ToString();
                lbT1.Text = Math.Round(Nn1).ToString();
                lbT2.Text = Math.Round(Nn2 / 2).ToString();
                lbT3.Text = Math.Round(Nn2 / 2).ToString();
                lbPP1.Text = Math.Round(Nn3).ToString();

                lbPttZ.Text = Math.Round(f1.pp.MaxPppT - Nn).ToString();
                if (f1.pp.MaxPppT - Nn < 0)
                {
                    lbPtt.ForeColor = Color.Red;
                    lbPttZ.ForeColor = Color.Red;
                }
                lbT1Z.Text = Math.Round(f1.t.MaxPT1 - Nn1).ToString();
                if (f1.t.MaxPT1 - Nn1 < 0)
                {
                    lbT1Z.ForeColor = Color.Red;
                    lbT1.ForeColor = Color.Red;
                }
                lbT2Z.Text = Math.Round((f1.t.MaxPT2 - Nn2) / 2).ToString();
                lbT3Z.Text = Math.Round((f1.t.MaxPT2 - Nn2) / 2).ToString();
                if (f1.t.MaxPT2 - Nn2 < 0)
                {
                    lbT2Z.ForeColor = Color.Red;
                    lbT2.ForeColor = Color.Red;
                    lbT3Z.ForeColor = Color.Red;
                    lbT3.ForeColor = Color.Red;
                }
                lbPP1Z.Text = Math.Round(f1.pp.MaxPpp1 - Nn3).ToString();
                if (f1.pp.MaxPpp1 - Nn3 < 0)
                {
                    lbPP1Z.ForeColor = Color.Red;
                    lbPP1.ForeColor = Color.Red;
                }
            }
            if (f1.t.osT == 3 && f1.pp.osPP == 2)
            {
                pictureBoxResultTPP.Image = VKR_Gorbatyuk.Properties.Resources.t3PP2;
                Point c = new Point(175, 247);
                lbPtt.Location = c;
                c = new Point(239, 247);
                lbT2.Location = c;
                c = new Point(309, 247);
                lbT3.Location = c;
                c = new Point(563, 247);
                lbPP1.Location = c;
                c = new Point(627, 247);
                lbPP2.Location = c;
                lbPP3.Visible = false;


                c = new Point(175, 287);
                lbPttZ.Location = c;
                c = new Point(239, 287);
                lbT2Z.Location = c;
                c = new Point(309, 287);
                lbT3Z.Location = c;
                c = new Point(563, 287);
                lbPP1Z.Location = c;
                c = new Point(627, 287);
                lbPP2Z.Location = c;
                lbPP3Z.Visible = false;


                lbPtt.Text = Math.Round(Nn).ToString();
                lbT1.Text = Math.Round(Nn1).ToString();
                lbT2.Text = Math.Round(Nn2 / 2).ToString();
                lbT3.Text = Math.Round(Nn2 / 2).ToString();
                lbPP1.Text = Math.Round(Nn3 / 2).ToString();
                lbPP2.Text = Math.Round(Nn3 / 2).ToString();

                lbPttZ.Text = Math.Round(f1.pp.MaxPppT - Nn).ToString();
                if (f1.pp.MaxPppT - Nn < 0)
                {
                    lbPtt.ForeColor = Color.Red;
                    lbPttZ.ForeColor = Color.Red;
                }
                lbT1Z.Text = Math.Round(f1.t.MaxPT1 - Nn1).ToString();
                if (f1.t.MaxPT1 - Nn1 < 0)
                {
                    lbT1Z.ForeColor = Color.Red;
                    lbT1.ForeColor = Color.Red;
                }
                lbT2Z.Text = Math.Round((f1.t.MaxPT2 - Nn2) / 2).ToString();
                lbT3Z.Text = Math.Round((f1.t.MaxPT2 - Nn2) / 2).ToString();
                if (f1.t.MaxPT2 - Nn2 < 0)
                {
                    lbT2Z.ForeColor = Color.Red;
                    lbT2.ForeColor = Color.Red;
                    lbT3Z.ForeColor = Color.Red;
                    lbT3.ForeColor = Color.Red;
                }
                lbPP1Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 2).ToString();
                if (f1.pp.MaxPpp1 - Nn3 < 0)
                {
                    lbPP1Z.ForeColor = Color.Red;
                    lbPP1.ForeColor = Color.Red;
                    lbPP2Z.ForeColor = Color.Red;
                    lbPP2.ForeColor = Color.Red;
                }
                lbPP2Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 2).ToString();
            }
            if (f1.t.osT == 3 && f1.pp.osPP == 3)
            {
                pictureBoxResultTPP.Image = VKR_Gorbatyuk.Properties.Resources.t3PP3;
                Point c = new Point(175, 247);
                lbPtt.Location = c;
                c = new Point(239, 247);
                lbT2.Location = c;
                c = new Point(309, 247);
                lbT3.Location = c;
                c = new Point(526, 247);
                lbPP1.Location = c;
                c = new Point(592, 247);
                lbPP2.Location = c;
                c = new Point(661, 247);
                lbPP3.Location = c;


                c = new Point(175, 287);
                lbPttZ.Location = c;
                c = new Point(239, 287);
                lbT2Z.Location = c;
                c = new Point(309, 287);
                lbT3Z.Location = c;
                c = new Point(526, 287);
                lbPP1Z.Location = c;
                c = new Point(592, 287);
                lbPP2Z.Location = c;
                c = new Point(661, 287);
                lbPP3Z.Location = c;

                lbPtt.Text = Math.Round(Nn).ToString();
                lbT1.Text = Math.Round(Nn1).ToString();
                lbT2.Text = Math.Round(Nn2 / 2).ToString();
                lbT3.Text = Math.Round(Nn2 / 2).ToString();
                lbPP1.Text = Math.Round(Nn3 / 3).ToString();
                lbPP2.Text = Math.Round(Nn3 / 3).ToString();
                lbPP3.Text = Math.Round(Nn3 / 3).ToString();

                lbPttZ.Text = Math.Round(f1.pp.MaxPppT - Nn).ToString();
                if (f1.pp.MaxPppT - Nn < 0)
                {
                    lbPtt.ForeColor = Color.Red;
                    lbPttZ.ForeColor = Color.Red;
                }
                lbT1Z.Text = Math.Round(f1.t.MaxPT1 - Nn1).ToString();
                if (f1.t.MaxPT1 - Nn1 < 0)
                {
                    lbT1Z.ForeColor = Color.Red;
                    lbT1.ForeColor = Color.Red;
                }
                lbT2Z.Text = Math.Round((f1.t.MaxPT2 - Nn2) / 2).ToString();
                lbT3Z.Text = Math.Round((f1.t.MaxPT2 - Nn2) / 2).ToString();
                if (f1.t.MaxPT2 - Nn2 < 0)
                {
                    lbT2Z.ForeColor = Color.Red;
                    lbT2.ForeColor = Color.Red;
                    lbT3Z.ForeColor = Color.Red;
                    lbT3.ForeColor = Color.Red;
                }
                lbPP1Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 3).ToString();
                if (f1.pp.MaxPpp1 - Nn3 < 0)
                {
                    lbPP1Z.ForeColor = Color.Red;
                    lbPP1.ForeColor = Color.Red;
                    lbPP2Z.ForeColor = Color.Red;
                    lbPP2.ForeColor = Color.Red;
                    lbPP3Z.ForeColor = Color.Red;
                    lbPP3.ForeColor = Color.Red;
                }
                lbPP2Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 3).ToString();
                lbPP3Z.Text = Math.Round((f1.pp.MaxPpp1 - Nn3) / 3).ToString();
            }

            best.SortRect();
            best.GetVertexRects();
            paintGruz();
            numbergr = best.rects.Count;
            lbGruzCount.Text = lbGruzCount.Text + best.rects.Count.ToString();
            lbT.Text = lbT.Text + f1.t.name;
            lbPP.Text = lbPP.Text + f1.pp.name;
            lbmassGR.Text = lbmassGR.Text + f1.massGr.ToString();
            lbCTGR.Text = lbCTGR.Text + $"({best.CentrSumMass.x}, {best.CentrSumMass.y})";
        }
        
        public void paintGruz()
        {
            
            for (int i = 0; i< best.rects.Count; i++)
            {
                string inf = $"Номер: {best.rects[i].number + 1}. Macca: {best.rects[i].massRect}\n Ширина/высота/глубина: {best.rects[i].w}, {best.rects[i].h}, {best.rects[i].d}\n Начальная координата: {best.rects[i].leftUpD1Point.x}, {best.rects[i].leftUpD1Point.z},{best.rects[i].leftUpD1Point.y} \n\n";
                lbInf.Text = lbInf.Text + inf;
            }
            listShape.Add(new ShapeRenderer(best));
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);



            gl.Color(1.0f, 1.0f, 1.0f);

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();

            cam.Look();

            gl.Disable(OpenGL.GL_TEXTURE_2D);
            PlaneSurfaceRenderer psr = new PlaneSurfaceRenderer((float)(f1.pp.SPP)/1000, (float)f1.pp.Hpp/1000, (float)f1.pp.Wpp/1000);
            psr.render(gl);


            texture.Bind(gl);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            foreach (ShapeRenderer shape in listShape)
            {
                shape.render(gl);
            }
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.X:
                    cam.ZoomIn();
                    break;
                case Keys.Z:
                    cam.ZoomOut();
                    break;
                case Keys.A:
                    cam.GoLeft();
                    break;
                case Keys.D:
                    cam.GoRight();
                    break;
                case Keys.W:
                    cam.GoUp();
                    break;
                case Keys.S:
                    cam.GoDown();
                    break;
                default:
                    break;
            }
            cam.Look();
        }

        //Показать полную расстановку
        private void button1_Click(object sender, EventArgs e)
        {
            paintGruz();
        }

        int numbergr=0;
        //Добавить следующий груз
        private void button2_Click(object sender, EventArgs e)
        {
            if (numbergr != (best.rects.Count))
            {
                listShape.Add(new ShapeRenderer(best.rects[numbergr]));

                string inf = $"Номер: {best.rects[numbergr].number+1}. Macca: {best.rects[numbergr].massRect}\n Ширина/высота/глубина: {best.rects[numbergr].w}, {best.rects[numbergr].h}, {best.rects[numbergr].d}\n Начальная координата: {best.rects[numbergr].leftUpD1Point.x}, {best.rects[numbergr].leftUpD1Point.z},{best.rects[numbergr].leftUpD1Point.y} \n\n";
                lbInf.Text = lbInf.Text+inf;
                numbergr++;
            }
            

        }

        //Очистить полуприцеп
        private void button3_Click(object sender, EventArgs e)
        {
            listShape.Clear();
            numbergr = 0;
            lbInf.Text = " ";
        }

        private void button4_Click(object sender, EventArgs e)
        {


            this.FormBorderStyle = FormBorderStyle.None;
            button1.Visible= false;
            button2.Visible= false;
            button3.Visible= false;
            button4.Visible= false;
            panel2.Visible= false;
           
            Graphics g = this.CreateGraphics();
            var bm = new Bitmap(this.Size.Width, this.Size.Height, g);
            Rectangle c = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
            this.DrawToBitmap(bm, c);
            
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.SelectedPath = @"C:\";
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
            {
                string path = folderBrowserDialog1.SelectedPath;
                string text=lbInf.Text;
               
                // Создаем папку, если ее нет
                Directory.CreateDirectory(path+"\\проб");
                path = path + "\\проб\\";
                File.WriteAllText(path + "Coordinaty.txt", text);
                bm.Save(path+ "picture_copy.bmp", ImageFormat.Jpeg);
            }

            this.FormBorderStyle = FormBorderStyle.Sizable;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            panel2.Visible = true;
        }
    }
    
}

