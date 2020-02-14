using System;
using System.Collections.Generic;
using System.Text;

namespace Application.SOLID.InterfaceSegregation
{
    public class Document
    {

    }

    public interface IMachine
    {
        void Print(Document doc);
        void Scan(Document doc);
        void Fax(Document doc);
    }

    public class Printer : IMachine
    {
        public void Fax(Document doc)
        {
        }

        public void Print(Document doc)
        {
        }

        public void Scan(Document doc)
        {
        }
    }

    /*
     * The IMachine interface and the Printer class does not follow the interface principle.
     * The interface holds to much resposibility instead of segregating them.
     * This implementation also makes it impossible to implement a class with a single responsibility,
     * in this case, you can't use the IMachine interface to implement a printer class that has only the printing functionality
     */

    public interface IPrinter
    {
        void Print(Document doc);
    }

    public interface IScanner
    {
        void Scan(Document doc);
    }

    public interface IFaxMachine
    {
        void Fax(Document doc);
    }

    public class SegregatedPrinter : IPrinter, IScanner, IFaxMachine
    {
        public void Fax(Document doc)
        {
        }

        public void Print(Document doc)
        {
        }

        public void Scan(Document doc)
        {
        }
    }

    /*
     * In this second case, the interfaces are segregated and it's possible to implement classes with only one responsibility
     */
}
