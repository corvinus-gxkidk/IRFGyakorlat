using gyakorlásfactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace gyakorlásfactory.Entities
{
    public class PresentFactory : IToyFactory
    {
        public Color WrapColor { get; set; }
        public Color RibbonColor { get; set; }
        public Toy CreateNew()
        {

            return new Present(WrapColor, RibbonColor);
        }
    }
}
