using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SoloLearning.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoloLearning.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }
        public String Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public Room Room { get; set; }
        public User User { get; set; }
    }

    internal class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Messages");

            builder.HasKey(k => k.Id);

            builder.Property(k => k.RoomId).IsRequired(true);
            builder.Property(k => k.UserId).IsRequired(true);
            builder.Property(k => k.Text).IsRequired(true);
            builder.Property(k => k.CreatedDate).IsRequired(true);

            builder.HasIndex(k => k.RoomId);

            builder.HasOne(k => k.User).WithMany(k => k.Messages).HasForeignKey(k => k.UserId);
        }
    }
}
