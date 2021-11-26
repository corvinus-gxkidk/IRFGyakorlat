using gyakorlásfactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace gyakorlásfactory.Entities
{
    class Present : Toy
    {
        public SolidBrush WrapColor { get; private set; }
        public SolidBrush RibbonColor { get; private set; }

        public Present(Color color1, Color color2)
        {
            WrapColor = new SolidBrush(color1);
            RibbonColor = new SolidBrush(color2);

        }
        protected override void DrawImage(Graphics g)
        {
            g.FillRectangle(WrapColor, 0, 0, Width, Height);
            g.FillRectangle(RibbonColor, 0, Height / 5 * 2, Width, Height / 5);
            g.FillRectangle(RibbonColor, Width / 5 * 2, 0, Width / 5, Height);
        }
    }
}
