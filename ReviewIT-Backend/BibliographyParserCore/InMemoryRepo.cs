using System;
using System.Collections.Generic;
using System.Linq;
using RecensysCoreRepository.DTOs;

// ReSharper disable LoopCanBeConvertedToQuery

namespace BibliographyParserCore
{
    /// <summary>
    /// A collection of bibliographic <see cref="StudySourceItemDTO" />'s which are held in memory.
    /// </summary>
    public class InMemoryItemRepo
    {
        readonly ICollection<StudySourceItemDTO> _items = new HashSet<StudySourceItemDTO>();

        /// <summary>
        /// Add an studySourceItemDto to the repo.
        /// </summary>
        /// <param name="studySourceItemDtoadd.</param>
        public void Add(StudySourceItemDTO studySourceItemDto)
        {
            if (studySourceItemDto == null) throw new ArgumentNullException(nameof(studySourceItemDto));
            _items.Add(studySourceItemDto);
        }

        /// <summary>
        /// Add a range of items to the repo.
        /// </summary>
        /// <param name="items">The items to add.</param>
        public void AddRange(IEnumerable<StudySourceItemDTO> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        /// <summary>
        /// Returns an IEnumerable of all items in the repo. This method is lazily evaluated.
        /// </summary>
        /// <returns>An IEnumerable of the results.</returns>
        public IEnumerable<StudySourceItemDTO> GetAll()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }

        /// <summary>
        /// Returns an IEnumerable of all items matching a given search string. This method is lazily evaluated.
        /// </summary>
        /// <param name="searchString">The search string is a plain non-null and whitespace string that is matehced against all fields of an studySourceItemDto.</param>
        /// <param name="take">The number of items to take. If null, return all results.</param>
        /// <returns>An IEnumerable of the results.</returns>
        public IEnumerable<StudySourceItemDTO> Search(string searchString, int? take = null)
        {
            if (string.IsNullOrWhiteSpace(searchString)) yield break;
            var i = 0;
            foreach (var item in _items)
            {
                if (i >= take) yield break;
                if (!item.Fields.Any(f => f.Value.ToLower().Contains(searchString.ToLower()))) continue;
                i++; yield return item;
            }
        }
    }
}