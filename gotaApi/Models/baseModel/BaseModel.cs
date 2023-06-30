namespace gotaApi.Models.baseModel
{
    public class BaseModel
    {
        public string Id { get; set; } = string.Empty; 
        public DateTime? DataDeCadastro { get;  set; }
        public DateTime? DataDeAtualizacao { get;  set; }
    }
}
