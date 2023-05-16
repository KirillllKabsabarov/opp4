using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace lab4._1
{
    public partial class Form1 : Form
    {
        private List<CCircle> FormCircles = new List<CCircle>();
        private int ctrl = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (CCircle Circle in FormCircles)
            {
                Circle.drawCircle(e.Graphics);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ctrl == 0)//не нажат ctrl
            {
                foreach (CCircle Circle1 in FormCircles)
                {
                    Circle1.setColor("Black");
                }
                CCircle Circle = new CCircle(e.X, e.Y, 60);
                FormCircles.Add(Circle);
            }
            if (ctrl == 1)//нажат
            {
                foreach (CCircle Circle1 in FormCircles)
                {
                    if (Circle1.checkCircle(e) == true && checkBox2.Checked == true)
                    {
                        break;
                    }
                }
                Refresh();
            }
            Refresh();
        }

       

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
            switch (ctrl)
            {
                case 0:
                    ctrl++;
                    foreach (CCircle Circle1 in FormCircles)
                    {
                        Circle1.setCtrl(true);
                    }
                    break;
                case 1:
                    ctrl = 0;
                    foreach (CCircle Circle1 in FormCircles)
                    {
                        Circle1.setCtrl(false);
                    }
                    break;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < FormCircles.Count(); i++)
            {
                if (FormCircles[i].getColor() == "Red")
                {
                    FormCircles.RemoveAt(i);
                    i--;
                }
            }
            Refresh();
        }
    }
    public class CCircle//описание объекта круга
    {
        private int x, y, radius;
        private string color = "Red";
        private bool ctrl = false;
        public CCircle(int xp, int yp, int radp)
        {
            x = xp;
            y = yp;
            radius = radp;

        }
        public void drawCircle(Graphics Canvas)//метод отрисовки круга
        {
            if (color == "Red")
            {
                Canvas.DrawEllipse(new Pen(Color.Blue), x - radius, y - radius, radius * 2, radius * 2);
            }
            else
            {
                Canvas.DrawEllipse(new Pen(Color.Black), x - radius, y - radius, radius * 2, radius * 2);
            }
        }
        public void setColor(string Color)//сеттер цвета круга
        {
            color = Color;
        }
        public string getColor()//геттер цвета круга
        {
            return color;
        }
        public bool checkCircle(MouseEventArgs e)//проверка на попадание курсора мыши во внутрь круга
        {
            if (ctrl)
            {
                if (Math.Pow(e.X - x, 2) + Math.Pow(e.Y - y, 2) <= Math.Pow(radius, 2) && color != "Red")
                {
                    color = "Red";
                    return true;
                }
            }
            return false;
        }
        public void setCtrl(bool a)
        {
            ctrl = a;
        }

    }
}
