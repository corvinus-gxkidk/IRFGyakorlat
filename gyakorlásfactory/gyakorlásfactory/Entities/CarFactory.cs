using gyakorlásfactory.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace gyakorlásfactory.Entities
{
    public class CarFactory : IToyFactory
    {
        public Toy CreateNew()
        {
            return new Car();
        }
    }
}
