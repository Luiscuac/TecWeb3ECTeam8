using System.ComponentModel.DataAnnotations;

namespace TecWebGrupo8.Models.dtos;

public class CreateGuestDto
{
    [Required, StringLength(200)]
    public string FullName { get; set; } = string.Empty;

    public bool Confirmed { get; set; } = false;
}
