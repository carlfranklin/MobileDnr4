using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileDnr.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string Text { get; set; } = "";
		public string LastError { get; set; } = "";
	}
}