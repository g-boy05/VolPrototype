using ArtzaTechnologies.DAL.Contexts;
using ArtzaTechnologies.DAL.Domains;
using ArtzaTechnologies.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace ArtzaTechnologies.Controllers
{
    public class VolsController : Controller
    {
        //Todo Supprimer AppDomainContext et utiliser entityrepository ou implemeter les methodes sous les services aeroportsservice et avionservice et injecter dans le controlleur
        private readonly AppDomainContext _context;
        private readonly IVolService _volService;

        public VolsController(AppDomainContext context, IVolService volService)
        {
            _context = context;
            _volService = volService;
        }
        // GET: Vols
        public async Task<IActionResult> Index()
        {
            var result = await _volService.GetVolsDtos();
            return View(result);
        }

        // GET: Vols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _volService.GetVolDtoById(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: Vols/Create
        public ActionResult Create()
        {
            //list des avions pour dropdown de choix
            var listeAvion = new SelectList(_context.Avions.ToList(), "Id", "Libelle");
            ViewBag.ListeAvion = listeAvion;
            //list des aeroport pour dropdown de choix
            var listeAeroport = new SelectList(_context.Aeroports.ToList(), "Id", "Nom");
            ViewBag.ListeAeroport = listeAeroport;
            return View();
        }

        // POST: Vols/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vol vol)
        {
                foreach (var key in ModelState.Keys)
                    if (key.Split('.').Length >= 2)
                    {
                        ModelState[key].Errors.Clear();
                        ModelState[key].ValidationState = ModelValidationState.Valid;
                    }

                if (ModelState.IsValid)
                {
                //On utilise la variable isAddSuccess pour l'utiliser dans une evolution dans le cas d'une redirection vers une page d'erreur ou pour afficher des messages d'erreurs 
                bool isAddSuccess = await _volService.AddVol(vol);
                return RedirectToAction(nameof(Index));
                }
            return View(vol);
        }

        // GET: Vols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var vol =await _volService.GetVolById(id);
            if (vol == null)
                return NotFound();
            //list des avions pour dropdown de choix
            var listeAvion = new SelectList(_context.Avions.ToList(), "Id", "Libelle");
            ViewBag.ListeAvion = listeAvion;
            //list des aeroport pour dropdown de choix
            var listeAeroport = new SelectList(_context.Aeroports.ToList(), "Id", "Nom");
            ViewBag.ListeAeroport = listeAeroport;
            return View(vol);
        }

        // POST: Vols/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Vol vol)
        {
            if (id != vol.Id)
                return NotFound();

            foreach (var key in ModelState.Keys)
            if (key.Split('.').Length >= 2)
            {
               ModelState[key].Errors.Clear();
               ModelState[key].ValidationState = ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                if(await _volService.EditVol(vol))
                    return RedirectToAction(nameof(Index));
            }
            return View(vol);
        }

        // GET: Vols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var vol = await _volService.GetVolDtoById(id);

            if (vol == null)
                return NotFound();
            return View(vol);
        }

        // POST: Vols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //Todo utiliser result pour manipuler la redirection et um message d'erreur si la suppression est echouee
            var result = await _volService.DeleteVol(id);
            return RedirectToAction(nameof(Index));
        }

    }
}