using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repositoryContext;
        private ITodoRepository _todo;

        public ITodoRepository ToDo
        {
            get
            {
                if (_todo == null) _todo = new ToDoRepository(_repositoryContext);

                return _todo;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}