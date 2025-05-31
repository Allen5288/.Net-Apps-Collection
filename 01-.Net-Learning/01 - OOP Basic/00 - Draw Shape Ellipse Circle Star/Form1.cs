using System.Drawing;
using System.Windows.Forms;

namespace Draw_Shape_Ellipse_Circle_Star
{
		public partial class Form1 : Form
		{				
				private List<Shape> Shapes = new List<Shape>();
				public Form1()
				{
						InitializeComponent();

						#region         
						Shapes.Add(new Ellipse());
						Shapes.Add(new Star());
						Shapes.Add(new Circle(220, 160, 40, Brushes.IndianRed));
						Shapes.Add(new Circle(420, 280, 60, Brushes.CadetBlue));
						Shapes.Add(new Shapes.Rectangle(220, 15, 100, 70));
						#endregion
				}

				private void Form1_Paint(object sender, PaintEventArgs e)
				{
						Star star = new Star();
						Ellipse ellipse = new Ellipse();
						Rectangle rc = new Rectangle(220, 15, 100, 70);
						Circle circle = new Circle(220,160, 40,Brushes.DarkGreen);
						Circle circle2 = new Circle(420, 280, 60, Brushes.Bisque);

						star.Draw(e.Graphics);
						ellipse.Draw(e.Graphics);
						rc.Draw(e.Graphics);
						circle.Draw(e.Graphics);
						circle2.Draw(e.Graphics);
				}

				#region Polymorphism way drawing
				private void btnPoly_Click(object sender, EventArgs e)
				{
						#region

						Graphics g = this.CreateGraphics();
						g.Clear(Color.White);
						foreach (Shape s in Shapes)
						{
								s.PolyDraw(g);
						}
						#endregion
				}
				#endregion

				#region Normal drawing
				private void DrawEllipse(Graphics gr)
				{
						Ellipse ellipse = new Ellipse();
						ellipse.Draw(gr);
				}
				private void DrawStar(Graphics gr)
				{
						Star star = new Star();
						star.Draw(gr);
				}

				private void DrawRectangle(Graphics gr)
				{
						Rectangle rc = new Rectangle(220, 15, 100, 70);
						rc.Draw(gr);
				}

				private void DrawCircle(Graphics gr, int x, int y, int r, Brush brush)
				{
						Circle circle = new Circle(x, y, r, brush);
						circle.Draw(gr);
				}
				private void btnNormal_Click(object sender, EventArgs e)
				{
						Graphics g = this.CreateGraphics();
						DrawStar(g);
						DrawEllipse(g);
						DrawRectangle(g);
						DrawCircle(g, 220, 160, 40, Brushes.YellowGreen);
						DrawCircle(g, 420, 280, 60, Brushes.Red);
				}
				#endregion
		}
}
