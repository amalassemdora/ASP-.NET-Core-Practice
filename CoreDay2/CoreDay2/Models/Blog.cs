using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDay2.Models
{
	public class Blog
	{
		public Blog()
		{
			posts = new List<Post>();
		}
		public int Id { get; set; }
		public string title { get; set; }
		public string desc { get; set; }
		public virtual List<Post> posts{ get; set; }


	}
}
