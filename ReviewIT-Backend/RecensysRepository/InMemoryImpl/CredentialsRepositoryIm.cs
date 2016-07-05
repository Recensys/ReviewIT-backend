using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class CredentialsRepositoryIm : ICredentialsRepository
    {

        private List<CredentialsEntity> _credentials = new List<CredentialsEntity>()
        {
            new CredentialsEntity() {User_Id = 1, Id = 1, User_Name = "Mat", Password_Salt = "SALT"}
        };

        public void Dispose()
        {
        }

        public IEnumerable<CredentialsEntity> GetAll()
        {
            return _credentials;
        }

        public void Create(CredentialsEntity item)
        {
            _credentials.Add(item);
        }

        public CredentialsEntity Read(int id)
        {
            return _credentials.Find(dto => dto.Id == id);
        }

        public void Update(CredentialsEntity item)
        {
            _credentials.RemoveAll(dto => dto.Id == item.Id);
            _credentials.Add(item);
        }

        public void Delete(int id)
        {
            _credentials.RemoveAll(dto => dto.Id == id);
        }
    }
}