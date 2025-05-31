using System.Drawing;
using System.Windows.Forms;

namespace Draw_Shape_Ellipse_Circle_Star
{
    public class Ellipse : Shape
    {
        public void Draw(Graphics gr)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(100, 15, 100, 70);

            System.Drawing.Region r = new System.Drawing.Region(gp);           
            gr.FillRegion(Brushes.LawnGreen, r);
        }

        public override void PolyDraw(Graphics graphics)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(100, 15, 100, 70);

            System.Drawing.Region r = new System.Drawing.Region(gp);
            Graphics gr = graphics;
            gr.FillRegion(Brushes.LightGoldenrodYellow, r);
        }
    }
}
