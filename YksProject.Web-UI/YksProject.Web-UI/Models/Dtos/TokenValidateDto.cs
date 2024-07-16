namespace YksProject.Web_UI.Models.Dtos
{
    public class TokenValidateDto
    {
        public int TabloID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string Role { get; set; }
        public string KisiImageUrl { get; set; }
    }
}
