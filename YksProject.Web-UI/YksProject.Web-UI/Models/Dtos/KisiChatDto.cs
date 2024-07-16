namespace YksProject.Web_UI.Models.Dtos
{
    public class KisiChatDto
    {
        public int TabloID { get; set; }
        public string? KisiKullaniciAdi { get; set; }
        public string? KisiImageUrl { get; set; }

        public bool UserOnlineMi { get; set; }
    }
}
