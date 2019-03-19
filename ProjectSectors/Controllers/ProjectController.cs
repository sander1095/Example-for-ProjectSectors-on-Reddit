using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectSectors.Domain;
using ProjectSectors.Models;

namespace ProjectSectors.Controllers
{
    public class ProjectController : Controller
    {
        #region FakeDatabase
        private static List<Project> Projects { get; } = new List<Project>()
        {
            new Project("Project 1", "Project!")
            {
                ProjectID = 2
            },


            new Project("Project 2", "Project!")
            {
                ProjectID = 2
            },
            new Project("Project 3", "Project!")
            {
                ProjectID = 3
            },
        };

        private static List<Sector> Sectors { get; } = new List<Sector>
        {
            new Sector(1, "Sector 1"),
            new Sector(2, "Sector 2"),
            new Sector(3, "Sector 3"),
            new Sector(4, "Sector 4"),
            new Sector(5, "Sector 5"),
        };

        private static List<ProjectSector> ProjectSectors { get; } = new List<ProjectSector>();
        #endregion Fake Database

        // GET: Project
        public ActionResult Index()
        {
            return View(Projects);
        }

        // GET: Project/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Project/Create
        public ActionResult Create()
        {
            var viewModel = new CreateProjectViewModel
            {
                Sectors = Sectors.Select(_ => new SectorViewModel
                {
                    Id = _.SectorID,
                    Title = _.Title
                }).ToList()
            };

            return View(viewModel);
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CreateProjectViewModel viewModel)
        {
            try
            {
                var selectedSectors = viewModel.Sectors.Where(_ => _.Selected);

                var selectedSectorsFromDatabase = Sectors
                    .Where(sectorInDb => selectedSectors.Any(selectedSector => selectedSector.Id == sectorInDb.SectorID));


                // I assume that the ID is set by the database which we are not using here
                var newProject = new Project(viewModel.Title, viewModel.Description);


                newProject.ProjectSectors = selectedSectors
                    .Select(sector => new ProjectSector
                    {
                        // You might need to fiddle a bit with setting Ids here. Just follow tutorials on how to create many to many entities in a controller in ASP NET.
                        Project = newProject,
                        Sector = selectedSectorsFromDatabase.Single(_ => _.SectorID == sector.Id)
                    }).ToList();

                ProjectSectors.AddRange(newProject.ProjectSectors);
                Projects.Add(newProject);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Project/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Project/Delete/5
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