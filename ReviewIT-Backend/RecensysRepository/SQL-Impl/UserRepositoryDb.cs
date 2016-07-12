using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository
{
    public class UserRepositoryDb
    {

        private string _conStr;

        public UserRepositoryDb()
        {
            //_conStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        public IEnumerable<UserEntity> GetAll()
        {

            return null;
        }

        public void Create(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public UserEntity Read(int id)
        {

            UserEntity m = null;

            using (IDbConnection c = new SqlConnection(_conStr))
            {
                //m = c.Query<UserDTO>("SELECT * FROM dbo.Users WHERE Id = @uid", new {uid = id}).SingleOrDefault();
            }

            return m;
        }

        public void Update(UserEntity user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}