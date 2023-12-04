using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using COMP2084Project.Controllers;
using COMP2084Project.Data;
using Microsoft.EntityFrameworkCore;
using COMP2084Project.Models;

namespace COMP2084ProjectTesting
{
    [TestClass]
    public class AudioGenreControllerTests
    {
        ApplicationDbContext _context;
        AudioGenresController controller;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            var audioGenre = new AudioGenre { AudioGenreId = 505, Name = "Genre1" };
            _context.AudioGenres.Add(audioGenre);

            audioGenre = new AudioGenre { AudioGenreId = 872, Name = "Genre2" };
            _context.AudioGenres.Add(audioGenre);

            audioGenre = new AudioGenre { AudioGenreId = 209, Name = "Genre3" };
            _context.AudioGenres.Add(audioGenre);

            _context.SaveChanges();

            controller = new AudioGenresController(_context);
        }
        [TestMethod]
        public void DeleteNullIdReturnsErrorView()
        {
            var result = (ViewResult)controller.Delete(null).Result;

            Assert.AreEqual("Error", result.ViewName);
        }
        [TestMethod]
        public void DeleteWrongIdReturnsErrorView()
        {
            var result = (ViewResult)controller.Delete(100).Result;

            Assert.AreEqual("Error", result.ViewName);
        }
        [TestMethod]
        public void DeleteValidIdReturnsDeleteView()
        {
            var result = (ViewResult)controller.Delete(505).Result;

            Assert.AreEqual("Delete", result.ViewName);
        }
        [TestMethod]
        public void DeleteValidIdReturnsAudioGenre()
        {
            var result = (ViewResult)controller.Delete(209).Result;
            var model = (AudioGenre)result.Model;

            Assert.AreEqual(_context.AudioGenres.Find(209),model);
        }
        [TestMethod]
        public void DeleteConfirmedValidAudioGenreDeleted()
        {
            var initialCount = _context.AudioGenres.Count();

            var result = controller.DeleteConfirmed(505).Result;
            _context.SaveChanges();

            Assert.AreEqual(_context.AudioGenres.Count(), initialCount - 1);
        }
        [TestMethod]
        public void DeleteConfirmedNonExistentAudioGenreNoChange()
        {
            var initialCount = _context.AudioGenres.Count();

            var result = controller.DeleteConfirmed(999).Result;
            _context.SaveChanges();

            Assert.AreEqual(_context.AudioGenres.Count(), initialCount);
        }
        [TestMethod]
        public void DeleteConfirmedValidAudioGenreReturnsIndex()
        {
            var result = (RedirectToActionResult)controller.DeleteConfirmed(505).Result;

            Assert.AreEqual("Index", result.ActionName);
        }
    }
}
