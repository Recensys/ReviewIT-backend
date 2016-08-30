using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecensysBLL.BusinessEntities;
using RecensysRepository.Entities;
using RecensysRepository.Factory;

namespace RecensysBLL.BusinessLogicLayer
{
    class FieldBLL
    {

        private IRepositoryFactory _factory;
        public FieldBLL(IRepositoryFactory factory)
        {
            _factory = factory;
        }

        

        public int SaveField(Field field, int studyId)
        {
            var id = field.Id;

            if (field.Id == -1)
            {
                id = AddField(field, studyId);
            }

            using (var fieldRepo = _factory.GetFieldRepo())
            {
                fieldRepo.Update(new FieldEntity()
                {
                    Id = field.Id,
                    Name = field.Name,
                    Study_Id = studyId,
                    DataType_Id = (int)field.DataType
                });
            }

            return id;
        }
        

        public List<Field> GetFieldsForStudy(int studyId)
        {
            var fields = new List<Field>();

            using (var fieldRepo = _factory.GetFieldRepo())
            {
                var fieldEntities = fieldRepo.GetAll().Where(f => f.Study_Id == studyId);
                foreach (var fieldEntity in fieldEntities)
                {
                    fields.Add(MapEntity(fieldEntity));
                }
            }

            return fields;
        }

        public List<Field> GetStageFields(FieldType ftype, int stageId)
        {
            var fields = new List<Field>();

            using (var stageFieldRepo = _factory.GetStageFieldsRepository())
            using (var fieldRepo = _factory.GetFieldRepo())
            {
                var entities = stageFieldRepo.GetAll().Where(e => e.Stage_Id == stageId && e.FieldType_Id == (int)ftype);
                foreach (var entity in entities)
                {
                    var fieldEntity = fieldRepo.Read(entity.Field_Id);
                    fields.Add(MapEntity(fieldEntity));
                }
            }

            return fields;
        }

        public void ReferenceField(FieldType ftype, int fieldId, int stageId)
        {

            using (var stageFieldsRepo = _factory.GetStageFieldsRepository())
            {
                stageFieldsRepo.Update(new StageFieldEntity()
                {
                    Stage_Id = stageId,
                    Field_Id = fieldId,
                    FieldType_Id = (int)ftype
                });
            }
        }

        public int AddField(Field field, int studyId)
        {
            int id = -1;

            using (var fieldRepo = _factory.GetFieldRepo())
            {
                id = fieldRepo.Create(new FieldEntity()
                {
                    DataType_Id = (int)field.DataType,
                    Name = field.Name,
                    Study_Id = studyId
                });
            }

            return id;
        }

        public List<Field> GetRequestedFields(int stageId)
        {
            var fields = new List<Field>();

            using (var stageFieldRepo = _factory.GetStageFieldsRepository())
            using (var fieldRepo = _factory.GetFieldRepo())
            {
                var entities = stageFieldRepo.GetAll().Where(e => e.Stage_Id == stageId && e.FieldType_Id == 1);
                foreach (var entity in entities)
                {
                    var fieldEntity = fieldRepo.Read(entity.Field_Id);
                    fields.Add(MapEntity(fieldEntity));
                }
            }

            return fields;
        }

        private Field MapEntity(FieldEntity entity)
        {
            return new Field()
            {
                Id = entity.Id,
                Name = entity.Name,
                DataType = (DataType) entity.DataType_Id,
            };
        }
        


    }
}
