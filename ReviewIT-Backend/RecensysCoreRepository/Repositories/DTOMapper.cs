using System;
using System.Collections.Generic;
using System.Linq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;

namespace RecensysCoreRepository.Repositories
{
    internal static class DTOMapper
    {


        /***
         * Study mappings
         */

        /// <summary>
        ///     Maps properties from a bll study to a repository study
        /// </summary>
        /// <param name="s">bll study</param>
        /// <returns>repo study</returns>
        internal static StudyConfigDTO Map(Study s)
        {
            return new StudyConfigDTO
            {
                Name = s.Name,
                Description = s.Description,
                Stages = s.Stages?.Select(Map).ToList(),
                AvailableFields = s.Fields?.Select(Map).ToList(),
                Criteria = s.Criteria?.Select(Map).ToList()
            };
        }

        /// <summary>
        ///     Maps properties from a repo study to a bll study
        /// </summary>
        /// <param name="s">repo study</param>
        /// <returns>bll study</returns>
        internal static void Map(StudyConfigDTO from, Study to)
        {
            to.Name = from.Name;
            to.Description = from.Description;

            //Map fields
            foreach (var fromFields in from.AvailableFields.OrEmptyIfNull())
            {
                var f = to.Fields.SingleOrAddedDefault(fi => fi.Id == fromFields.Id);
                Map(fromFields, f);
            }

            //Map criteria
            foreach (var fromCriteria in from.Criteria.OrEmptyIfNull())
            {
                var c = to.Criteria.SingleOrAddedDefault(cri => cri.Id == fromCriteria.Id);
                Map(fromCriteria, c);
            }

            /**
             * MAPS STAGES
             */
             // remove stages in storage that are not in incoming dto
            if (from.Stages != null && to.Stages != null)
            {
                foreach (var toStage in to.Stages.ToList())
                {
                    if (from.Stages.All(fs => fs.Id != toStage.Id)) to.Stages.Remove(toStage);
                }
            } else to.Stages = new List<Stage>();
             // map stages in dto, either to a matching entity in storage, or new entity
            foreach (var fromStage in from.Stages.OrEmptyIfNull())
            {
                if (fromStage.Id > 0)
                {
                    var s = to.Stages.Single(st => st.Id == fromStage.Id);
                    Map(fromStage, s);
                }
                if (fromStage.Id <= 0)
                {
                    var s = new Stage();
                    to.Stages.Add(s);
                    Map(fromStage, s);
                }
            }
            
        }
        


        /***
         * Researcher mappings
         */

        internal static void Map(ResearcherDetailsDTO from, User to)
        {
            if (from == null || to == null) return;

            to.FirstName = from.FirstName;
        }

        


        /***
         * Criteria mappings
         */

        /// <summary>
        ///     Maps properties from a bll criteria to a repo criteria
        /// </summary>
        /// <param name="c">bll criteria</param>
        /// <returns>repo criteria</returns>
        internal static void Map(CriteriaDTO from, Criteria to)
        {
            if (from == null || to == null) return;

            to.Value = from.Value;
            Map(from.Field, to.Field);
        }

        /// <summary>
        ///     Maps properties from a repo criteria to a bll criteria
        /// </summary>
        /// <param name="c">repo criteria</param>
        /// <returns>bll criteria</returns>
        internal static CriteriaDTO Map(Criteria c)
        {
            return new CriteriaDTO
            {
                Id = c.Id,
                Value = c.Value,
                Field = Map(c.Field)
            };

        }

        /***
         * Field mappings
         */

        /// <summary>
        ///     Maps properties from a bll field to a repo field
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        internal static void Map(FieldDTO from, Field to)
        {
            if (from == null || to == null) return;

            to.Id = from.Id;
            to.Name = from.Name;
            to.DataType = (int)from.DataType;
        }

