using System.Drawing;
using System.Windows.Forms;

namespace Draw_Shape_Ellipse_Circle_Star
{
    public static class RectangleExtension
    {
        public static void Draw(this System.Drawing.Rectangle rectangle, Graphics gr)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddRectangle(rectangle);
            System.Drawing.Region r = new System.Drawing.Region(gp);            
            gr.FillRegion(Brushes.OrangeRed, r);
        }

        public static void Draw_V2(this System.Drawing.Rectangle rectangle, Graphics graphics)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddRectangle(rectangle);
            System.Drawing.Region r = new System.Drawing.Region(gp);
            Graphics gr = graphics;
            gr.FillRegion(Brushes.DarkOliveGreen, r);
        }
    }
}
