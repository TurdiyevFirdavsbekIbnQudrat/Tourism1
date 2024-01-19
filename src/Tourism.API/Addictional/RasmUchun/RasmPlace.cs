using Microsoft.AspNetCore.Hosting;

namespace Tourism.API.Addictional.RasmUchun
{
    public class RasmPlace:IRasmPlace
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public RasmPlace(IWebHostEnvironment webHostBuilder)
        {
            webHostEnvironment = webHostBuilder;
        }

        public async ValueTask<string> GetRasm(IFormFile rasm)
        {
            string extension = Path.GetExtension(rasm.FileName);
            string path = webHostEnvironment.WebRootPath + "\\\\Images\\\\" + Guid.NewGuid() + extension;
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                await rasm.CopyToAsync(file);
            }
            return path;
        }
    }
}
