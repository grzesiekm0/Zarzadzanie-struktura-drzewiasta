using TaskManager.Models;

namespace TaskManager.Repositories
{
    public interface ITreeViewRepository
    {
        public TreeViewModel GetTree();

        public string GetSubNode(string pid);

    }
}
