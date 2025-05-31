using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw_Shape_Ellipse_Circle_Star.Shapes
{
    public class Rectangle:Shape
    {
        private System.Drawing.Rectangle _rectangle;
        public Rectangle(int x, int y, int width, int height)
        {
            _rectangle = new System.Drawing.Rectangle(x, y, width, height);
        }

        public override void PolyDraw(Graphics graphics)
        {            
            _rectangle.Draw_V2(graphics);            
        }
    }
}
