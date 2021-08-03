using Microsoft.AspNetCore.Mvc;
using System;
using TaskManager.Models;
using TaskManager.Repositories;

namespace TaskManager.Controllers
{
    public class TreeFormController : Controller
    {
        private readonly ITreeFormRepository _treeFormRepository;

        public TreeFormController(ITreeFormRepository treeFormRepository)
        {
            _treeFormRepository = treeFormRepository;
        }

        // POST: /Treeview/InsertNode
        [HttpPost]
        public ActionResult<bool> InsertNode(TreeView form)
        {
            try
            {
                return _treeFormRepository.InsertNode(form);        
            }
            catch (Exception ex) // catches all exceptions
            {
                return View(ex.Message);
            }
        }

        // POST: /Treeview/UpdateNode
        [HttpPost]
        public ActionResult<bool> MoveNode(TreeView form)
        {           
            try
            {
                return _treeFormRepository.MoveNode(form);
            }
            catch (Exception ex) // catches all exceptions
            {
                return View(ex.Message);
            }
        }
    }
}
