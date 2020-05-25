using ArtzaTechnologies.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArtzaTechnologies.Controllers
{
    public class AeroportsController : Controller
    {
        private readonly IAeroportService _aeroportService;

        public AeroportsController(IAeroportService aeroportService)
        {
            _aeroportService = aeroportService;
        }
        // GET: Aeroports
        public async Task<IActionResult> Index()
        {
            var result = await _aeroportService.GetAeroports();
            return View(result);
        }

        // GET: Aeroports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Aeroports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aeroports/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aeroports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Aeroports/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aeroports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Aeroports/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}