using Microsoft.EntityFrameworkCore;

namespace LokusAPI.Dtos
{
    public class ImageDto
    {
            public int Id { get; set; }
            public string Base64Data { get; set; } = string.Empty;
 
    }

}

