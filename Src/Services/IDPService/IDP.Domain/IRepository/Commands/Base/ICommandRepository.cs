namespace IDP.Domain.IRepository.Commands.Base;

public interface ICommandRepository<in TEntity> where TEntity : class
{
    Task<bool> Insert(TEntity entity);
    Task<bool> Update(TEntity entity);
    Task<bool> Delete(TEntity entity);
}
