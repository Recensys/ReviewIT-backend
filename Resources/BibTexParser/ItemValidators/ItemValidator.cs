using System.Collections.Generic;
using BibliographyParser.ItemChecker;

namespace BibliographyParser.ItemValidators
{
    /// <summary>
    /// This class is used for validating bibliographic <see cref="Item"/> objects.
    /// </summary>
    public class ItemValidator : IItemValidator
    {
        readonly IDictionary<Item.ItemType, IItemChecker> _checkers;
        readonly IItemChecker _defaultChecker;

        /// <summary>
        /// Constructs a new ItemValidator.
        /// </summary>
        /// <param name="checkers">
        /// A dictionary of field checkers per item type.
        /// If a checker for an item type is not specified, <see cref="DefaultItemChecker"/> is used.
        /// </param>
        /// <param name="defaultChecker">The <see cref="IItemChecker"/> implementation to use as default</param>
        public ItemValidator(IItemChecker defaultChecker = null, IDictionary<Item.ItemType, IItemChecker> checkers = null)
        {
            _checkers = checkers ?? new Dictionary<Item.ItemType, IItemChecker>();
            _defaultChecker = defaultChecker ?? new DefaultItemChecker();
        }

        /// <summary>
        /// Checks whether or not a given item is valid.
        /// </summary>
        /// <param name="item">The item to validate.</param>
        /// <returns>true if the item is valid; false otherwise.</returns>
        public bool IsItemValid(Item item)
        {
            return _checkers.ContainsKey(item.Type) ? _checkers[item.Type].Validate(item) : _defaultChecker.Validate(item);
        }
    }
}
