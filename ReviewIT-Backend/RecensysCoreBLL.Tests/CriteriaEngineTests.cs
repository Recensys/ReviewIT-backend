using System.Collections.Generic;
using Moq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Repositories;
using RecensysCoreRepository.Repositories;
using Xunit;

namespace RecensysCoreBLL.Tests
{
    public class CriteriaEngineTests
    {
        [Fact(DisplayName = "Evaluate() Article year 2001, include year over 2000 = article included")]
        public void Evaluate1()
        {
            var sfMock = new Mock<IStageFieldsRepository>();
            sfMock.Setup(sf => sf.Get(1, FieldType.Requested)).Returns(() => new List<FieldDTO>
            {
                new FieldDTO {Id = 1, DataType = DataType.Number}
            });

            var sdMock = new Mock<IStageDetailsRepository>();
            sdMock.Setup(s => s.GetStudyId(1)).Returns(() => 1);

            var criteriaMock = new Mock<ICriteriaRepository>();
            criteriaMock.Setup(c => c.Read(1)).Returns(() => new CriteriaDTO
            {
                Inclusions = new List<FieldCriteriaDTO>
                {
                    new FieldCriteriaDTO
                    {
                        Id = 1,
                        Field = new FieldDTO {DataType = DataType.Number, Id = 1},
                        Value = "2000",
                        Operator = "<"
                    }
                }
            });

            var articleMock = new Mock<IArticleRepository>();
            articleMock.Setup(a => a.AddCriteriaResult(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(() => true);
            articleMock.Setup(a => a.GetAllActive(1)).Returns(() => new List<int> {1});

            var dataMock = new Mock<IDataRepository>();
            dataMock.Setup(d => d.Read(1, 1)).Returns(() => new DataDTO {Id = 1, Value = "2001"});

            var criteriaEngine = new CriteriaEngine.CriteriaEngine(sfMock.Object, criteriaMock.Object, sdMock.Object, articleMock.Object, dataMock.Object);

            criteriaEngine.Evaluate(1);

            articleMock.Verify(a => a.AddCriteriaResult(1,1,1), Times.Exactly(1));
        }

        [Fact(DisplayName = "Evaluate() Article year 2001, include year under 2000 = article included")]
        public void Evaluate2()
        {
            var sfMock = new Mock<IStageFieldsRepository>();
            sfMock.Setup(sf => sf.Get(1, FieldType.Requested)).Returns(() => new List<FieldDTO>
            {
                new FieldDTO {Id = 1, DataType = DataType.Number}
            });

            var sdMock = new Mock<IStageDetailsRepository>();
            sdMock.Setup(s => s.GetStudyId(1)).Returns(() => 1);

            var criteriaMock = new Mock<ICriteriaRepository>();
            criteriaMock.Setup(c => c.Read(1)).Returns(() => new CriteriaDTO
            {
                Inclusions = new List<FieldCriteriaDTO>
                {
                    new FieldCriteriaDTO
                    {
                        Id = 1,
                        Field = new FieldDTO {DataType = DataType.Number, Id = 1},
                        Value = "2000",
                        Operator = ">"
                    }
                }
            });

            var articleMock = new Mock<IArticleRepository>();
            articleMock.Setup(a => a.AddCriteriaResult(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(() => true);
            articleMock.Setup(a => a.GetAllActive(1)).Returns(() => new List<int> { 1 });

            var dataMock = new Mock<IDataRepository>();
            dataMock.Setup(d => d.Read(1, 1)).Returns(() => new DataDTO { Id = 1, Value = "2001" });

            var criteriaEngine = new CriteriaEngine.CriteriaEngine(sfMock.Object, criteriaMock.Object, sdMock.Object, articleMock.Object, dataMock.Object);

            criteriaEngine.Evaluate(1);

            articleMock.Verify(a => a.AddCriteriaResult(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(0));
        }

        [Fact(DisplayName = "Evaluate() Article year 2001, include year > 2000 && exclude year < 2005 given year 2002 = included")]
        public void Evaluate3()
        {
            var sfMock = new Mock<IStageFieldsRepository>();
            sfMock.Setup(sf => sf.Get(1, FieldType.Requested)).Returns(() => new List<FieldDTO>
            {
                new FieldDTO {Id = 1, DataType = DataType.Number}
            });

            var sdMock = new Mock<IStageDetailsRepository>();
            sdMock.Setup(s => s.GetStudyId(1)).Returns(() => 1);

            var criteriaMock = new Mock<ICriteriaRepository>();
            criteriaMock.Setup(c => c.Read(1)).Returns(() => new CriteriaDTO
            {
                Inclusions = new List<FieldCriteriaDTO>
                {
                    new FieldCriteriaDTO
                    {
                        Id = 1,
                        Field = new FieldDTO {DataType = DataType.Number, Id = 1},
                        Operator = "<",
                        Value = "2000"
                    }
                },
                Exclusions = new List<FieldCriteriaDTO>
                {
                    new FieldCriteriaDTO
                    {
                       Id = 2,
                       Field = new FieldDTO {DataType = DataType.Number, Id = 1},
                       Operator = ">",
                       Value = "2005"
                    }
                }
            });

            var articleMock = new Mock<IArticleRepository>();
            articleMock.Setup(a => a.AddCriteriaResult(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(() => true);
            articleMock.Setup(a => a.GetAllActive(1)).Returns(() => new List<int> { 1 });

            var dataMock = new Mock<IDataRepository>();
            dataMock.Setup(d => d.Read(1, 1)).Returns(() => new DataDTO { Id = 1, Value = "2002" });

            var criteriaEngine = new CriteriaEngine.CriteriaEngine(sfMock.Object, criteriaMock.Object, sdMock.Object, articleMock.Object, dataMock.Object);

            criteriaEngine.Evaluate(1);

            articleMock.Verify(a => a.AddCriteriaResult(1, It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(1));
            articleMock.Verify(a => a.AddCriteriaResult(2, It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(0));
        }


    }
}