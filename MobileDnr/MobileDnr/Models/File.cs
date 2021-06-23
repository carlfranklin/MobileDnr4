using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileDnr.Models
{
	public class File
	{
		public int Id { get; set; }
		public int ShowId { get; set; }
		public string Url { get; set; }
		public int Minutes { get; set; }
		public int Bytes { get; set; }
	}
}