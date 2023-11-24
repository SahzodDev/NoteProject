using NoteProjectDomain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProjectDomain.Entities
{
    public class Note : BaseClass
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Kullanici User { get; set; }
        public int UserRefId { get; set; }
    }
}
