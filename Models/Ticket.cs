using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public string notes { get; set; } = string.Empty;
    }
}
