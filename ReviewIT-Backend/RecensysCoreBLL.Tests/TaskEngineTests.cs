using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;
using Xunit;

namespace RecensysCoreBLL.Tests
{
    public class TaskEngineTests
    {

        [Fact]
        public void Generate_Review_Strategy_100_percent_to_Mathias_2_articles_in_one_stage__()
        {
            var distMock = new Mock<IDistributionRepository>();
            distMock.Setup(d => d.Read(1)).Returns(new DistributionDTO()
            {
                Distribution = new Dictionary<ResearcherDetailsDTO, double>()
                {
                    [new ResearcherDetailsDTO() {Id = 1, FirstName = "Mathias"}] = 100
                }
            });
            var f1 = new FieldDTO() {Id = 1, Name = "f1"};
            var f2 = new FieldDTO() {Id = 1, Name = "f2"};
            var stageFieldsMock = new Mock<IStageFieldsRepository>();
            stageFieldsMock.Setup(sf => sf.Get(1)).Returns(new StageFieldsDTO()
            {
                RequestedFields = new List<FieldDTO> {f1},
                VisibleFields = new List<FieldDTO> { f2 }
            });
            
            
            var engine = new TaskEngine(distMock.Object);


            var r = engine.Generate(1);

            Assert.Equal(r, 2);
        }

    }
}