        /// <summary>
        ///     Maps properties from a repo field to a bll field
        /// </summary>
        /// <param name="f">repo field</param>
        /// <returns>bll field</returns>
        internal static FieldDTO Map(Field f)
        {
            return f != null
                ? new FieldDTO
                {
                    Id = f.Id,
                    Name = f.Name,
                    DataType = (DataType)f.DataType
                }
                : null;
        }


        /***
         * Stage mappings
         */

        /// <summary>
        ///     Maps properties from a DTO to an Entity
        /// </summary>
        /// <param name="from">DTO</param>
        /// <param name="to">Entity</param>
        internal static void Map(StageConfigDTO from, Stage to)
        {
            to.Name = from.Name;
            to.Description = from.Description;
            if (to.StageFields == null) to.StageFields =  new List<StageFieldRelation>();

            foreach (var requestedFieldDTO in from.RequestedFields.OrEmptyIfNull())
            {
                var stageFieldEntity = to.StageFields.SingleOrAddedDefault(sf => sf.Field.Id == requestedFieldDTO.Id);

                stageFieldEntity.FieldType = FieldType.Requested;

                if (stageFieldEntity.Field == null) stageFieldEntity.Field = new Field();
                
                // Map the field.
                Map(requestedFieldDTO, stageFieldEntity.Field);
                stageFieldEntity.Field = stageFieldEntity.Field;
            }

            foreach (var visibleFieldDTO in from.VisibleFields.OrEmptyIfNull())
            {
                var stageFieldEntity = to.StageFields.SingleOrAddedDefault(sf => sf.Field.Id == visibleFieldDTO.Id);

                stageFieldEntity.FieldType = FieldType.Visible;

                if (stageFieldEntity.Field == null) stageFieldEntity.Field = new Field();

                // Map the field.
                Map(visibleFieldDTO, stageFieldEntity.Field);
                stageFieldEntity.Field = stageFieldEntity.Field;
            }
            
        }

        
        /// <summary>
        ///     Maps properties from a repo stage to a bll stage
        /// </summary>
        /// <param name="s">repo stage</param>
        /// <returns>bll stage</returns>
        internal static StageConfigDTO Map(Stage s)
        {
            var dto = new StageConfigDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                RequestedFields = new List<FieldDTO>(),
                VisibleFields = new List<FieldDTO>()
            };

            foreach (var sf in s.StageFields)
            {
                var field = Map(sf.Field);


                switch (sf.FieldType)
                {
                    case FieldType.Visible:
                        dto.VisibleFields.Add(field);
                        break;
                    case FieldType.Requested:
                        dto.RequestedFields.Add(field);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return dto;
        }

        ///// <summary>
        ///// Maps fields related to a stage in the correct lists in a bll stagefields
        ///// </summary>
        ///// <param name="stageFieldRelations">bll entity</param>
        ///// <returns>repo entity</returns>
        //internal static StageFields Map(ICollection<StageFieldEntity> stageFieldRelations)
        //{
        //    var stageFields = new StageFields
        //    {
        //        RequestedFields = new List<Field>(),
        //        VisibleFields = new List<Field>()
        //    };

        //    foreach (var sf in stageFieldRelations)
        //    {
        //        var field = Map(sf.Field);


        //        switch (sf.FieldType)
        //        {
        //            case FieldType.Visible:
        //                stageFields.VisibleFields.Add(field);
        //                break;
        //            case FieldType.Requested:
        //                stageFields.RequestedFields.Add(field);
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException();
        //        }
        //    }

        //    return stageFields;
        //}

    }

    public static class CollectionExtensions
    {
        public static IEnumerable<T> OrEmptyIfNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static T SingleOrAddedDefault<T>(this ICollection<T> sources, Func<T, bool> predicate) where T : new()
        {
            var c = sources.Count(predicate);
            switch (c)
            {
                case 0:
                    var t = new T();
                    sources.Add(t);
                    return t;
                case 1:
                    return sources.Single(predicate);
                default:
                    throw new InvalidOperationException("The input sequence contains more than one element.");
            }
        }
    }

   
    
}

