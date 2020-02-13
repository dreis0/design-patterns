using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.SOLID.OpenClose
{
    /*
     * Classes should be open for extension, but closed for modification, 
     * meaning that a new functionality should be added by extending the classes instead of modifying it
     */
    public enum Color
    {
        Red, Green, Blue
    }

    public enum Size
    {
        Small, Medium, Large
    }

    /// <summary>
    /// Example of the Open Close principle
    /// </summary>
    public class Product
    {
        public string Name;
        public Color Color;
        public Size Size;

        public Product(string name, Color color, Size size)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(paramName: nameof(name));

            Name = name;
            Color = color;
            Size = size;
        }
    }

    /// <summary>
    /// Filter that does not follow the open close principle
    /// </summary>
    public class ProductFilter
    {
        public static IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            return products.Where(p => p.Size == size);
        }
    }

    /*
     * In the ProductFilter class, for changing how the filter works, it's necessary to modify the class.
     * That said, it does not follow the open close principle.
     * To solve that, it's necessary to create a extendable pattern by using interfaces
     */

    public interface ISpecification<T>
    {
        bool IsSatisfied(T entity);
    }

    public interface IFilter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
    }

    public class ColorSpecification : ISpecification<Product>
    {
        private Color SpecifiedColor;

        public ColorSpecification(Color color)
        {
            SpecifiedColor = color;
        }

        public bool IsSatisfied(Product entity) => entity.Color == SpecifiedColor;
    }

    public class SizeSpecification : ISpecification<Product>
    {
        private readonly Size SpecifiedSize;

        public SizeSpecification(Size size)
        {
            this.SpecifiedSize = size;
        }

        public bool IsSatisfied(Product entity) => entity.Size == SpecifiedSize;
    }

    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> A, B;

        public AndSpecification(ISpecification<T> a, ISpecification<T> b)
        {
            A = a;
            B = b;
        }

        public bool IsSatisfied(T entity) => A.IsSatisfied(entity) && B.IsSatisfied(entity);
    }

    public class OrSpecification<T> : ISpecification<T>
    {
        ISpecification<T> A, B;

        public OrSpecification(ISpecification<T> a, ISpecification<T> b)
        {
            A = a;
            B = b;
        }

        public bool IsSatisfied(T entity) => A.IsSatisfied(entity) || B.IsSatisfied(entity);
    }

    /*
     * By creating implementations of ISpecification, it's possible to include various filters and combined classes to
     * create and extend the desired behaviors
     */
}
