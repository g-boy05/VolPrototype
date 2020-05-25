using ArtzaTechnologies.DAL.Contexts;
using ArtzaTechnologies.DAL.Domains;
using GeoCoordinatePortable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ArtzaTechnologies.Services.Interfaces;

namespace ArtzaTechnologies.Controllers
{
    public class AvionsController : Controller
    {
        private readonly AppDomainContext _context;

        public AvionsController(AppDomainContext context)
        {
            _context = context;
        }
        // GET: Avion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Avions.ToListAsync());
        }

        // GET: Avion/Details/5
        public ActionResult Details(int? id)
        {
            return View();
        }

        // GET: Avion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Avion/Create
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

        // GET: Avion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Avion/Edit/5
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

        // GET: Avion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Avion/Delete/5
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