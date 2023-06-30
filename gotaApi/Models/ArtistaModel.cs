using gotaApi.Models.baseModel;

namespace gotaApi.Models
{
    public class ArtistaModel: BaseModel
    { 
        public string Nome { get; set; } = string.Empty;
        public string Celular { get; set; } = string.Empty;
        public string Atuacao { get; set; } = string.Empty;
    }
}
