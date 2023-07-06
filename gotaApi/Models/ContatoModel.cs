using gotaApi.Models.baseModel;

namespace gotaApi.Models
{
    public class ContatoModel:BaseModel
    {
        public string Endereco { get; set; }
        public string LinkInstagram { get; set; }
        public string LinkWhatsapp { get; set; }
        public string LinkYoutube { get; set; }
    }
}
