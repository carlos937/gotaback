using domain.entidades;
using gotaApi.Models.baseModel;

namespace gotaApi.Models
{
    public class ProdutoModel:BaseModel
    {
        public string Titulo { get;  set; }
        public string Descricao { get;  set; }
        public double Valor { get;  set; }
        public List<string> ArtistasId { get;  set; } = new List<string>();
    }
}
