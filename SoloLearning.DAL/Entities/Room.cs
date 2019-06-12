using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoloLearning.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public DateTime CreatdDate { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

    }

    internal class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");

            builder.Property(k => k.Name).IsRequired(true);
            builder.Property(k => k.CreatdDate).IsRequired(true);

            builder.HasKey(k => k.Id);

            builder.HasMany(p => p.Messages).WithOne(p => p.Room).HasForeignKey(k => k.RoomId);
        }
    }
}
