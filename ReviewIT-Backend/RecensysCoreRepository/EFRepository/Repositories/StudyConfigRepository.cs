using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EF;
using RecensysCoreRepository.Entities;
using Remotion.Linq.Parsing.Structure.IntermediateModel;

namespace RecensysCoreRepository.Repositories
{
    public class StudyConfigRepository : IStudyConfigRepository
    {
        private readonly IRecensysContext _context;

        public StudyConfigRepository(IRecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Create(StudyConfigDTO dto)
        {
            var entity = new Study();
            DTOMapper.Map(dto, entity);
            _context.Studies.Add(entity);
            _context.SaveChanges();
            return dto.Id = entity.Id;
        }

        public StudyConfigDTO Read(int id)
        {
            var dtos = from s in _context.Studies
                      where s.Id == id
                      select new StudyConfigDTO()
                      {
                          Id = s.Id,
                          Name = s.Name,
                          Description = s.Description,
                          Criteria = (from c in s.Criteria
                                      select new CriteriaDTO() { Id = c.Id, Value = c.Value }).ToList(),
                          AvailableFields = (from af in s.Fields
                                             select new FieldDTO() { Id = af.Id, Name = af.Name, DataType = (DataType)af.DataType }).ToList(),
                          Stages = (from st in s.Stages
                                    select new StageConfigDTO()
                                    {
                                        Id = st.Id,
                                        Name = st.Name,
                                        Description = st.Description,
                                        VisibleFields = (from vf in st.StageFields
                                                         where vf.FieldType == FieldType.Visible
                                                         select new FieldDTO() { Id = vf.Field.Id, Name = vf.Field.Name, DataType = (DataType)vf.Field.DataType }).ToList(),
                                        RequestedFields = (from rf in st.StageFields
                                                           where rf.FieldType == FieldType.Requested
                                                           select new FieldDTO() { Id = rf.Field.Id, Name = rf.Field.Name, DataType = (DataType)rf.Field.DataType }).ToList(),
                                    }).ToList(),
                          //Researchers = (from r in s.UserRelations TODO researchers get from userRelations
                          //               select new ResearcherDetailsDTO() { Id = r.Id, FirstName = r.FirstName }).ToList()
                      };
            return dtos.Single();
        }
        

        public bool Update(StudyConfigDTO dto)
        {
            var entity = _context.Studies.Include(s => s.Stages).Include(s => s.Criteria).Include(s => s.Fields).First(s => s.Id == dto.Id);
            DTOMapper.Map(dto, entity);
            _context.Studies.Update(entity);
            return _context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var entity = _context.Studies.Single(s => s.Id == id);
            _context.Studies.Remove(entity);
            return _context.SaveChanges() > 0;
        }
    }

    
}