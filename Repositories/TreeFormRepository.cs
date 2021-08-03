using System;
using System.Linq;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public class TreeFormRepository : ITreeFormRepository
    {

        private readonly TreeManagerContex _treeManagerContext;
        public TreeFormRepository(TreeManagerContex treeManagerContext)
        {
            _treeManagerContext = treeManagerContext;
        }

        public bool InsertNode(TreeView form)
        {
            /*var insert = new TreeView
            {
                TreeId = 0,
                TreeName = form.TreeName,
                ParentTreeId = form.ParentTreeId
            };
           
            _treeManagerContext.Add(insert);
            _treeManagerContext.SaveChanges();
            return true;*/

            try
            {
                var insert = new TreeView
                {
                    TreeId = 0,
                    TreeName = form.TreeName,
                    ParentTreeId = form.ParentTreeId
                };
                if (form == null)
                    return false;
                _treeManagerContext.Add(insert);
                _treeManagerContext.SaveChanges();
                return true;
            }
            catch (Exception ex) // catches all exceptions
            {
                throw new Exception("Insert error", ex);
            }
        }
    

        public bool MoveNode(TreeView form)
        {
            try
            {
            if (form == null)
                return false;
            var result = _treeManagerContext.Tree.SingleOrDefault(b => b.TreeId == form.TreeId);
            if (result != null)
            {
                result.ParentTreeId = form.ParentTreeId;
                _treeManagerContext.SaveChanges();
                return true;
            }
            return false;
            }
            catch(Exception ex)
            {
                throw new Exception("Move node error", ex);
            }
        }
    }
}
