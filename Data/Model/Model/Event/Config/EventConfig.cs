using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Model.Config;

public class EventConfig:IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.DateTime).HasColumnType("date");
        builder.Property(e => e.LocationId);
        //Fk
        builder.HasOne<Location>().
            WithMany().HasForeignKey(e => e.LocationId);

        //Inheritance"
        builder
            .HasDiscriminator<string>("Discriminator")
            .HasValue<Event>("Event")
            .HasValue<ComposedTeamsEvent>("ComposedTeamsEvent")
            .HasValue<TeamEvent>("TeamEvent");

    }
}