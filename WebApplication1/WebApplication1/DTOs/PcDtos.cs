namespace WebApplication1.DTOs
{
    public class PcListItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float Weight { get; set; }
        public int Warranty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Stock { get; set; }
    }

    public class PcComponentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<ComponentInPcDto> Components { get; set; } = new();
    }

    public class ComponentInPcDto
    {
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description  { get; set; }
        public int Amount {get; set; }

        public string Manufacturer { get; set; } = null!;
        public string Type{ get; set; } = null!;
    }

    public class CreatePcDto
    {
        public string Name { get; set; } = null!;
        public float Weight { get; set; }
        public int Warranty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Stock { get; set; }
    }

    public class UpdatePcDto
    {
        public string Name { get; set; } = null!;
        public float Weight { get; set; }
        public int Warranty { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Stock { get; set; }
    }
}
