using System;
using System.Collections.Generic;
using System.Linq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Entities;
using RecensysCoreRepository.Repositories;
using Xunit;
using DataType = RecensysCoreRepository.DTOs.DataType;


namespace RecensysCoreRepository.Tests.Unittests
{
    public class DTOMapperTests
    {

        [Fact]
        public void MapStudyConfigDTO_Id_Name_Desc_Mapped_Correctly()
        {
            var dto = new StudyConfigDTO()
            {
                Id = 1,
                Name = "Name",
                Description = "Desc"
            };
            var entity = new Study();

            DTOMapper.Map(dto, entity);

            Assert.Equal("Name",entity.Name);
            Assert.Equal("Desc",entity.Description);
        }

        [Fact]
        public void MapStudyConfig_Three_Fields_Mapped_Correctly()
        {
            var dto = new StudyConfigDTO()
            {
                AvailableFields = new List<FieldDTO>
                {
                    new FieldDTO() {Id = 1, Name = "F1Name"},
                    new FieldDTO() {Id = 2, Name = "F2Name"},
                    new FieldDTO() {Id = 3, Name = "F3Name"}
                }
            };

            var targetEntity = new Study()
            {
                Fields = new List<Field>()
                {
                    new Field() {Id = 1},
                    new Field() {Id = 2},
                    new Field() {Id = 3},
                }
            };

            DTOMapper.Map(dto, targetEntity);

            Assert.Equal("F1Name", targetEntity.Fields.Single(f => f.Id == 1).Name);
            Assert.Equal("F2Name", targetEntity.Fields.Single(f => f.Id == 2).Name);
            Assert.Equal("F3Name", targetEntity.Fields.Single(f => f.Id == 3).Name);
        }

        [Fact]
        public void MapStudyDTO_Two_Criteria_Mapped_Correctly()
        {
            var dto = new StudyConfigDTO()
            {
                Criteria = new List<CriteriaDTO>()
                {
                    new CriteriaDTO()
                    {
                        Id = 1,
                        Field = new FieldDTO() {Id = 1},
                        Value = "> 2"
                    },
                    new CriteriaDTO()
                    {
                        Id = 2,
                        Field = new FieldDTO() {Id = 1},
                        Value = "< 10"
                    }
                }
            };

            var targetEntity = new Study()
            {
                Criteria = new List<Criteria>()
                {
                    new Criteria() {Id = 1},
                    new Criteria() {Id = 2},
                }
            };

            DTOMapper.Map(dto, targetEntity);

            Assert.Equal("> 2", targetEntity.Criteria.Single(c => c.Id == 1).Value);
            Assert.Equal("< 10", targetEntity.Criteria.Single(c => c.Id == 2).Value);
        }

        [Fact]
        public void MapResearcherDetailsDTO_FirstName_Mapped_Correctly()
        {
            var dto = new ResearcherDetailsDTO()
            {
                FirstName = "John"
            };

            var targetEntity = new User()
            {
            };

            DTOMapper.Map(dto, targetEntity);

            Assert.Equal("John", targetEntity.FirstName);
        }

        [Fact]
        public void MapStage_Name_And_Desc_And_Id_Mapped_Correctly()
        {
            var entity = new Stage()
            {
                Id = 1,
                Name = "Name",
                Description = "Desc"
            };

            var r = DTOMapper.Map(entity);

            Assert.Equal("Name", r.Name);
            Assert.Equal("Desc", r.Description);
            Assert.Equal(1, r.Id);
        }

        [Fact]
        public void MapStageConfigDTO_Name_And_Desc_Mapped_Correctly()
        {
            var StageDTO = new StageConfigDTO()
            {
                Id = 1,
                Name = "Name",
                Description = "Desc"
            };
            var targetEntity = new Stage()
            {
                Id = 1
            };

            DTOMapper.Map(StageDTO, targetEntity);

            Assert.Equal("Name", targetEntity.Name);
            Assert.Equal("Desc", targetEntity.Description);
            Assert.Equal(1, targetEntity.Id);
        }

        [Fact]
        public void MapStageConfigDTO_One_Visible_Field_Mapped_Correctly()
        {
            var dto = new StageConfigDTO()
            {
                VisibleFields = new List<FieldDTO>()
                {
                    new FieldDTO() {Id = 1, Name = "F1"}
                }
            };


            var targetEntity = new Stage();

            DTOMapper.Map(dto, targetEntity);

            Assert.Equal(1, targetEntity.StageFields.Count(sf => sf.FieldType == FieldType.Visible));
        }

        [Fact]
        public void MapStageConfigDTO_One_Requested_Field_Mapped_Correctly()
        {
            var dto = new StageConfigDTO()
            {
                RequestedFields = new List<FieldDTO>()
                {
                    new FieldDTO() {Id = 1, Name = "F1"}
                }
            };

            var targetEntity = new Stage() {StageFields = new List<StageFieldRelation>() {new StageFieldRelation() {FieldType = FieldType.Requested,Field = new Field() {Id = 1} } } };

            DTOMapper.Map(dto, targetEntity);

            Assert.Equal(1, targetEntity.StageFields.Count);
            Assert.Equal("F1", targetEntity.StageFields.Where(sf => sf.FieldType == FieldType.Requested).Select(f => f.Field.Name).Single());
        }



        [Fact]
        public void SingleOrAddedDefault_Item_Not_Contained_New_Item_Added()
        {
            var col = new List<int>() {1, 2};

            col.SingleOrAddedDefault(i => i == 3);

            Assert.Equal(3, col.Count);
            Assert.True(col.Contains(0));
        }

