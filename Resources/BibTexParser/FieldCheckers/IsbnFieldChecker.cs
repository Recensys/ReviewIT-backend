using System;

namespace BibliographyParser.FieldCheckers
{
    /// <summary>
    /// A field checker to verify whether an ISBN field is valid.
    /// ISBN, International Standard Book Number is a unique idenfier for books.
    /// More info can be found at: https://en.wikipedia.org/wiki/International_Standard_Book_Number
    /// </summary>
    public class IsbnFieldChecker : IFieldChecker
    {
        public bool Validate(string field)
        {
            throw new NotImplementedException();
        }
    }
}
