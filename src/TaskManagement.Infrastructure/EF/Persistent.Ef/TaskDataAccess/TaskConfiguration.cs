using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.TasksAgg.Models;

namespace TaskManagement.Infrastructure.EF.Persistent.Ef.TaskDataAccess
{
	 public class TaskConfiguration : IEntityTypeConfiguration<Tasks>
	 {
		  public void Configure(EntityTypeBuilder<Tasks> builder)
		  {
			   builder.ToTable("Tasks", "dbo");
			   builder.HasKey(t => t.Id);
			   builder.Property(c => c.StartTime)
					.IsRequired();
			   builder.Property(c => c.Description)
					.IsRequired()
					.HasMaxLength(500);
			   builder.Property(c => c.Name)
					.IsRequired()
					.HasMaxLength(200);

			   builder.OwnsMany(c => c.Items, option =>
			   {
					option.ToTable("CheckListItems", "task");
					option.HasKey(t => t.Id);
					option.Property(c => c.Name).IsRequired();
					option.Property(c => c.Description).IsRequired();
			   });
				
		  }
	 }
}
