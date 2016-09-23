using System;
using System.Collections.Generic;
using System.Linq;
using RecensysCoreBLL.BusinessEntities;
using RecensysCoreRepository.Entities;
using Criteria = RecensysCoreBLL.BusinessEntities.Criteria;
using CriteriaEntity = RecensysCoreRepository.Entities.Criteria;
using DataType = RecensysCoreBLL.BusinessEntities.DataType;
using Field = RecensysCoreBLL.BusinessEntities.Field;
using FieldEntity = RecensysCoreRepository.Entities.Field;
using Stage = RecensysCoreBLL.BusinessEntities.Stage;
using StageEntity = RecensysCoreRepository.Entities.Stage;
using StudyEntity = RecensysCoreRepository.Entities.Study;
using StageFieldEntity = RecensysCoreRepository.Entities.StageFieldRelation;
using Study = RecensysCoreBLL.BusinessEntities.Study;

namespace RecensysCoreBLL.BusinessLogicLayer
{
    internal static class EntityMapper
    {
        /***
         * Study mappings
         */

        /// <summary>
        ///     Maps properties from a bll study to a repository study
        /// </summary>
        /// <param name="s">bll study</param>
        /// <returns>repo study</returns>
        internal static StudyEntity Map(Study s)
        {
            return new StudyEntity
            {
                Title = s.StudyDetails?.Name,
                Description = s.StudyDetails?.Description,
                Stages = s.Stages?.Select(Map).ToList(),
                Fields = s.AvailableFields?.Select(Map).ToList(),
                Criteria = s.Criteria?.Select(Map).ToList()
            };
        }

        /// <summary>
        ///     Maps properties from a repo study to a bll study
        /// </summary>
        /// <param name="s">repo study</param>
        /// <returns>bll study</returns>
        internal static Study Map(StudyEntity s)
        {
            return new Study
            {
                Id = s.Id,
                StudyDetails = new StudyDetails
                {
                    StudyId = s.Id,
                    Name = s.Title,
                    Description = s.Description
                },
                Stages = s.Stages?.Select(Map).ToList(),
                AvailableFields = s.Fields?.Select(Map).ToList(),
                Criteria = s.Criteria?.Select(Map).ToList()
            };
        }


        /***
         * Criteria mappings
         */

        /// <summary>
        ///     Maps properties from a bll criteria to a repo criteria
        /// </summary>
        /// <param name="c">bll criteria</param>
        /// <returns>repo criteria</returns>
        internal static CriteriaEntity Map(Criteria c)
        {
            return new CriteriaEntity
            {
                Id = c.Id,
                Value = c.Value,
                Field = Map(c.Field)
            };
        }

        /// <summary>
        ///     Maps properties from a repo criteria to a bll criteria
        /// </summary>
        /// <param name="c">repo criteria</param>
        /// <returns>bll criteria</returns>
        internal static Criteria Map(CriteriaEntity c)
        {
            return new Criteria
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
        /// <param name="f"></param>
        /// <returns></returns>
        internal static FieldEntity Map(Field f)
        {
            return f != null
                ? new FieldEntity
                {
                    Id = f.Id,
                    DataTypeId = (int) f.DataType,
                    Name = f.Name,
                }
                : null;
        }

        /// <summary>
        ///     Maps properties from a repo field to a bll field
        /// </summary>
        /// <param name="f">repo field</param>
        /// <returns>bll field</returns>
        internal static Field Map(FieldEntity f)
        {
            return f != null
                ? new Field
                {
                    Id = f.Id,
                    Name = f.Name,
                    DataType = (DataType) f.DataTypeId
                }
                : null;
        }


        /***
         * Stage mappings
         */

        /// <summary>
        ///     Maps properties from a bll stage to a repo stage
        /// </summary>
        /// <param name="s">bll stage</param>
        /// <returns>repo stage</returns>
        internal static StageEntity Map(Stage s)
        {
            return new StageEntity
            {
                Id = s.Id,
                Description = s.StageDetails?.Description,
                Name = s.StageDetails?.Name
            };
        }

        /// <summary>
        ///     Maps properties from a repo stage to a bll stage
        /// </summary>
        /// <param name="s">repo stage</param>
        /// <returns>bll stage</returns>
        internal static Stage Map(StageEntity s)
        {
            return new Stage
            {
                Id = s.Id,
                StageDetails = new StageDetails
                {
                    Name = s.Name,
                    Description = s.Description
                },
                StageFields = Map(s.StageFields)
            };
        }

        /// <summary>
        /// Maps fields related to a stage in the correct lists in a bll stagefields
        /// </summary>
        /// <param name="stageFieldRelations">bll entity</param>
        /// <returns>repo entity</returns>
        internal static StageFields Map(ICollection<StageFieldEntity> stageFieldRelations)
        {
            var stageFields = new StageFields
            {
                RequestedFields = new List<Field>(),
                VisibleFields = new List<Field>()
            };

            foreach (var sf in stageFieldRelations)
            {
                var field = Map(sf.Field);
                

                switch (sf.FieldType)
                {
                    case FieldType.Visible:
                        stageFields.VisibleFields.Add(field);
                        break;
                    case FieldType.Requested:
                        stageFields.RequestedFields.Add(field);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return stageFields;
        }
        
    }


    
}

