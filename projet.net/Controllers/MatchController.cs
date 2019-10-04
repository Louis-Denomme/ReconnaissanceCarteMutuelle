using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using projet.net.Models;
using IronOcr;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace projet.net.Controllers
{
    [Route("api/Match")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        static string baseFolder = Path.Combine("/","Users","lea","Projects","projet.net","projet.net","wwwroot","Images");
        static string CarteFolder = Path.Combine(baseFolder, "Cartes");
        static string LogoFolder = Path.Combine(baseFolder, "logos");

        private readonly projetContext _context;

        public MatchController(projetContext context)
        {
            _context = context;

            if (_context.Mutuelles.Count() == 0)
            {
                _context.Mutuelles.Add(new Mutuelle { Name = "Mutuelle1" });
                _context.SaveChanges();
            }
        }

        // POST: api/Match
        [HttpGet]
        public string getImage()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                AutoOcr OCR = new AutoOcr() { ReadBarCodes = false };
                var Carte = Path.Combine(LogoFolder, "harmonie.png");
                var Results = OCR.Read(Carte);
                Console.WriteLine(Results.Text);
            }

            return "Incompatible";
        }
    }
}
