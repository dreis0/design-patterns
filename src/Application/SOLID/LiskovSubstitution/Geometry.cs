using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SOLID.LiskovSubstitution
{
    /*
     * The Liskov Substitution states that a class should always be castable to it's father.
     * It also says that, when keeping a class' reference by using it's base type, it should still behave normally/as expected
     */

    public class Geometry
    {
        public class Rectangle
        {
            public Rectangle(int w, int h)
            {
                Width = w;
                Height = h;
            }
            public Rectangle() { }

            public virtual int Width { get; set; }
            public virtual int Height { get; set; }

            public override string ToString()
            {
                return $"{nameof(Width)}: {Width} | {nameof(Height)}: {Height}";
            }
        }

        /// <summary>
        /// This class does not follow the Liskov principle
        /// If you keep it's reference as a Rectangle, when setting one of it's properties, you might acess the property of the base class instead of the square one
        /// </summary>
        public class Square : Rectangle
        {
            public new int Width { set => Width = Height = value; }
            public new int Height { set => Width = Height = value; }
        }

        public class LiskovSquare : Rectangle
        {
            public override int Width
            {
                set => Width = Height = value;
            }

            public override int Height
            {
                set => Height = Width = value;
            }
        }
    }
}
