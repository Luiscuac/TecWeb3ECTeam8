using System.ComponentModel.DataAnnotations;
namespace TecWeb3ECTeam8.Models.dtos
{
    public class CreateEventDto
    {
        [Required, StringLength(100)]
        public string Title { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        [Range(1,1000)]
        public int Capacity { get; set; }
    }
}
