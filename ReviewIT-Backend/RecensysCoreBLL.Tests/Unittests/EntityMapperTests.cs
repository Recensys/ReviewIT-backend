using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreBLL.BusinessEntities;
using RecensysCoreRepository.Entities;
using RecensysCoreBLL.BusinessLogicLayer;
using Xunit;

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

namespace RecensysCoreBLL.Tests.Unittests
{
    public class EntityMapperTests
    {
        [Fact]
        public void MapStageFieldEntity_Contains_1_Visible_And_Requested_Field_Correctly_Maps()
        {

            var entity = new List<StageFieldEntity>()
            {
                new StageFieldEntity
                {
                    FieldType = FieldType.Requested,
                    Field = new FieldEntity() { Name = "" }
                },
                new StageFieldEntity()
                {
                    FieldType = FieldType.Visible,
                    Field = new FieldEntity() { Name = ""}
                },
            };


            var r = EntityMapper.Map(entity);


            Assert.True(r.RequestedFields.Count == 1);
            Assert.True(r.VisibleFields.Count == 1);
        }

        [Fact]
        public void MapStageFieldEntity_Empty_Results_In_Empty()
        {
            var entity = new List<StageFieldEntity>();

            var r = EntityMapper.Map(entity);

            Assert.True(r.RequestedFields.Count == 0);
            Assert.True(r.VisibleFields.Count == 0);
        }


        [Fact]
        public void MapStageEntity_Name_And_Desc_And_Id_Mapped_Correctly()
        {
            var entity = new StageEntity()
            {
                Id = 1,
                Name = "Name",
                Description = "Desc"
            };

            var r = EntityMapper.Map(entity);

            Assert.Equal("Name", r.StageDetails.Name);
            Assert.Equal("Desc", r.StageDetails.Description);
            Assert.Equal(1, r.Id);
        }

        [Fact]
        public void MapStage_Name_And_Desc_And_Id_Mapped_Correctly()
        {
            var stage = new Stage()
            {
                Id = 1,
                StageDetails = new StageDetails()
                {
                    Name = "Name",
                    Description = "Desc"
                },
            };

            var r = EntityMapper.Map(stage);

            Assert.Equal("Name", r.Name);
            Assert.Equal("Desc", r.Description);
            Assert.Equal(1, r.Id);
        }

        [Fact]
        public void MapFieldEntity_DataType_Boolean_Mapped_To_Boolean()
        {
            var entity = new FieldEntity()
            {
                DataTypeId = (int) DataType.Boolean
            };

            var r = EntityMapper.Map(entity);

            Assert.Equal(DataType.Boolean, r.DataType);
        }

        [Fact]
        public void MapField_DataType_Boolean_Mapped_To_Boolean()
        {
            var field = new Field()
            {
                DataType = DataType.Boolean
            };

            var r = EntityMapper.Map(field);

            Assert.Equal((int)DataType.Boolean, r.DataTypeId);
        }

        [Fact]
        public void MapField_Null_Returns_Null()
        {
            Field f = null;
            Assert.Null(EntityMapper.Map(f));
        }

        [Fact]
        public void MapCriteria_Id_And_Value_Mapped_Correctly()
        {
            var criteria = new Criteria()
            {
                Id = 1,
                Value = "value"
            };

            var r = EntityMapper.Map(criteria);

            Assert.Equal("value", r.Value);
            Assert.Equal(1, r.Id);
        }

        [Fact]
        public void MapCriteria_Field_Set_Mapped_Correctly()
        {
            var criteria = new Criteria()
            {
                Field = new Field()
            };

            var r = EntityMapper.Map(criteria);

            Assert.NotNull(r.Field);
        }

        [Fact]
        public void MapCriteriaEntity_Id_And_Value_And_Field_Mapped_Correctly()
        {
            var entity = new CriteriaEntity()
            {
                Id = 1,
                Value = "value",
                Field = new FieldEntity()
            };

            var r = EntityMapper.Map(entity);

            Assert.Equal(1,r.Id);
            Assert.Equal("value",r.Value);
            Assert.NotNull(r.Field);
        }

        [Fact]
        public void MapStudy_StudyDetails_Mapped_Correctly()
        {
            var s = new Study()
            {
                StudyDetails = new StudyDetails()
                {
                    Name = "Name",
                    Description = "Desc"
                }
            };

            var r = EntityMapper.Map(s);

            Assert.Equal("Name",r.Title);
            Assert.Equal("Desc",r.Description);
        }


        [Fact]
        public void MapStudy_Stages_Fields_Criteria_Mapped_Correctly()
        {
            var s = new Study()
            {
                Stages = new List<Stage>()
                {
                    new Stage(), new Stage(), new Stage()
                },
                AvailableFields = new List<Field>()
                {
                    new Field(), new Field(), new Field(), new Field()
                },
                Criteria = new List<Criteria>()
                {
                    new Criteria()
                }
            };

            var r = EntityMapper.Map(s);

            Assert.True(r.Stages.Count == 3);
            Assert.True(r.Fields.Count == 4);
            Assert.True(r.Criteria.Count == 1);
        }

        [Fact]
        public void MapStudyEntity_Name_Desc_Mapped_Correctly()
        {
            var s = new StudyEntity()
            {
                Title = "Name",
                Description = "Desc"
            };

            var r = EntityMapper.Map(s);

            Assert.Equal("Name",r.StudyDetails.Name);
            Assert.Equal("Desc",r.StudyDetails.Description);
        }

        [Fact]
        public void MapStudyEntity_Stages_Fields_Criteria_Mapped_Correctly()
        {
            var s = new StudyEntity()
            {
                Stages = new List<StageEntity>() { new StageEntity(), new StageEntity(), },
                Fields = new List<FieldEntity>() { new FieldEntity(), new FieldEntity(), new FieldEntity() },
                Criteria = new List<CriteriaEntity>() { new CriteriaEntity() }
            };

            var r = EntityMapper.Map(s);

            Assert.True(r.Stages.Count == 2);
            Assert.True(r.AvailableFields.Count == 3);
            Assert.True(r.Criteria.Count == 1);
        }

    }
}
