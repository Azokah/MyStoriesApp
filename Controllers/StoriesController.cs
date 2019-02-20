using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMyStories.Models;

namespace MvcMyStories.Controllers
{
    
    public class StoriesController : Controller
    {
        private readonly MvcStoryContext _context;

        public StoriesController(MvcStoryContext context)
        {
            _context = context;
        }

        // GET: Stories
        // Index modified to be able to retrieve stories by title name
        public async Task<IActionResult> Index(string searchString)
        {
            //We retrieve every story
            var stories = from m in _context.story
                 select m;

                //And we parse with only the ones that contain the searchString in their name
                if (!String.IsNullOrEmpty(searchString))
                {
                    stories = stories.Where(s => s.Title.Contains(searchString));
                }
                
                //For graphic reasons we only want to show 95 characters in index stories
                //Also, we store the name of the image on the db, but we want to return the correct path
                // inside the images folder.
                foreach (Story s in stories){
                    if(s.Content.Length > 95){
                        s.Content = s.Content.Substring(0,92);
                        s.Content += "...";
                    }
                    s.imgPath = "images/" + s.imgPath;
                }

            return View(await stories.ToListAsync());
        }

        // GET: Stories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.story
                .FirstOrDefaultAsync(m => m.Id == id);
            if (story == null)
            {
                return NotFound();
            }

            //Also, we store the name of the image on the db, but we want to return the correct path
            // inside the images folder.
            story.imgPath = "../../images/" + story.imgPath;

            return View(story);
        }

        // GET: Stories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Content,imgPath")] Story story)
        {
            if (ModelState.IsValid)
            {
                _context.Add(story);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(story);
        }

        // GET: Stories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.story.FindAsync(id);
            if (story == null)
            {
                return NotFound();
            }
            return View(story);
        }

        // POST: Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Content,imgPath")] Story story)
        {
            if (id != story.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(story);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoryExists(story.Id))
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
            return View(story);
        }

        // GET: Stories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var story = await _context.story
                .FirstOrDefaultAsync(m => m.Id == id);
            if (story == null)
            {
                return NotFound();
            }

            return View(story);
        }

        // POST: Stories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var story = await _context.story.FindAsync(id);
            _context.story.Remove(story);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoryExists(int id)
        {
            return _context.story.Any(e => e.Id == id);
        }
    }
}
