 using gotaApi.Models.baseModel;

namespace gotaApi.Models
{
    public class ProjetoModel : BaseModel
    { 
        public string Nome { get;  set; } = string.Empty;
        public string Descricao { get;  set; } = string.Empty;
        public List<string> ArtistasId { get; set; } = new List<string>();
    }
}
