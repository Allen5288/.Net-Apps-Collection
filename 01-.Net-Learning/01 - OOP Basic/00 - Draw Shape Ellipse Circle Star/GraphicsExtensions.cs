﻿using System.Drawing;

namespace Draw_Shape_Ellipse_Circle_Star
{
    public static class GraphicsExtensions
    {
        public static void FillCircle(this Graphics g, Brush brush,
                                  float centerX, float centerY, float radius)
        {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }
    }
}
