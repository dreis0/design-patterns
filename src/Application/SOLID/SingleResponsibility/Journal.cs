using System;
using System.Collections.Generic;

namespace Application.SOLID.SingleResponsibility
{
    /// <summary>
    /// Example of the Single Resposibilit principle
    /// </summary>
    public class Journal
    {
        private readonly List<string> entries = new List<string>();
        private static int entriesCount = 0;

        public void AddEntry(string entry)
        {
            entries.Add($"{++entriesCount}: {entry}");
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }
        
        /* 
         * These are examples of methods that fit the responsibility of the Journal class.
         * Adding a method that accesses external resources for data persistance for instance would violate this principle.
         * Basically the single responsibility principle states that each class should stick to its intent 
         */

        /// <summary>
        /// Would violate the single responsibility principle, as it would no be specificaly related to the journal entity
        /// </summary>
        public void SaveToDb()
        {
            throw new NotImplementedException();
        }
    }
}
