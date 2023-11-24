using NoteProjectDomain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProjectDomain.Entities
{
    public class Kullanici : BaseClass
    {
        public string UserName { get; set; }
        private string password;

        public string Password
        {
            get { return password; }
            set 
            {
                if (value.Length < 6)
                {
                    throw new ArgumentException("Şifre 6 karakterden kısa olamaz.");
                }
                else
                {
                    password = value;
                }
                
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<Note> Notes { get; set; }

        
    }
}
