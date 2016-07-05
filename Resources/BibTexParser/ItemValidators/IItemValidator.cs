namespace BibliographyParser.ItemValidators
{
    public interface IItemValidator
    {
        /// <summary>
        /// Checks whether or not a given item is valid.
        /// </summary>
        /// <param name="item">The item to validate.</param>
        /// <returns>true if the item is valid; false otherwise.</returns>
        bool IsItemValid(Item item);
    }
}