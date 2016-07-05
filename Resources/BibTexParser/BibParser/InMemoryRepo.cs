using System;
using System.Collections.Generic;

// ReSharper disable LoopCanBeConvertedToQuery

namespace BibliographyParser
{
    /// <summary>
    /// A collection of bibliographic <see cref="Item" />'s which are held in memory.
    /// </summary>
    public class InMemoryItemRepo
    {
        private readonly ICollection<Item> _items;

        /// <summary>
        /// Add an item to the repo.
        /// </summary>
        /// <param name="item">The item to add.</param>
        public void Add(Item item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a range of items to the repo.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(IEnumerable<Item> items)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an IEnumerable of all items in the repo. This method is lazily evaluated.
        /// </summary>
        /// <returns>An IEnumerable of the results.</returns>
        public IEnumerable<Item> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns an IEnumerable of all items matching a given search string. This method is lazily evaluated.
        /// </summary>
        /// <param name="searchString">The search string is a plain non-null and whitespace string that is matehced against all fields of an item.</param>
        /// <param name="take">The number of items to take. If null, return all results.</param>
        /// <returns>An IEnumerable of the results.</returns>
        public IEnumerable<Item> Search(string searchString, int? take = null)
        {
            throw new NotImplementedException();
        }
    }
}
