
using System.ComponentModel.DataAnnotations;

namespace apiwithdb.Models.dtos
{
    public class CreateTicketDto
    {
        [Required, StringLenght(200)]
        public string notes { get; set; } = string.Empty;
    }
}
