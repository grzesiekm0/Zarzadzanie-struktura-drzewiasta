using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITreeFormRepository
    {
        public bool InsertNode(TreeView form);

        public bool MoveNode(TreeView form); 
    }
}
