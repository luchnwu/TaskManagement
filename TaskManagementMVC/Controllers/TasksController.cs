using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TaskManagementMVC.Services;
//using TaskManagementMVC.Services;

namespace TaskManagementMVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly SwaggerClient _api;
        public TasksController(SwaggerClient api)
        {
            _api = api;
        }
        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            return View(await _api.TasksAllAsync());
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var taskItem = await _api.TasksGETAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _api.TasksPOSTAsync(taskItem);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(taskItem);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var taskItem = await _api.TasksGETAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _api.TasksPUTAsync(id, taskItem);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(taskItem);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var taskItem = await _api.TasksGETAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                await _api.TasksDELETEAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
