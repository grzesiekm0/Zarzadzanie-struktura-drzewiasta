using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TreeViewRepository : ITreeViewRepository
    {
        private readonly TreeManagerContex _treeManagerContext;
        public TreeViewRepository(TreeManagerContex treeRepository)
        {
            _treeManagerContext = treeRepository;
        }
        public TreeViewModel GetTree()
        {
            TreeViewModel viewModel = new TreeViewModel();
            List<TreeView> treeView = new List<TreeView>();
            List<TreeView> treeForm = new List<TreeView>();
         
            treeView = _treeManagerContext.Tree.Where(a => a.ParentTreeId.Equals(0)).OrderBy(a => a.TreeName).ToList();
            treeForm = _treeManagerContext.Tree.OrderBy(x => x.TreeName).ToList();

            viewModel.GetTreeview = treeView;
            viewModel.GetTreeFormViews = treeForm;

            return viewModel;
        }

        public string GetSubNode(string pid)
        { 
            List<TreeView> subMenus = new List<TreeView>();
            int pID = 0;
            int.TryParse(pid, out pID);

            subMenus = _treeManagerContext.Tree.Where(a => a.ParentTreeId.Equals(pID)).OrderBy(a => a.TreeName).ToList();

            var json = JsonSerializer.Serialize(subMenus);

            return json;
        }
    }   
}

