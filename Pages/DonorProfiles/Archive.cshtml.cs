using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PinkCross.Data;
using PinkCross.Models;

namespace PinkCross.Pages.DonorProfiles
{
    public class ArchiveModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public ArchiveModel(PinkCross.Data.PinkCrossContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DonorProfile DonorProfile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DonorProfile = await _context.DonorProfile.FirstOrDefaultAsync(m => m.ID == id);

            if (DonorProfile == null)
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

            DonorProfile = await _context.DonorProfile.FindAsync(id);

            if (DonorProfile != null)
            {
                _context.DonorProfile.Remove(DonorProfile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
   