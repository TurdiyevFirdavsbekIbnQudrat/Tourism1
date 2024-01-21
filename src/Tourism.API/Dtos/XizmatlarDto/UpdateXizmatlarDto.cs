namespace Tourism.API.Dtos.XizmatlarDto
{
    public class UpdateXizmatlarDto
    {
        public string nomi { get; set; }
        public int narxi { get; set; }
        public IFormFile rasm { get; set; }
        public string boshlanishVaqti { get; set; }
        public string tugashVaqti { get; set; }
        public string haqida { get; set; }
        public string kun { get; set; }
        public int shaharId { get; set; }
    }
}
