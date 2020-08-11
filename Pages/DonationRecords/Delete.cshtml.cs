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
    public class DeleteModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public DeleteModel(PinkCross.Data.PinkCrossContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DonationRecord = await _context.DonationRecord.FindAsync(id);

            if (DonationRecord != null)
            {
                _context.DonationRecord.Remove(DonationRecord);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
