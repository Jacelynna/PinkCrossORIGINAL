using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PinkCross.Data;
using PinkCross.Models;

namespace PinkCross.Pages.DonorProfiles
{
    public class IndexModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public IndexModel(PinkCross.Data.PinkCrossContext context)
        {
            _context = context;
        }

        public IList<DonorProfile> DonorProfile { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DonorName { get; set; }

        public SelectList Donornrics { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Donornric { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> genreQuery = from m in _context.DonorProfile
                                            orderby m.Donornric
                                            select m.Donornric;

            var DonorProfiles = from m in _context.DonorProfile
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                DonorProfiles = DonorProfiles.Where(s => s.DonorName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(Donornric))
            {
                DonorProfiles = DonorProfiles.Where(x => x.Donornric == Donornric); 

            }

            Donornrics = new SelectList(await genreQuery.Distinct().ToListAsync()); 
            DonorProfile = await DonorProfiles.ToListAsync();
        }
    }
}
