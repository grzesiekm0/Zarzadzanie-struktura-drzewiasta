using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Repositories;


namespace MVATreeviewOndemand.Controllers
{
    public class TreeviewController : Controller
    {

        private readonly ITreeViewRepository _treeviewRepository;

        public TreeviewController(ITreeViewRepository treeviewRepository)
        {
            _treeviewRepository = treeviewRepository;
        }

        // GET: /Treeview/GetTree
        public ActionResult GetTree()
        {          
            try
            {
                return View(_treeviewRepository.GetTree());
            }
            catch (Exception ex) // catches all exceptions
            {
                return View(ex.Message);
            }
        }

        // GET: /Treeview/GetSubNode
        public string GetSubNode(string pid)
        {
            try
            {
                return _treeviewRepository.GetSubNode(pid);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }          
        }
    }
}
