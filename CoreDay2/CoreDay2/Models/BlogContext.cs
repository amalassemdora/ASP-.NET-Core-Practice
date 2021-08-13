using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDay2.Models
{
	public class BlogContext:DbContext
	{
		public BlogContext(DbContextOptions<BlogContext>option):base(option)
		{

		}
		public virtual DbSet<Blog> blogs { get; set; }
		public virtual DbSet<Post> posts { get; set; }

	}
}
