using System.Collections.Generic;
using Moq;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.Repositories;
using Xunit;

namespace RecensysCoreBLL.Tests
{
    public class StudyStartEngineTests
    {

        [Fact]
        public void StartStudy_10ArticlesInStudy__10ArticlesOnFirstStage()
        {
            var cMock = new Mock<ICriteriaEngine>();
            var tMock = new Mock<ITaskDistributionEngine>();
            var aMock = new Mock<IArticleRepository>();
            var sMock = new Mock<IStageDetailsRepository>();

            aMock.Setup(am => am.GetAllIdsForStudy(1)).Returns(() => new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
            aMock.Setup(am => am.AddToStage(1, It.IsInRange(1,10,Range.Inclusive))).Returns(() => true);

            sMock.Setup(sm => sm.GetAll(1)).Returns(() => new[] {new StageDetailsDTO {Id = 1}});

            var engine = new StudyStartEngine(tMock.Object, sMock.Object, aMock.Object, cMock.Object);


            engine.StartStudy(1);


            aMock.Verify(am => am.AddToStage(1, It.IsAny<int>()), Times.Exactly(10));
        }
    }
}