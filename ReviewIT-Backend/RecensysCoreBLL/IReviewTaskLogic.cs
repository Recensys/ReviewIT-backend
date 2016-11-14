using System.Security.Cryptography.X509Certificates;
using RecensysCoreRepository.DTOs;

namespace RecensysCoreBLL
{
    public interface IReviewTaskLogic
    {
        bool Update(ReviewTaskDTO dto);
    }
}