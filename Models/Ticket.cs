using System.ComponentModel.DataAnnotations;

namespace TecWebGrupo8.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public string notes { get; set; } = string.Empty;
    }
}
