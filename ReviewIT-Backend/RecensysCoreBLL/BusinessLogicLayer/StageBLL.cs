using System.Collections.Generic;
using RecensysCoreBLL.BusinessEntities;

namespace RecensysCoreBLL.BusinessLogicLayer
{
    public class StageBLL
    {

        private readonly IRepositoryFactory _factory;
        public StageBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }


        public Stage GetStage(int id)
        {
            var stage = new Stage() {Id = id};

            // get stage details
            using (var stageRepo = _factory.GetStageRepo())
            {
                var stageEntity = stageRepo.Read(id);
                
                stage.StageDetails = new StageDetails()
                {
                    Name = stageEntity.Name,
                    Description = stageEntity.Description
                };
            }

            stage.StageFields = new StageFields()
            {
                RequestedFields = new FieldBLL(_factory).GetStageFields(FieldType.Requested, id),
                VisibleFields = new FieldBLL(_factory).GetStageFields(FieldType.Visible, id)
            };

            return stage;
        }

        public int SaveStage(Stage stage)
        {
            
            // save basic details
            int id = UpdateDetails(stage.Id, stage.StageDetails);

            // save fields
            var fieldBll = new FieldBLL(_factory);
            foreach (var field in stage.StageFields.VisibleFields)
            {
                fieldBll.ReferenceField(FieldType.Visible, field.Id, stage.Id);
            }
            foreach (var field in stage.StageFields.RequestedFields)
            {
                fieldBll.ReferenceField(FieldType.Requested, field.Id, stage.Id);
            }

            return id;
        }

        public int UpdateDetails(int stageId, StageDetails details)
        {
            int id = stageId;

            using (var stageRepo = _factory.GetStageRepo())
            {
                var entity = stageRepo.Read(stageId);
                if (entity != null)
                {
                    entity.Name = details.Name;
                    entity.Description = details.Description;
                    stageRepo.Update(entity);
                }
                else
                {
                    entity = new StageEntity()
                    {
                        Name = details.Name,
                        Description = details.Description
                    };
                    id = stageRepo.Create(entity);
                }
            }

            return id;
        }

        public void UpdateFields(int stageId, List<Field> visibleFields, List<Field> requestedFields)
        {
            using (var stageDescRepo = _factory.GetStageFieldsRepository())
            {
                foreach (var field in visibleFields)
                {
                    stageDescRepo.Create(new StageFieldEntity()
                    {
                        Stage_Id = stageId,
                        Field_Id = field.Id,
                        FieldType_Id = 0
                    });
                }
                foreach (var field in requestedFields)
                {
                    stageDescRepo.Create(new StageFieldEntity()
                    {
                        Stage_Id = stageId,
                        Field_Id = field.Id,
                        FieldType_Id = 1
                    });
                }

            }
        }

        public List<Stage> GetStagesForStudy(int studyId)
        {
            int[] ids;
            var stages = new List<Stage>();
            using (var stageRepo = _factory.GetStageRepo())
            {
                ids = stageRepo.GetAll().Where(s => s.Study_Id == studyId).Select(s => s.Id).ToArray();
            }
            foreach(var id in ids)
            {
                stages.Add(GetStage(id));
            }
            return stages;
        }


        public int AddStage(Stage stage, int studyId)
        {
            var id = -1;
            using (var stageRepo = _factory.GetStageRepo())
            {
                id = stageRepo.Create(new StageEntity()
                {
                    Study_Id = studyId,
                    Name = stage.StageDetails.Name,
                    Description = stage.StageDetails.Description
                });
            }
            return id;
        }

        public void RemoveStage(int id)
        {
            using (var stageRepo = _factory.GetStageRepo())
            {
                stageRepo.Delete(id);
            }
        }


    }
}