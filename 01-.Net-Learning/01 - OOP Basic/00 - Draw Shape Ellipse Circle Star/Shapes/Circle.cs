using System.Drawing;
using System.Windows.Forms;

namespace Draw_Shape_Ellipse_Circle_Star
{
    public class Circle : Shape
    {
        private int X;
        private int Y;
        private int Radius;
        private Brush Brush;

        public Circle(int x, int y, int radius, Brush brush )
        {
            X = x;
            Y = y;
            Radius = radius;
            Brush = brush;
        }

        public void Draw(Graphics gr)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gr.FillCircle(Brush, X, Y, Radius);
        }

        public override void PolyDraw(Graphics graphics)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            graphics.FillCircle(Brush, X, Y, Radius);
        }
    }
}