        [Fact]
        public void SingleOrAddedDefault_TestItem_Not_Contained_New_Item_Added()
        {
            var col = new List<Test>() { new Test() {Name = "John"}, new Test() {Name = "Steve"} };

            col.SingleOrAddedDefault(t => t.Name == "Mary");

            Assert.Equal(3, col.Count);
            Assert.Equal(1, col.Count(t => t.Name == "not set"));
        }

        public class Test
        {
            public string Name { get; set; } = "not set";

        }

        [Fact]
        public void SingleOrAddedDefault_Item_Contained_And_Returned()
        {
            var col = new List<int>() { 1, 2 };

            var res = col.SingleOrAddedDefault(i => i == 2);

            Assert.Equal(2, res);
        }

        [Fact]
        public void SingleOrAddedDefault_Multiple_Items_Contained_InvalidOperationException_Thrown()
        {
            var col = new List<int>() { 1, 2, 2 };

            Assert.Throws<InvalidOperationException>(() => col.SingleOrAddedDefault(i => i == 2));
        }

        [Fact]
        public void MapField_DataType_Boolean_Mapped_To_Boolean()
        {
            var entity = new Field()
            {
                DataType = (int) DataType.Boolean
            };

            var r = DTOMapper.Map(entity);

            Assert.Equal(DataType.Boolean, r.DataType);
        }

        //[Fact]
        //public void MapFieldDTO_DataType_Boolean_Mapped_To_Boolean()
        //{
        //    var field = new FieldDTO()
        //    {
        //        DataType = DataType.Boolean
        //    };

        //    var r = DTOMapper.Map(field);

        //    Assert.Equal((int)DataType.Boolean, r.DataTypeId);
        //}

        [Fact]
        public void MapField_Null_Returns_Null()
        {
            Field f = null;
            Assert.Null(DTOMapper.Map(f));
        }

        [Fact]
        public void MapCriteria_Id_And_Value_Mapped_Correctly()
        {
            var criteria = new Criteria()
            {
                Id = 1,
                Value = "value"
            };

            var r = DTOMapper.Map(criteria);

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

            var r = DTOMapper.Map(criteria);

            Assert.NotNull(r.Field);
        }

        [Fact]
        public void MapCriteria_Id_And_Value_And_Field_Mapped_Correctly()
        {
            var entity = new Criteria()
            {
                Id = 1,
                Value = "value",
                Field = new Field()
            };

            var r = DTOMapper.Map(entity);

            Assert.Equal(1,r.Id);
            Assert.Equal("value",r.Value);
            Assert.NotNull(r.Field);
        }

        [Fact]
        public void MapStudy_StudyDetails_Mapped_Correctly()
        {
            var s = new Study()
            {
                Name = "Name",
                Description = "Desc"
            };

            var r = DTOMapper.Map(s);

            Assert.Equal("Name", r.Name);
            Assert.Equal("Desc", r.Description);
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
                Fields = new List<Field>()
                {
                    new Field(), new Field(), new Field(), new Field()
                },
                Criteria = new List<Criteria>()
                {
                    new Criteria()
                }
            };

            var r = DTOMapper.Map(s);

            Assert.True(r.Stages.Count == 3);
            Assert.True(r.AvailableFields.Count == 4);
            Assert.True(r.Criteria.Count == 1);
        }

        [Fact]
        public void MapStudy_Name_Desc_Mapped_Correctly()
        {
            var s = new Study()
            {
                Name = "Name",
                Description = "Desc"
            };

            var r = DTOMapper.Map(s);

            Assert.Equal("Name", r.Name);
            Assert.Equal("Desc", r.Description);
        }


        [Fact]
        public void StudyMappingIntegrationTest_One_Field()
        {
            var dto = new StudyConfigDTO()
            {
                Id = 1,
                AvailableFields = new List<FieldDTO>()
                {
                    new FieldDTO() {DataType = DataType.Boolean}
                }
            };

            var targetEntity = new Study();
            DTOMapper.Map(dto, targetEntity);

            var targetDto = DTOMapper.Map(targetEntity);

            Assert.Equal(1, targetDto.AvailableFields.Count(f => f.DataType == DataType.Boolean));
        }

        [Fact]
        public void StudyMappingIntegrationTest_One_Criteria()
        {
            var dto = new StudyConfigDTO()
            {
                Id = 1,
                Criteria = new List<CriteriaDTO>()
                {
                    new CriteriaDTO() {Value = "< 2"}
                }
            };

            var targetEntity = new Study();
            DTOMapper.Map(dto, targetEntity);

            var targetDto = DTOMapper.Map(targetEntity);

            Assert.Equal(1, targetDto.Criteria.Count(s => s.Value == "< 2"));
        }

        [Fact]
        public void StudyMappingIntegrationTest_One_Visible_Field()
        {
            var dto = new StudyConfigDTO()
            {
                Id = 1,
                Stages = new List<StageConfigDTO>()
                {
                    new StageConfigDTO()
                    {
                        VisibleFields = new List<FieldDTO>()
                        {
                            new FieldDTO() {Name = "F1"}
                        }
                    }
                }
            };

            var targetEntity = new Study();
            DTOMapper.Map(dto, targetEntity);

            var targetDto = DTOMapper.Map(targetEntity);

            Assert.Equal(1, targetDto.Stages.First().VisibleFields.Count(f => f.Name == "F1"));
        }

        
    }
}
