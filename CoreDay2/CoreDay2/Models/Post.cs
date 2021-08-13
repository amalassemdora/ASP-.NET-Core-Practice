using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDay2.Models
{
	public class Post
	{
		public int Id { get; set; }
		public string post_title { get; set; }
		public string body { get; set; }
		public DateTime? time { get; set; }
		[ForeignKey("blog")]
		public int bId { get; set; }
		public virtual Blog blog { get; set; }


	}
}
