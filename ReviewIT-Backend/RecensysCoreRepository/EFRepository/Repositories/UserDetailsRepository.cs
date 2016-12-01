﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;
using RecensysCoreRepository.EFRepository.Entities;
using RecensysCoreRepository.Repositories;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public class UserDetailsRepository: IUserDetailsRepository
    {

        private readonly RecensysContext _context;

        public UserDetailsRepository(RecensysContext context)
        {
            if (context == null) throw new ArgumentNullException($"{nameof(context)} is null");
            _context = context;
        }

        public void Dispose()
        {
            
        }

        public IEnumerable<UserDetailsDTO> Get()
        {
            return from r in _context.Users
                select new UserDetailsDTO()
                {
                    Id = r.Id,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    Email = r.Email
                };
        }

        public IEnumerable<UserDetailsDTO> GetForStudy(int studyId)
        {
            return from us in _context.UserStudyRelations
                where us.StudyId == studyId
                select new UserDetailsDTO
                {
                    Id = us.UserId,
                    FirstName = us.User.FirstName,
                    LastName = us.User.LastName,
                    Email = us.User.Email
                };
        }

        public bool Update(int studyId, ICollection<UserDetailsDTO> dtos)
        {
            var stored = from us in _context.UserStudyRelations
                where us.StudyId == studyId
                select us;

            if (dtos != null)
                foreach (var to in stored) if (dtos.All(c => c.Id != to.UserId)) _context.UserStudyRelations.Remove(to);
            _context.SaveChanges();

            foreach (var userDto in dtos)
            {
                if (userDto.Id == 0)
                    _context.UserStudyRelations.Add(new UserStudyRelation {StudyId = studyId, UserId = userDto.Id });
                if (userDto.Id > 0)
                {
                    var s = stored.Single(st => st.UserId == userDto.Id);
                }
            }
            return _context.SaveChanges() > 0;
        }

        public UserDetailsDTO Create(UserDetailsDTO dto)
        {
            var entity = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email
            };
            _context.Users.Add(entity);
            _context.SaveChanges();
            dto.Id = entity.Id;
            return dto;
        }
    }
}
