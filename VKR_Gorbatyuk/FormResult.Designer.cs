using System.Drawing;

namespace VKR_Gorbatyuk
{
    partial class FormResult
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartMaxPpp = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbPP3Z = new System.Windows.Forms.Label();
            this.lbPP2Z = new System.Windows.Forms.Label();
            this.lbPP1Z = new System.Windows.Forms.Label();
            this.lbT3Z = new System.Windows.Forms.Label();
            this.lbT2Z = new System.Windows.Forms.Label();
            this.lbPttZ = new System.Windows.Forms.Label();
            this.lbT1Z = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPP3 = new System.Windows.Forms.Label();
            this.lbPP1 = new System.Windows.Forms.Label();
            this.lbPtt = new System.Windows.Forms.Label();
            this.lbT3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbPP2 = new System.Windows.Forms.Label();
            this.lbT2 = new System.Windows.Forms.Label();
            this.lbT1 = new System.Windows.Forms.Label();
            this.pictureBoxResultTPP = new System.Windows.Forms.PictureBox();
            this.lbGruzCount = new System.Windows.Forms.Label();
            this.lbmassGR = new System.Windows.Forms.Label();
            this.lbPP = new System.Windows.Forms.Label();
            this.lbT = new System.Windows.Forms.Label();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbInf = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.lbCTGR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartMaxPpp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultTPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartMaxPpp
            // 
            this.chartMaxPpp.BackColor = System.Drawing.Color.Transparent;
            this.chartMaxPpp.BackImage = "D:\\Загрузки\\pngwing.com.png";
            this.chartMaxPpp.BackImageTransparentColor = System.Drawing.Color.Transparent;
            this.chartMaxPpp.BackSecondaryColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisX.Minimum = 0D;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.Interval = 1000D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            this.chartMaxPpp.ChartAreas.Add(chartArea1);
            this.chartMaxPpp.Location = new System.Drawing.Point(205, 25);
            this.chartMaxPpp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chartMaxPpp.Name = "chartMaxPpp";
            this.chartMaxPpp.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            series1.Name = "Series1";
            this.chartMaxPpp.Series.Add(series1);
            this.chartMaxPpp.Size = new System.Drawing.Size(852, 185);
            this.chartMaxPpp.TabIndex = 0;
            this.chartMaxPpp.Text = "chart1";
            this.chartMaxPpp.Click += new System.EventHandler(this.chartMaxPpp_Click_1);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.lbPP3Z);
            this.panel1.Controls.Add(this.lbPP2Z);
            this.panel1.Controls.Add(this.lbPP1Z);
            this.panel1.Controls.Add(this.lbT3Z);
            this.panel1.Controls.Add(this.lbT2Z);
            this.panel1.Controls.Add(this.lbPttZ);
            this.panel1.Controls.Add(this.lbT1Z);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbPP3);
            this.panel1.Controls.Add(this.chartMaxPpp);
            this.panel1.Controls.Add(this.lbPP1);
            this.panel1.Controls.Add(this.lbPtt);
            this.panel1.Controls.Add(this.lbT3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbPP2);
            this.panel1.Controls.Add(this.lbT2);
            this.panel1.Controls.Add(this.lbT1);
            this.panel1.Controls.Add(this.pictureBoxResultTPP);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 389);
            this.panel1.TabIndex = 2;
            // 
            // lbPP3Z
            // 
            this.lbPP3Z.AutoSize = true;
            this.lbPP3Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP3Z.ForeColor = System.Drawing.Color.Green;
            this.lbPP3Z.Location = new System.Drawing.Point(881, 353);
            this.lbPP3Z.Name = "lbPP3Z";
            this.lbPP3Z.Size = new System.Drawing.Size(23, 25);
            this.lbPP3Z.TabIndex = 17;
            this.lbPP3Z.Text = "0";
            this.lbPP3Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPP2Z
            // 
            this.lbPP2Z.AutoSize = true;
            this.lbPP2Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP2Z.ForeColor = System.Drawing.Color.Green;
            this.lbPP2Z.Location = new System.Drawing.Point(789, 353);
            this.lbPP2Z.Name = "lbPP2Z";
            this.lbPP2Z.Size = new System.Drawing.Size(23, 25);
            this.lbPP2Z.TabIndex = 16;
            this.lbPP2Z.Text = "0";
            this.lbPP2Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPP1Z
            // 
            this.lbPP1Z.AutoSize = true;
            this.lbPP1Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP1Z.ForeColor = System.Drawing.Color.Green;
            this.lbPP1Z.Location = new System.Drawing.Point(701, 353);
            this.lbPP1Z.Name = "lbPP1Z";
            this.lbPP1Z.Size = new System.Drawing.Size(23, 25);
            this.lbPP1Z.TabIndex = 15;
            this.lbPP1Z.Text = "0";
            this.lbPP1Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbT3Z
            // 
            this.lbT3Z.AutoSize = true;
            this.lbT3Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT3Z.ForeColor = System.Drawing.Color.Green;
            this.lbT3Z.Location = new System.Drawing.Point(412, 353);
            this.lbT3Z.Name = "lbT3Z";
            this.lbT3Z.Size = new System.Drawing.Size(23, 25);
            this.lbT3Z.TabIndex = 14;
            this.lbT3Z.Text = "0";
            this.lbT3Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbT2Z
            // 
            this.lbT2Z.AutoSize = true;
            this.lbT2Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT2Z.ForeColor = System.Drawing.Color.Green;
            this.lbT2Z.Location = new System.Drawing.Point(319, 353);
            this.lbT2Z.Name = "lbT2Z";
            this.lbT2Z.Size = new System.Drawing.Size(23, 25);
            this.lbT2Z.TabIndex = 13;
            this.lbT2Z.Text = "0";
            this.lbT2Z.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPttZ
            // 
            this.lbPttZ.AutoSize = true;
            this.lbPttZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPttZ.ForeColor = System.Drawing.Color.Green;
            this.lbPttZ.Location = new System.Drawing.Point(233, 353);
            this.lbPttZ.Name = "lbPttZ";
            this.lbPttZ.Size = new System.Drawing.Size(23, 25);
            this.lbPttZ.TabIndex = 12;
            this.lbPttZ.Text = "0";
            this.lbPttZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbT1Z
            // 
            this.lbT1Z.AutoSize = true;
            this.lbT1Z.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT1Z.ForeColor = System.Drawing.Color.Green;
            this.lbT1Z.Location = new System.Drawing.Point(101, 353);
            this.lbT1Z.Name = "lbT1Z";
            this.lbT1Z.Size = new System.Drawing.Size(23, 25);
            this.lbT1Z.TabIndex = 11;
            this.lbT1Z.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 32);
            this.label1.TabIndex = 10;
            this.label1.Text = "Запас\r\nнагрузки";
            // 
            // lbPP3
            // 
            this.lbPP3.AutoEllipsis = true;
            this.lbPP3.AutoSize = true;
            this.lbPP3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP3.ForeColor = System.Drawing.Color.Green;
            this.lbPP3.Location = new System.Drawing.Point(881, 304);
            this.lbPP3.Name = "lbPP3";
            this.lbPP3.Size = new System.Drawing.Size(23, 25);
            this.lbPP3.TabIndex = 9;
            this.lbPP3.Text = "0";
            this.lbPP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPP1
            // 
            this.lbPP1.AutoSize = true;
            this.lbPP1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP1.ForeColor = System.Drawing.Color.Green;
            this.lbPP1.Location = new System.Drawing.Point(701, 304);
            this.lbPP1.Name = "lbPP1";
            this.lbPP1.Size = new System.Drawing.Size(23, 25);
            this.lbPP1.TabIndex = 8;
            this.lbPP1.Text = "0";
            this.lbPP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPtt
            // 
            this.lbPtt.AutoSize = true;
            this.lbPtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPtt.ForeColor = System.Drawing.Color.Green;
            this.lbPtt.Location = new System.Drawing.Point(233, 304);
            this.lbPtt.Name = "lbPtt";
            this.lbPtt.Size = new System.Drawing.Size(23, 25);
            this.lbPtt.TabIndex = 7;
            this.lbPtt.Text = "0";
            this.lbPtt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbT3
            // 
            this.lbT3.AutoSize = true;
            this.lbT3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT3.ForeColor = System.Drawing.Color.Green;
            this.lbT3.Location = new System.Drawing.Point(412, 304);
            this.lbT3.Name = "lbT3";
            this.lbT3.Size = new System.Drawing.Size(23, 25);
            this.lbT3.TabIndex = 6;
            this.lbT3.Text = "0";
            this.lbT3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 32);
            this.label4.TabIndex = 5;
            this.label4.Text = "Фактическая\r\nнагрузка";
            // 
            // lbPP2
            // 
            this.lbPP2.AutoSize = true;
            this.lbPP2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP2.ForeColor = System.Drawing.Color.Green;
            this.lbPP2.Location = new System.Drawing.Point(789, 304);
            this.lbPP2.Name = "lbPP2";
            this.lbPP2.Size = new System.Drawing.Size(23, 25);
            this.lbPP2.TabIndex = 4;
            this.lbPP2.Text = "0";
            this.lbPP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbT2
            // 
            this.lbT2.AutoSize = true;
            this.lbT2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT2.ForeColor = System.Drawing.Color.Green;
            this.lbT2.Location = new System.Drawing.Point(319, 304);
            this.lbT2.Name = "lbT2";
            this.lbT2.Size = new System.Drawing.Size(23, 25);
            this.lbT2.TabIndex = 3;
            this.lbT2.Text = "0";
            this.lbT2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbT1
            // 
            this.lbT1.AutoSize = true;
            this.lbT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT1.ForeColor = System.Drawing.Color.Green;
            this.lbT1.Location = new System.Drawing.Point(101, 304);
            this.lbT1.Name = "lbT1";
            this.lbT1.Size = new System.Drawing.Size(23, 25);
            this.lbT1.TabIndex = 2;
            this.lbT1.Text = "0";
            // 
            // pictureBoxResultTPP
            // 
            this.pictureBoxResultTPP.Image = global::VKR_Gorbatyuk.Properties.Resources.t3PP3;
            this.pictureBoxResultTPP.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxResultTPP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxResultTPP.Name = "pictureBoxResultTPP";
            this.pictureBoxResultTPP.Size = new System.Drawing.Size(1104, 302);
            this.pictureBoxResultTPP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxResultTPP.TabIndex = 0;
            this.pictureBoxResultTPP.TabStop = false;
            // 
            // lbGruzCount
            // 
            this.lbGruzCount.AutoSize = true;
            this.lbGruzCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbGruzCount.Location = new System.Drawing.Point(1137, 92);
            this.lbGruzCount.Name = "lbGruzCount";
            this.lbGruzCount.Size = new System.Drawing.Size(169, 20);
            this.lbGruzCount.TabIndex = 21;
            this.lbGruzCount.Text = "Количество груза: ";
            // 
            // lbmassGR
            // 
            this.lbmassGR.AutoSize = true;
            this.lbmassGR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbmassGR.Location = new System.Drawing.Point(1137, 65);
            this.lbmassGR.Name = "lbmassGR";
            this.lbmassGR.Size = new System.Drawing.Size(121, 20);
            this.lbmassGR.TabIndex = 20;
            this.lbmassGR.Text = "Масса груза: ";
            // 
            // lbPP
            // 
            this.lbPP.AutoSize = true;
            this.lbPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbPP.Location = new System.Drawing.Point(1137, 38);
            this.lbPP.Name = "lbPP";
            this.lbPP.Size = new System.Drawing.Size(120, 20);
            this.lbPP.TabIndex = 19;
            this.lbPP.Text = "Полуприцеп: ";
            // 
            // lbT
            // 
            this.lbT.AutoSize = true;
            this.lbT.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbT.Location = new System.Drawing.Point(1137, 11);
            this.lbT.Name = "lbT";
            this.lbT.Size = new System.Drawing.Size(67, 20);
            this.lbT.TabIndex = 18;
            this.lbT.Text = "Тягач: ";
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.Location = new System.Drawing.Point(7, 395);
            this.openGLControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(1104, 446);
            this.openGLControl1.TabIndex = 3;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl1_OpenGLDraw);
            this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.openGLControl1_KeyDown);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1141, 395);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(383, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "Показать полную расстановку";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1141, 441);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(383, 38);
            this.button2.TabIndex = 5;
            this.button2.Text = "Добавить следующий груз";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1141, 486);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(383, 38);
            this.button3.TabIndex = 6;
            this.button3.Text = "Очистить Полуприцеп";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.lbInf);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(1141, 533);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(383, 308);
            this.panel2.TabIndex = 7;
            // 
            // lbInf
            // 
            this.lbInf.AutoSize = true;
            this.lbInf.Location = new System.Drawing.Point(4, 39);
            this.lbInf.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbInf.Name = "lbInf";
            this.lbInf.Size = new System.Drawing.Size(0, 16);
            this.lbInf.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(4, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Координаты груза";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1203, 337);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(256, 52);
            this.button4.TabIndex = 19;
            this.button4.Text = "Сохранить";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lbCTGR
            // 
            this.lbCTGR.AutoSize = true;
            this.lbCTGR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbCTGR.Location = new System.Drawing.Point(1137, 119);
            this.lbCTGR.Name = "lbCTGR";
            this.lbCTGR.Size = new System.Drawing.Size(292, 40);
            this.lbCTGR.TabIndex = 22;
            this.lbCTGR.Text = "Координа точки центра тяжести \r\nгруза: ";
            // 
            // FormResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1532, 846);
            this.Controls.Add(this.lbCTGR);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbGruzCount);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lbmassGR);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbPP);
            this.Controls.Add(this.lbT);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(2661, 3066);
            this.Name = "FormResult";
            this.Text = "FormResult";
            this.Load += new System.EventHandler(this.FormResult_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartMaxPpp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResultTPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chartMaxPpp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbPP2;
        private System.Windows.Forms.Label lbT2;
        private System.Windows.Forms.Label lbT1;
        private System.Windows.Forms.PictureBox pictureBoxResultTPP;
        private System.Windows.Forms.Label lbPP3;
        private System.Windows.Forms.Label lbPP1;
        private System.Windows.Forms.Label lbPtt;
        private System.Windows.Forms.Label lbT3;
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.Label lbPP3Z;
        private System.Windows.Forms.Label lbPP2Z;
        private System.Windows.Forms.Label lbPP1Z;
        private System.Windows.Forms.Label lbT3Z;
        private System.Windows.Forms.Label lbT2Z;
        private System.Windows.Forms.Label lbPttZ;
        private System.Windows.Forms.Label lbT1Z;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbInf;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lbGruzCount;
        private System.Windows.Forms.Label lbmassGR;
        private System.Windows.Forms.Label lbPP;
        private System.Windows.Forms.Label lbT;
        private System.Windows.Forms.Label lbCTGR;
    }
}