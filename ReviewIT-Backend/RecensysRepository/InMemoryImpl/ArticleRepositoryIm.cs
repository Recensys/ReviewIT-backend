using System.Collections.Generic;
using RecensysRepository.Entities;
using RecensysRepository.Interfaces;

namespace RecensysRepository.InMemoryImpl
{
    public class ArticleRepositoryIm : IArticleRepository
    {


        private List<ArticleEntity> _articles = new List<ArticleEntity>()
        {
            
        };

        public IEnumerable<ArticleEntity> GetAll()
        {
            return _articles;
        }

        public void Create(ArticleEntity item)
        {
            _articles.Add(item);
        }

        public ArticleEntity Read(int id)
        {
            return _articles.Find(dto => dto.Id == id);
        }

        public void Update(ArticleEntity item)
        {
            _articles.RemoveAll(dto => dto.Id == item.Id);
            _articles.Add(item);
        }

        public void Delete(int id)
        {
            _articles.RemoveAll(dto => dto.Id == id);
        }

        public void Dispose()
        {
        }
    }
}