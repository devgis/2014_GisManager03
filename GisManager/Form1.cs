using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
/*
 * 凸包问题
 * 使用方法：
 * 1.鼠标在窗体空白处随机点击
 * 2.点击凸包按钮，算法程序将勾画凸包边界
 * 3.第二次连续实验前，请点击清除按钮。
*/
namespace 凸包问题
{
    public partial class Form1 : Form
    {
        private Graphics g = null;                             //实例化绘图表面为null
        private Brush bPoint = Brushes.Green;                  //实例化填充对象bPoint表示点，填充色为绿色
        private Pen bLine=new Pen(Color.Red,1);                //实例化线条对象bLine，填充色为红色
        private List<Point> list = new List<Point>();          //实例化列表，对象为二维平面上的点
        public Form1()                                        
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)         //
        {
            g.FillEllipse(bPoint, e.X, e.Y, 5, 5);
            list.Add(e.Location);
        }

        /// <summary>                                    //注释
        /// 凸包算法
        /// </summary>
        /// <param name="_list"></param>
        /// <returns></returns>
        private List<TuLine> BruteForceTu(List<Point> _list)
        {
            //记录极点对
            List<TuLine> role = new List<TuLine>();

            //遍历
            for (int i = 0; i < _list.Count-1; i++)
            {
                for (int j = i+1; j < _list.Count; j++)
                {
                    int a = _list[j].Y - _list[i].Y;
                    int b = _list[i].X - _list[j].X;
                    int c = _list[i].X * _list[j].Y - _list[i].Y * _list[j].X;

                    int count = 0;
                    //将所有点代入方程
                    for (int k = 0; k < _list.Count; k++)
                    {
                        int result=a * _list[k].X + b * _list[k].Y - c;
                        if (result> 0)
                        {
                            count++;
                        }
                        else if(result < 0)
                        {
                            count--;
                        }
                    }
                    //是极点，则将连线记录下来
                    if (Math.Abs(count) == _list.Count - 2)
                    {
                        TuLine line = new TuLine();
                        line.Begin = _list[i];
                        line.End = _list[j];
                        role.Add(line);
                    }
                }

            }
            return role;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();                         //this指定为当前窗体
        }

        private void btTu_Click(object sender, EventArgs e)
        {
            List<TuLine> jidian = BruteForceTu(list);

            for (int i = 0; i < jidian.Count; i++)
            {
                g.DrawLine(bLine, jidian[i].Begin, jidian[i].End);
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            list.Clear();
            this.Refresh();
        }
    }
}