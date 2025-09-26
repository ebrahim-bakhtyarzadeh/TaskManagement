using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.UserDataAccess
{
	 public class UserConfiguration : IEntityTypeConfiguration<Domain.UsersAgg.Models.User>
	 {
		  public void Configure(EntityTypeBuilder<Domain.UsersAgg.Models.User> builder)
		  {
			   builder.HasKey(x => x.Id);
			   builder.Property(c => c.PhoneNumber)
					.IsRequired()
					.HasMaxLength(11);
			   builder.Property(c => c.FirstName)
					.IsRequired()
					.HasMaxLength(15);
			   builder.Property(c => c.LastName)
					.IsRequired()
					.HasMaxLength(25);
			   builder.Property(c => c.Password)
					.IsRequired();
			   builder.OwnsMany(c => c.Tokens, option =>
			   {
					option.ToTable("UserToken", "user");
					option.HasKey(k => k.Id);
					option.Property(p => p.HashJwtToken)
						.IsRequired()
						.HasMaxLength(300);
					option.Property(p => p.HashRefreshToken)
						.IsRequired()
						.HasMaxLength(300);
			   });
			   builder.HasMany(c => c.Tasks)
					.WithOne(c => c.Owner)
					.HasForeignKey(c => c.UserId);
		  }
	 }
}
