using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EcomProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace EcomProject.Data.PictureUpload
{
    public class IndexModel : PageModel
    {
        public IndexModel(IConfiguration configuration)
        {
            Blob = new Blob(configuration);
        }

        public Blob Blob { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var filePath = Path.GetTempFileName();

            using (var stream = System.IO.File.Create(filePath))
            {
                await Image.CopyToAsync(stream);

            }
            await Blob.UploadFile("seattlepour", "tempFile", filePath);

            //using (var memoryStream = new MemoryStream())
            //{
            //    await Image.CopyToAsync(memoryStream);
            //    await Blob.UploadFile("temp", "tempFile", memoryStream);

            //}

            var blob = await Blob.GetBlob("seattlepour", "temp");

            var temp = blob.Uri;

            //using (var stream = System.IO.File.Create(filePath))
            //{
            //  await Image.CopyToAsync(stream);
            //}

            // have this be whatever filepath the user inputs
            return Page();
        }
    }
}
