using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApplication.Models
{
    public class ObjectData
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }


    }
}
