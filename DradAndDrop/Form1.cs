using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DradAndDrop
{
	public partial class Form1 : Form
	{
		PictureBox picB;
		Label lbl1, lbl2, lbl3;
		Rectangle rec = new Rectangle(10, 10, 200, 100);//x, y, width, height
		Rectangle sq = new Rectangle(380, 10, 150, 150);
		Rectangle circ = new Rectangle(220, 10, 150, 150);//Circle
		bool r, s, c;//clicked
		int r1 = 0, r2 = 0, s1 = 0, s2 = 0, c1 = 0, c2 = 0;//X,Y
		int X, Y, dX, dY;
		int LastClicked = 0;
		public Form1()
		{
			this.Height = 500;
			this.Width = 600;
			this.Text = "Drag and Drop";

			picB = new PictureBox
			{
				Size = new Size(560, 400),
				Location = new Point(10, 10),
				BorderStyle=BorderStyle.FixedSingle
			};
			picB.Paint += PicB_Paint;
			picB.MouseDown += PicB_MouseDown;
			picB.MouseUp += PicB_MouseUp;
			picB.MouseMove += PicB_MouseMove;
			lbl1 = new Label() {
				Text = "Вид",
				Size = new Size(100, 60),
				Location = new Point(30, 380),
				BackColor = Color.PowderBlue
			};
			lbl2 = new Label()
			{
				Text = "Форма",
				Size = new Size(100, 60),
				Location = new Point(210, 380),
				BackColor = Color.PowderBlue
			};
			lbl3 = new Label()
			{
				Text = "Информация",
				Size = new Size(100, 60),
				Location = new Point(400, 380),
				BackColor = Color.PowderBlue
			};
			this.Controls.Add(lbl1);
			this.Controls.Add(lbl2);
			this.Controls.Add(lbl3);
			this.Controls.Add(picB);
		}

		private void PicB_MouseMove(object sender, MouseEventArgs e)
		{
			if (r)
			{
				rec.X = e.X - r1;
				rec.Y = e.Y - r2;
			}
			else if (s)
			{
				sq.X = e.X - s1;
				sq.Y = e.Y - s2;
			}
			else if (c)
			{
				circ.X = e.X - c1;
				circ.Y = e.Y - c2;
			}

			if ((lbl1.Location.X < sq.X + sq.Width) && (lbl1.Location.X > sq.X))
			{
				if ((lbl1.Location.Y < sq.Y + sq.Height) && (lbl1.Location.Y > sq.Y))
				{
					lbl3.Text = "Розовый Квадрат";
				}
			}
			if ((lbl1.Location.X < circ.X + circ.Width) && (lbl1.Location.X > circ.X))
			{
				if ((lbl1.Location.Y < circ.Y + circ.Height) && (lbl1.Location.Y > circ.Y))
				{
					lbl3.Text = "Голубой Круг";
				}
			}
			if ((lbl1.Location.X < rec.X + rec.Width) && (lbl1.Location.X > rec.X))
			{
				if ((lbl1.Location.Y < rec.Y + rec.Height) && (lbl1.Location.Y > rec.Y))
				{
					lbl3.Text = "Фиолетовый Прямоугольник";
				}
			}

			picB.Invalidate();
		}

		private void PicB_MouseUp(object sender, MouseEventArgs e)
		{
			r = false;
			s = false;
			c = false;

			if (LastClicked==2)
			{
				if ((lbl2.Location.X < circ.X + circ.Width) && (lbl2.Location.X > circ.X))
				{
					if ((lbl2.Location.Y < circ.Y + circ.Height) && (lbl2.Location.Y > circ.Y))
					{
						X = circ.X;
						Y = circ.Y;
						dX = c1;
						dY = c2;
						circ.X = rec.X;
						circ.Y = rec.Y;
						c1 = r1;
						c2 = r2;

						rec.X = X;
						rec.Y = Y;
						r1 = dX;
						r2 = dY;
					}
				}
			}
		}

		private void PicB_MouseDown(object sender, MouseEventArgs e)
		{
			if ((e.X < rec.X + rec.Width) && (e.X > rec.X))
			{
				if ((e.Y < rec.Y + rec.Height) && (e.Y > rec.Y))
				{
					r = true;
					r1 = e.X - rec.X;
					r2 = e.Y - rec.Y;
				}
			}
			else if ((e.X < sq.X + sq.Width) && (e.X > sq.X))
			{
				if ((e.Y < sq.Y + sq.Height) && (e.Y > sq.Y))
				{
					s = true;
					s1 = e.X - sq.X;
					s2 = e.Y - sq.Y;
				}
			}
			else if ((e.X < circ.X + circ.Width) && (e.X > circ.X))
			{
				if ((e.Y < circ.Y + circ.Height) && (e.Y > circ.Y))
				{
					c = true;
					c1 = e.X - circ.X;
					c2 = e.Y - circ.Y;
				}
			}
		}

		private void PicB_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.FillRectangle(Brushes.Indigo, rec);
			e.Graphics.FillRectangle(Brushes.DarkSalmon, sq);
			e.Graphics.FillEllipse(Brushes.DarkTurquoise, circ);
		}
	}
}
