using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetRocks.Models
{
    public class GetByShowNumbersRequest
    {
        public string ShowName { get; set; }
        public List<int> Indexes { get; set; }
    }
}
