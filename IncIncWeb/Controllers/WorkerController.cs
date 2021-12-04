using IncIncWeb.Context;
using IncIncWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IncIncWeb.Controllers
{
	public class WorkerController : Controller
	{
		private readonly WorkerContext _context;

		public WorkerController(WorkerContext context)
		{
			_context = context;
		}

		// GET: Worker
		public async Task<IActionResult> Index()
		{
			return View(await _context.Worker.ToListAsync());
		}

		// GET: Worker/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var workerModel = await _context.Worker
				.FirstOrDefaultAsync(m => m.Id == id);
			if (workerModel == null)
			{
				return NotFound();
			}

			return View(workerModel);
		}

		// GET: Worker/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Worker/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Messages")] WorkerModel workerModel)
		{
			if (ModelState.IsValid)
			{
				_context.Add(workerModel);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(workerModel);
		}

		// GET: Worker/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var workerModel = await _context.Worker.FindAsync(id);
			if (workerModel == null)
			{
				return NotFound();
			}
			return View(workerModel);
		}

		// POST: Worker/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Messages")] WorkerModel workerModel)
		{
			if (id != workerModel.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(workerModel);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!WorkerModelExists(workerModel.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(workerModel);
		}

		// GET: Worker/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var workerModel = await _context.Worker
				.FirstOrDefaultAsync(m => m.Id == id);
			if (workerModel == null)
			{
				return NotFound();
			}

			return View(workerModel);
		}

		// POST: Worker/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var workerModel = await _context.Worker.FindAsync(id);
			_context.Worker.Remove(workerModel);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool WorkerModelExists(int id)
		{
			return _context.Worker.Any(e => e.Id == id);
		}
	}
}
