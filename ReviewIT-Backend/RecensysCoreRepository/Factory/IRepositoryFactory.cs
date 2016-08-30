using RecensysCoreRepository.Interfaces;

namespace RecensysCoreRepository.Factory
{
    public interface IRepositoryFactory
    {
        IUserRepository GetUserRepo();
        IStudyRepository GetStudyRepo();
        IStageRepository GetStageRepo();
        IFieldRepository GetFieldRepo();
        IDataRepository GetDataRepo();
        ITaskRepository GetTaskRepo();
        IArticleRepository GetArticleRepo();
        IUserStageRelationRepository GetUserStageRelationRepo();
        IUserStudyRelationRepository GetUserStudyRelationRepo();
        IStudyRoleRepository GetStudyRoleRepo();
        IStrategyRepository GetStrategyRepo();
        IDataTypeRepository GetDataTypeRepo();
        IStageFieldsRepository GetStageFieldsRepository();
    }
}
