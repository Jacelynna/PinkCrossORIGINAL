using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PinkCross.Data;
using PinkCross.Models;

namespace PinkCross.Pages.DonationRecords
{
    public class DetailsModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public DetailsModel(PinkCross.Data.PinkCrossContext context)
        {
            _context = context;
        }

        public DonationRecord DonationRecord { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DonationRecord = await _context.DonationRecord.FirstOrDefaultAsync(m => m.ID == id);

            if (DonationRecord == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
