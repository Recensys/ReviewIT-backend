using System;

namespace BibliographyParser.FieldCheckers
{
    /// <summary>
    /// A field checker to verify whether an author field is valid. This can either be a single author, or a list of authors.
    /// First and last name can be separated by a comma. Multiple authors are separated by 'and'.
    /// </summary>
    public class AuthorFieldChecker : IFieldChecker
    {
        public bool Validate(string field)
        {
            throw new NotImplementedException();
        }
    }
}
