namespace Tourism.API.Addictional.RasmUchun
{
    public interface IRasmPlace
    {
        public ValueTask<string> GetRasm(IFormFile rasm);
    }
}
