using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class FileManagerController : Controller
    {
        [HttpPost("upload")]
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            try
            {
                var result = new List<FileUpload>();
                foreach (var file in files)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                    var stream = new FileStream(path, FileMode.Create);
                    file.CopyToAsync(stream);
                    result.Add(new FileUpload() { Name = file.FileName, Length = file.Length });
                }
                return Ok(result);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
