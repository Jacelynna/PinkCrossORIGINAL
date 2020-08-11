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
    public class EditModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public EditModel(PinkCross.Data.PinkCrossContext context)
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

            DonorProfile = await _context.DonorProfile.FirstOrDefaultAsync(m => m.ID== id);

            if (DonorProfile == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DonorProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonorProfileExists(DonorProfile.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DonorProfileExists(int id)
        {
            return _context.DonorProfile.Any(e => e.ID ==id);
        }
    }
}
