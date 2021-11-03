using Application.DTOs;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class ListIndexController : Controller
    {
        private readonly IListIndexService _listIndexService;
        private readonly IChoreService _choreService;
        public ListIndexController(IChoreService choreService, IListIndexService listIndexService)
        {
            _listIndexService = listIndexService;
            _choreService = choreService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var listIndexes = await _listIndexService.GetListIndexDTOs();
            return View(listIndexes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListIndexDTO listIndexDTO)
        {
            if (ModelState.IsValid)
            {
                await _listIndexService.Add(listIndexDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(listIndexDTO);
        }

        [HttpGet()]
        public async  Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var listIndexDTO = await _listIndexService.GetById(id);
            if (listIndexDTO == null) return NotFound();

            return View(listIndexDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ListIndexDTO listIndexDTO)
        {
            if (ModelState.IsValid)
            {
                await _listIndexService.Update(listIndexDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(listIndexDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var listIndexDTO = await _listIndexService.GetById(id);
            if (listIndexDTO == null) return NotFound();

            return View(listIndexDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {            
            await _listIndexService.Remove(id);
            return RedirectToAction("Index");
        }

        //--------------------------------------------------------------------------------



        [HttpGet()]
        public async Task<IActionResult> ListChores(int id)
        {
           
           var chores = await _choreService.GetChoresDTOs();
            if (chores != null)
            {
                var listChore = chores.Where((e) => e.ListIndexId == id);
                return View(listChore);
            }
            return View();

        }

        [HttpGet()]
        public async  Task<IActionResult> CreateChore()
        {
            ViewBag.ListIndexId = new SelectList(
                await _listIndexService.GetListIndexDTOs() , "Id", "Name");

            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> CreateChore(ChoreDTO choreDTO)
        {            

            if (ModelState.IsValid)
            {
                await _choreService.Add(choreDTO);
                return RedirectToAction(nameof(Index));

            }

            return View(choreDTO);
        }



        [HttpGet()]
        public async Task<IActionResult> EditChore(int? id)
        {
            if (id == null) return NotFound();
            var choreDTO = await _choreService.GetById(id);

            if (choreDTO == null) return NotFound();

            var chores =  await _listIndexService.GetListIndexDTOs();            
            ViewBag.ListIndexId = new SelectList(
                await _listIndexService.GetListIndexDTOs(), "Id", "Name");

            return View(choreDTO);
        }

        [HttpPost]
        public async Task<IActionResult> EditChore(ChoreDTO choreDTO)
        {
            if (ModelState.IsValid)
            {
                await _choreService.Update(choreDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(choreDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> DeleteChore(int? id)
        {
            if (id == null) return NotFound();
            var choreDTO = await _choreService.GetById(id);
            if (choreDTO == null) return NotFound();
            
            return View(choreDTO);
        }

        [HttpPost(), ActionName("DeleteChore")]
        public async Task<IActionResult> DeleteChoreConfirmed(int id)
        {            
            await _choreService.Remove(id);
            return RedirectToAction("Index");
        }



    }
}
