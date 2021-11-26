using gyakorlásfactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace gyakorlásfactory.Entities
{
    public class Ball : Toy
    {
        public SolidBrush BallColor { get; private set; }
       public Ball (Color color)
        {
            BallColor = new SolidBrush(color);
        }
        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallColor, 0, 0, Width, Height);
        }

       
    }
}
