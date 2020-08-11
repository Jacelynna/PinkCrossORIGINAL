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

namespace PinkCross.Pages.DonationRecords
{
    public class IndexModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public IndexModel(PinkCross.Data.PinkCrossContext context)
        {
            _context = context;
        }

        public IList<DonationRecord> DonationRecord { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Name { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CompanyName { get; set; }

        public SelectList DonorTypes { get; set; }
        [BindProperty(SupportsGet = true)]
        public string DonorType { get; set; }

        public async Task OnGetAsync()
        {

            IQueryable<string> genreQuery = from m in _context.DonationRecord
                                            orderby m.DonorType
                                            select m.DonorType;

            var DonationRecords = from m in _context.DonationRecord
                                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                DonationRecords = DonationRecords.Where(s => s.CompanyName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(DonorType))
            {
                DonationRecords = DonationRecords.Where(x => x.DonorType == DonorType);

            }

            DonorTypes = new SelectList(await genreQuery.Distinct().ToListAsync());
            DonationRecord = await DonationRecords.ToListAsync();
        }
    }
}
