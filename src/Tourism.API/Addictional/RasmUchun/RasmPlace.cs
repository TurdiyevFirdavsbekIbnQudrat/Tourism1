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
            string pathGet= "images/" + Guid.NewGuid() + extension;
            string path = Path.Combine(webHostEnvironment.WebRootPath, pathGet);
            //string path = webHostEnvironment.WebRootPath + "\\images\\" + Guid.NewGuid() + extension;
            using (FileStream file = new FileStream(path, FileMode.Create))
            {
                await rasm.CopyToAsync(file);
            }
            return pathGet;
        }
    }
}
