using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreRepository.EFRepository.Repositories
{
    public interface IArticleRepository: IDisposable
    {
        IEnumerable<ArticleDTO> GetAllForStudy(int studyId);
        IEnumerable<ArticleDTO> GetAllForStage(int studyId);
    }
}
