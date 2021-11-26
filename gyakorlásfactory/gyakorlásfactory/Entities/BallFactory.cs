using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using gyakorlásfactory.Abstractions;
using gyakorlásfactory.Entities;

public class BallFactory : IToyFactory
    {
    public Color BallColor { get; set; }
    public Toy CreateNew()
        {
        return new Ball(BallColor);
        }
    }

