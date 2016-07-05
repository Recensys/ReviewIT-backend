using System;

namespace BibliographyParser.FieldCheckers
{
    /// <summary>
    /// A field checker to verify whether an ISNN field is valid.
    /// ISSN, International Standard Serial Number is a unique idenfier of items.
    /// More info can be found at: https://en.wikipedia.org/wiki/International_Standard_Serial_Number
    /// </summary>
    public class IssnFieldChecker : IFieldChecker
    {
        public bool Validate(string field)
        {
            throw new NotImplementedException();
        }
    }
}
