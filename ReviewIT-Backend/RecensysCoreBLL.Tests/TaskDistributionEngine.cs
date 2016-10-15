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
    public class TaskDistributionEngine
    {

        [Fact]
        public void Generate_two_articles__returns_2()
        {
            var distMock = new Mock<IDistributionRepository>();
            distMock.Setup(d => d.Read(1)).Returns(new DistributionDTO()
            {
                Distribution = new Dictionary<ResearcherDetailsDTO, double>()
                {
                    [new ResearcherDetailsDTO() {Id = 1, FirstName = "Mathias"}] = 100
                }
            });
            var dataMock = new Mock<IRequestedDataRepository>();
            dataMock.Setup(d => d.GetAll(1)).Returns(new List<ArticleWithRequestedDataDTO>
            {
                new ArticleWithRequestedDataDTO {ArticleId = 1, DataIds = new List<int> {1}},
                new ArticleWithRequestedDataDTO {ArticleId = 2, DataIds = new List<int> {2}}
            });
            var taskMock = new Mock<ITaskRepository>();
            
            var engine = new RecensysCoreBLL.TaskDistributionEngine(distMock.Object, dataMock.Object, taskMock.Object);
            var r = engine.Generate(1);

            Assert.Equal(r, 2);
        }

        [Fact]
        public void Generate_two_articles__two_tasks_created()
        {
            var distMock = new Mock<IDistributionRepository>();
            distMock.Setup(d => d.Read(1)).Returns(new DistributionDTO()
            {
                Distribution = new Dictionary<ResearcherDetailsDTO, double>()
                {
                    [new ResearcherDetailsDTO() { Id = 1, FirstName = "Mathias" }] = 100
                }
            });
            var dataMock = new Mock<IRequestedDataRepository>();
            dataMock.Setup(d => d.GetAll(1)).Returns(new List<ArticleWithRequestedDataDTO>
            {
                new ArticleWithRequestedDataDTO {ArticleId = 1, DataIds = new List<int> {1}},
                new ArticleWithRequestedDataDTO {ArticleId = 2, DataIds = new List<int> {2}}
            });
            var taskMock = new Mock<ITaskRepository>();


            var engine = new RecensysCoreBLL.TaskDistributionEngine(distMock.Object, dataMock.Object, taskMock.Object);
            var r = engine.Generate(1);

            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.IsAny<TaskDTO>()), Times.Exactly(2));
        }


        [Fact]
        public void Generate_two_articles_100_percent_mathias__two_tasks_for_mathias()
        {
            var distMock = new Mock<IDistributionRepository>();
            distMock.Setup(d => d.Read(1)).Returns(new DistributionDTO()
            {
                Distribution = new Dictionary<ResearcherDetailsDTO, double>()
                {
                    [new ResearcherDetailsDTO() { Id = 1, FirstName = "Mathias" }] = 100
                }
            });
            var dataMock = new Mock<IRequestedDataRepository>();
            dataMock.Setup(d => d.GetAll(1)).Returns(new List<ArticleWithRequestedDataDTO>
            {
                new ArticleWithRequestedDataDTO {ArticleId = 1, DataIds = new List<int> {1}},
                new ArticleWithRequestedDataDTO {ArticleId = 2, DataIds = new List<int> {2}}
            });
            var taskMock = new Mock<ITaskRepository>();


            var engine = new RecensysCoreBLL.TaskDistributionEngine(distMock.Object, dataMock.Object, taskMock.Object);
            var r = engine.Generate(1);

            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.Is<TaskDTO>(dto => dto.OwnerId == 1)), Times.Exactly(2));
        }

        [Fact]
        public void Generate_two_articles_50_50_between_mathias_and_paolo__one_task_for_each()
        {
            var distMock = new Mock<IDistributionRepository>();
            distMock.Setup(d => d.Read(1)).Returns(new DistributionDTO()
            {
                Distribution = new Dictionary<ResearcherDetailsDTO, double>()
                {
                    [new ResearcherDetailsDTO() { Id = 1, FirstName = "Mathias" }] = 50,
                    [new ResearcherDetailsDTO() { Id = 2, FirstName = "Paolo" }] = 50
                }
            });
            var dataMock = new Mock<IRequestedDataRepository>();
            dataMock.Setup(d => d.GetAll(1)).Returns(new List<ArticleWithRequestedDataDTO>
            {
                new ArticleWithRequestedDataDTO {ArticleId = 1, DataIds = new List<int> {1}},
                new ArticleWithRequestedDataDTO {ArticleId = 2, DataIds = new List<int> {2}}
            });
            var taskMock = new Mock<ITaskRepository>();


            var engine = new RecensysCoreBLL.TaskDistributionEngine(distMock.Object, dataMock.Object, taskMock.Object);
            var r = engine.Generate(1);

            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.Is<TaskDTO>(dto => dto.OwnerId == 1)), Times.Exactly(1));
            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.Is<TaskDTO>(dto => dto.OwnerId == 2)), Times.Exactly(1));
        }

        [Fact]
        public void Generate_three_articles_33_33_33_between_mathias_paolo_and_jacob__one_task_for_each()
        {
            var distMock = new Mock<IDistributionRepository>();
            distMock.Setup(d => d.Read(1)).Returns(new DistributionDTO()
            {
                Distribution = new Dictionary<ResearcherDetailsDTO, double>()
                {
                    [new ResearcherDetailsDTO() { Id = 1, FirstName = "Mathias" }] = 33,
                    [new ResearcherDetailsDTO() { Id = 3, FirstName = "Jacob" }] = 33,
                    [new ResearcherDetailsDTO() { Id = 2, FirstName = "Paolo" }] = 33
                }
            });
            var dataMock = new Mock<IRequestedDataRepository>();
            dataMock.Setup(d => d.GetAll(1)).Returns(new List<ArticleWithRequestedDataDTO>
            {
                new ArticleWithRequestedDataDTO {ArticleId = 1, DataIds = new List<int> {1}},
                new ArticleWithRequestedDataDTO {ArticleId = 3, DataIds = new List<int> {3}},
                new ArticleWithRequestedDataDTO {ArticleId = 2, DataIds = new List<int> {2}}
            });
            var taskMock = new Mock<ITaskRepository>();


            var engine = new RecensysCoreBLL.TaskDistributionEngine(distMock.Object, dataMock.Object, taskMock.Object);
            var r = engine.Generate(1);

            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.Is<TaskDTO>(dto => dto.OwnerId == 1)), Times.Exactly(1));
            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.Is<TaskDTO>(dto => dto.OwnerId == 2)), Times.Exactly(1));
            taskMock.Verify(t => t.Create(It.IsAny<int>(), It.Is<TaskDTO>(dto => dto.OwnerId == 3)), Times.Exactly(1));
        }

    }
}
