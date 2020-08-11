using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PinkCross.Data;
using PinkCross.Models;

namespace PinkCross.Pages.DonationRecords
{
    public class CreateModel : PageModel
    {
        private readonly PinkCross.Data.PinkCrossContext _context;

        public CreateModel(PinkCross.Data.PinkCrossContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public DonationRecord DonationRecord { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DonationRecord.Add(DonationRecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
