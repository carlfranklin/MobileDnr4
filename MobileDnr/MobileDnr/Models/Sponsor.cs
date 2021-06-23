using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileDnr.Models
{
    public class Sponsor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string BannerUrl { get; set; } = "";
        public string Blurb { get; set; } = "";
        public string LandingUrl { get; set; } = "";
        public string Copy { get; set; } = "";
        public string LastError { get; set; } = "";
    }
}