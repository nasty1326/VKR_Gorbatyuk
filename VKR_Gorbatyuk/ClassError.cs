using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VKR_Gorbatyuk
{
    internal class ClassError
    {

        public void ErrorST()
        {
            Form form = new FormError("Ошибка параметров расстояний тягача", "Cумма расстояний от передней оси тягача до седла и от седла до задней оси тягача не равна расстоянию между осями тягача.");
            form.Show();
        }
        public void ErrorPT()
        {
            Form form = new FormError("Ошибка параметров нагрузок тягача", "Cумма нагрузок на оси пустого тягача не равны массе тягача");
            form.Show();
        }
        public void ErrorPT1Max()
        {
            Form form = new FormError("Ошибка ограничения на 1 ось тягача", "Ограничение на первую ось тягача меньше нагрузки на эту ось");
            form.Show();
        }
        public void ErrorPT2Max()
        {
            Form form = new FormError("Ошибка ограничения на 2 ось тягача", "Ограничение на вторую ось тягача меньше нагрузки на эту ось");
            form.Show();
        }
        public void ErrorSPP()
        {
            Form form = new FormError("Ошибка параметров расстояний полуприцепа", "Cумма расстояний от седла до оси полуприцепа и от оси полуприцепа до задней стенки больше полезной глубины полуприцепа");
            form.Show();
        }
        public void ErrorPpp()
        {
            Form form = new FormError("Ошибка параметров нагрузок полуприцепа", "Cумма нагрузок на ось пустого полуприцепа и нагрузки на седло не равна массе полуприцепа");
            form.Show();
        }
        public void ErrorPppTMax()
        {
            Form form = new FormError("Ошибка ограничения на седло", "Ограничение на седло меньше нагрузки на седло");
            form.Show();
        }
        public void ErrorPpp1Max()
        {
            Form form = new FormError("Ошибка ограничения на ось полуприцепа", "Ограничение на ось полуприцепа меньше нагрузки на эту ось");
            form.Show();
        }
        public void ErrorPGrMax()
        {
            Form form = new FormError("Ошибка суммарной массы груза", "Cуммарная масса груза превышает максимальную грузоподъемность полуприцепа");
            form.Show();
        }
        public void ErrorWGr()
        {
            Form form = new FormError("Ошибка ширины груза", "Ширина какого-либо груза превышает ширину полуприцепа");
            form.Show();
        }
        public void ErrorHGr()
        {
            Form form = new FormError("Ошибка высоты груза", "Высота какого-либо груза превышает высоту полуприцепа");
            form.Show();
        }
        public void ErrorDGr()
        {
            Form form = new FormError("Ошибка глубины груза", "Глубина какого-либо груза превышает глубину полуприцепа");
            form.Show();
        }
        public void ErrorVGr()
        {
            Form form = new FormError("Ошибка объема груза", "Суммарный объем груза больше объема полуприцепа");
            form.Show();
        }
        public void ErrorGr0()
        {
            Form form = new FormError("Ошибка значения параметра груза", "Высота, ширина, глубина или масса груза равны 0");
            form.Show();
        }
        public void ErrorNotData(int cl)
        {
            if (cl == 1)
            {
                Form form = new FormError("Введите параметры тягача", "Не забудьте нажать (Выбрать)");
                form.Show();
            }
            if (cl == 2)
            {
                Form form = new FormError("Введите параметры полуприцепа", "Не забудьте нажать (Выбрать)");
                form.Show();
            }
            if (cl == 3)
            {
                Form form = new FormError("Введите параметры груза", " ");
                form.Show();
            }

        }
    }
}
