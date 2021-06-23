using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileDnr.Models
{
	public class Link
	{
		public int Id { get; set; }
		public int ShowId { get; set; }
		public string Text { get; set; } = "";
		public string Url { get; set; } = "";
		public string LastError { get; set; } = "";
	}
}