using System.Security.Principal;

namespace ApiPilotosF1.Model
{
    public class Piloto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Number { get; set; }
        public string? Nationality { get; set; }
        public string? Team { get; set; }
    }
}
