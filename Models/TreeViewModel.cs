using System.Collections.Generic;


namespace TaskManager.Models
{
    public class TreeViewModel
    {
        public IEnumerable<TreeView> GetTreeview { get; set; }
        public IEnumerable<TreeView> GetTreeFormViews { get; set; }
    }
}
