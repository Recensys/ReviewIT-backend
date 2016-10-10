﻿namespace RecensysCoreRepository.EFRepository.Entities
{
    public class StageFieldRelation
    {
        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }

        public int FieldId { get; set; }
        public virtual Field Field { get; set; }

        public int FieldTypeId { get; set; }
        public virtual FieldType FieldType { get; set; }
    }
}