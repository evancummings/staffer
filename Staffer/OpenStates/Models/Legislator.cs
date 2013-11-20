using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staffer.OpenStates.Models
{
    public class Legislator
    {
        public string last_name { get; set; }
        public string updated_at { get; set; }
        public string full_name { get; set; }
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string district { get; set; }
        public string state { get; set; }
        public string votesmart_id { get; set; }
        public string party { get; set; }
        public string biography { get; set; }
        public string leg_id { get; set; }
        public string active { get; set; }
        public string transparencydata_id { get; set; }
        public string photo_url { get; set; }
        public string url { get; set; }
        public string country { get; set; }
        public string created_at { get; set; }
        public string level { get; set; }
        public string chamber { get; set; }
        public string suffixes { get; set; }
        public string csrfmiddlewaretoken { get; set; }
        public string nickname { get; set; }
        public string email { get; set; }
        public List<Office> Offices { get; set; }
    }
}
