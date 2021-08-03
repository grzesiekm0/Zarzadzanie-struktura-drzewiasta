using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public partial class TreeView
    {
        [Key]
        public int TreeId { get; set; }
        [MaxLength(50)]
        public string TreeName { get; set; }
        public int ParentTreeId { get; set; }
    }

}



