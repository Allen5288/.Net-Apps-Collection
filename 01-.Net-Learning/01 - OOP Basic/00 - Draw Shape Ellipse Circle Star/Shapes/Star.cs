using System.Drawing;
using System.Windows.Forms;

namespace Draw_Shape_Ellipse_Circle_Star
{
    public class Star : Shape
    {
        Point[] p = new System.Drawing.Point[8];
        public Star()
        {
            p[0] = new Point(0, 50);
            p[1] = new Point(40, 40);
            p[2] = new Point(50, 0);
            p[3] = new Point(60, 40);
            p[4] = new Point(100, 50);
            p[5] = new Point(60, 60);
            p[6] = new Point(50, 100);
            p[7] = new Point(40, 60);
        }

        public void Draw(Graphics gr)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddPolygon(p);

            System.Drawing.Region r = new System.Drawing.Region(gp);            
            gr.FillRegion(Brushes.BlueViolet, r);
        }

        public override void PolyDraw(Graphics graphics)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddPolygon(p);

            System.Drawing.Region r = new System.Drawing.Region(gp);
            Graphics gr = graphics;
            gr.FillRegion(Brushes.DarkSalmon, r);
        }
    }
}
