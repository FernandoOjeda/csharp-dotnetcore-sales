using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewWebApplication.Models
{
    public class ObjectData2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("ObjectData")]
        public int ObjectDataId { get; set; }
        public ObjectData ObjectData { get; set; }
    }
}
