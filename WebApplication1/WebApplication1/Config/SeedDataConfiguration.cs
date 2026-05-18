using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entities;

namespace WebApplication1.Config
{
    public class ComponentTypeConfiguration : IEntityTypeConfiguration<ComponentType>
    {
        public void Configure(EntityTypeBuilder<ComponentType> builder)
        {
            builder.HasData(
                new ComponentType { Id = 1, Abbreviation = "CPU", FullName = "Central Processing Unit" },
                new ComponentType { Id = 2, Abbreviation = "GPU", FullName = "Graphics Processing Unit" },
                new ComponentType { Id = 3, Abbreviation = "RAM", FullName = "Random Access Memory" }
            );
        }
    }

    public class ComponentManufacturerConfiguration : IEntityTypeConfiguration<ComponentManufacturer>
    {
        public void Configure(EntityTypeBuilder<ComponentManufacturer> builder)
        {
            builder.HasData(
                new ComponentManufacturer { Id = 1, Abbreviation = "Intel", FullName = "Intel Corporation",         FoundationDate = new DateTime(1968, 7, 18) },
                new ComponentManufacturer { Id = 2, Abbreviation = "AMD",   FullName = "Advanced Micro Devices",    FoundationDate = new DateTime(1969, 5, 1)  },
                new ComponentManufacturer { Id = 3, Abbreviation = "NVDA",  FullName = "NVIDIA Corporation",        FoundationDate = new DateTime(1993, 4, 5)  }
            );
        }
    }

    public class ComponentConfiguration : IEntityTypeConfiguration<Component>
    {
        public void Configure(EntityTypeBuilder<Component> builder)
        {
            builder.HasData(
                new Component
                {
                    Code                    = "I9-14900K",
                    Name                    = "Intel Core i9-14900K",
                    Description             = "High-performance desktop processor with 24 cores",
                    ComponentManufacturersId = 1,
                    ComponentTypesId         = 1
                },
                new Component
                {
                    Code                    = "RX7900XTX",
                    Name                    = "AMD Radeon RX 7900 XTX",
                    Description             = "Flagship AMD graphics card with 24GB GDDR6",
                    ComponentManufacturersId = 2,
                    ComponentTypesId         = 2
                },
                new Component
                {
                    Code                    = "RTX4090",
                    Name                    = "NVIDIA GeForce RTX 4090",
                    Description             = "Top-tier NVIDIA GPU with 24GB GDDR6X",
                    ComponentManufacturersId = 3,
                    ComponentTypesId         = 2
                }
            );
        }
    }

    public class PCConfiguration : IEntityTypeConfiguration<PC>
    {
        public void Configure(EntityTypeBuilder<PC> builder)
        {
            builder.HasData(
                new PC { Id = 1, Name = "Gaming Beast X",  Weight = 12.5f, Warranty = 36, CreatedAt = new DateTime(2026, 5, 8,  9,  0, 0), Stock = 5  },
                new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2f,  Warranty = 24, CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0), Stock = 12 },
                new PC { Id = 3, Name = "Workstation Pro", Weight = 18.0f, Warranty = 48, CreatedAt = new DateTime(2026, 3, 1,  10, 0, 0), Stock = 3  }
            );
        }
    }

    public class PCComponentConfiguration : IEntityTypeConfiguration<PCComponent>
    {
        public void Configure(EntityTypeBuilder<PCComponent> builder)
        {
            builder.HasData(
                new PCComponent { PCId = 1, ComponentCode = "I9-14900K", Amount = 1 },
                new PCComponent { PCId = 1, ComponentCode = "RTX4090",   Amount = 1 },
                new PCComponent { PCId = 2, ComponentCode = "I9-14900K", Amount = 1 },
                new PCComponent { PCId = 2, ComponentCode = "RX7900XTX", Amount = 1 },
                new PCComponent { PCId = 3, ComponentCode = "I9-14900K", Amount = 2 },
                new PCComponent { PCId = 3, ComponentCode = "RTX4090",   Amount = 4 }
            );
        }
    }
}
