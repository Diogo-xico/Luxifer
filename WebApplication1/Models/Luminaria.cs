namespace WebApplication1.Models
{
    public class Luminaria
    {
        public int Id { get; set; }
        public string Modelo { get; set; }

        public string Cidade { get; set; }

        public string Pais { get; set; }

        public string id_cliente { get; set; }
        public string id_grupo { get; set; } 
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Estado { get; set;}


    }
}
