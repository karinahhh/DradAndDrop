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
		PictureBox picB, img1;
		Label lbl1, lbl2, lbl3, lbl4, lbl5;
		Rectangle rec = new Rectangle(60, 40, 100, 100);//x, y, width, height
		Rectangle sq = new Rectangle(380, 40, 100, 100);
		Rectangle circ = new Rectangle(220, 40, 100, 100);//Circle
		bool r, s, c;//clicked
		int r1 = 0, r2 = 0, s1 = 0, s2 = 0, c1 = 0, c2 = 0;//X,Y
		int X, Y, dX, dY;
		int LastClicked = 0;
		public Form1()
		{
			this.Height = 600;
			this.Width = 700;
			this.Text = "Drag and Drop";

			picB = new PictureBox
			{
				Size = new Size(660, 540),
				Location = new Point(10, 10),
				BorderStyle=BorderStyle.FixedSingle
			};
			picB.Paint += PicB_Paint;
			picB.MouseDown += PicB_MouseDown;
			picB.MouseUp += PicB_MouseUp;
			picB.MouseMove += PicB_MouseMove;

			img1 = new PictureBox()
			{
				Image = Image.FromFile("slon.jpg"),
				Size = new Size(100, 150),
				Location = new Point(20, 30),
				SizeMode = PictureBoxSizeMode.Normal
		};

			lbl1 = new Label() {
				Text = "Найди маму",
				Size = new Size(300, 30),
				Location = new Point(170, 13),
				BackColor = Color.PowderBlue,
				Font = new Font("Arial", 20, FontStyle.Bold),
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter
			};
			lbl2 = new Label()
			{
				Text = "мама 2",
				Size = new Size(100, 60),
				Location = new Point(210, 380),
				BackColor = Color.PowderBlue,
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter
			};
			lbl3 = new Label()
			{
				Text = "мама 3",
				Size = new Size(100, 60),
				Location = new Point(400, 380),
				BackColor = Color.PowderBlue,
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter
			};
			lbl4 = new Label()
			{
				Text = "мама 4",
				Size = new Size(100, 60),
				Location = new Point(550, 380),
				BackColor = Color.PowderBlue,
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter
			};
			lbl5 = new Label()
			{
				Text = "мама 1",
				Size = new Size(100, 60),
				Location = new Point(20, 380),
				BackColor = Color.PowderBlue,
				AutoSize = false,
				TextAlign = ContentAlignment.MiddleCenter
			};
			this.Controls.Add(lbl1);
			this.Controls.Add(lbl2);
			this.Controls.Add(lbl3);
			this.Controls.Add(lbl4);
			this.Controls.Add(lbl5);
			//this.Controls.Add(img1);
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

			if ((lbl2.Location.X < sq.X + sq.Width) && (lbl2.Location.X > sq.X))
			{
				if ((lbl2.Location.Y < sq.Y + sq.Height) && (lbl2.Location.Y > sq.Y))
				{
					lbl1.Text = "Правильно!";
				}
			}
			if ((lbl3.Location.X < circ.X + circ.Width) && (lbl3.Location.X > circ.X))
			{
				if ((lbl3.Location.Y < circ.Y + circ.Height) && (lbl3.Location.Y > circ.Y))
				{
					lbl1.Text = "Голубой квадрат";
					

				}
			}
			if ((lbl4.Location.X < rec.X + rec.Width) && (lbl4.Location.X > rec.X))
			{
				if ((lbl4.Location.Y < rec.Y + rec.Height) && (lbl4.Location.Y > rec.Y))
				{
					lbl1.Text = "Фиолетовый Прямоугольник";
				}
			}


			picB.Invalidate();
		}

		private void PicB_MouseUp(object sender, MouseEventArgs e)
		{
			r = false;
			s = false;
			c = false;/*

			if ((lbl2.Location.X < sq.X + sq.Width) && (lbl2.Location.X > sq.X))
			{
				if ((lbl2.Location.Y < sq.Y + sq.Height) && (lbl2.Location.Y > sq.Y))
				{
					LastClicked = 3;
				}
			}
			if ((lbl2.Location.X < circ.X + circ.Width) && (lbl2.Location.X > circ.X))
			{
				if ((lbl2.Location.Y < circ.Y + circ.Height) && (lbl2.Location.Y > circ.Y))
				{
					LastClicked = 2;
				}
			}
			if ((lbl2.Location.X < rec.X + rec.Width) && (lbl2.Location.X > rec.X))
			{
				if ((lbl2.Location.Y < rec.Y + rec.Height) && (lbl2.Location.Y > rec.Y))
				{
					LastClicked = 1;
				}
			}

			if (LastClicked == 2)
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

			if (LastClicked==1)
			{
				if ((lbl2.Location.X < rec.X + rec.Width) && (lbl2.Location.X > rec.X))
				{
					if ((lbl2.Location.Y < rec.Y + rec.Height) && (lbl2.Location.Y > rec.Y))
					{
						X = rec.X;
						Y = rec.Y;
						dX = r1;
						dY = r2;
						rec.X = sq.X;
						rec.Y = sq.Y;
						r1 = s1;
						r2 = s2;

						sq.X = X;
						sq.Y = Y;
						s1 = dX;
						s2 = dY;
					}
				}
			}
			if (LastClicked == 3)
			{
				if ((lbl2.Location.X < sq.X + sq.Width) && (lbl2.Location.X > sq.X))
				{
					if ((lbl2.Location.Y < sq.Y + sq.Height) && (lbl2.Location.Y > sq.Y))
					{
						X = sq.X;
						Y = sq.Y;
						dX = s1;
						dY = s2;
						sq.X = circ.X;
						sq.Y = circ.Y;
						s1 = c1;
						s2 = c2;

						circ.X = X;
						circ.Y = Y;
						r1 = dX;
						r2 = dY;
					}
				}
			}*/
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
			e.Graphics.FillRectangle(Brushes.DarkTurquoise, circ);
		}
	}
}
