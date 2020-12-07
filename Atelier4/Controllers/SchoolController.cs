using Atelier4.Models;
using Atelier4.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atelier4.Controllers
{
    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;

        public SchoolController(ISchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        // GET: SchoolController
        public ActionResult Index()
        {
            return View(_schoolRepository.GetAll());
            
        }

        // GET: SchoolController/Details/5
        public ActionResult Details(int id)
        {

            ViewBag.studentcount = _schoolRepository.StudentCount(id);
            ViewBag.StudentAgeAverage = _schoolRepository.StudentAgeAverage(id);
            var school = _schoolRepository.GetById(id);
            return View(school);
        }

        // GET: SchoolController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchoolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(School sch)
        {
            
            try
            {
                _schoolRepository.Add(sch);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Edit/5
        public ActionResult Edit(int id)
        {
            var sch = _schoolRepository.GetById(id);
            return View(sch);
            
            
            
        }

        // POST: SchoolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(School s )
        {
            try
            {
                _schoolRepository.Edit(s);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SchoolController/Delete/5
        public ActionResult Delete(int id)
        {
            var school = _schoolRepository.GetById(id);
            return View(school);
        }

        // POST: SchoolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(School s)
        {
            try
            {
                
                _schoolRepository.Delete(s);
                return RedirectToAction(nameof(Index));
            
            }
            catch
            {
                return View();
            }
        }
    }
}
