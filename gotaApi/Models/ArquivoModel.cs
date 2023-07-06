using gotaApi.Models.baseModel;

namespace gotaApi.Models
{
    public class ArquivoModel:BaseModel
    {
        public string Nome { get; set; }
        public string Caminho { get; set; }
    }
}
