using NoteProject.DAL.Context;
using NoteProjectDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteProject.Repositories.Repositories
{
    public class UserRepository 
    {
        public UserRepository()
        {
            db = new AppDbContext();
        }
        AppDbContext db;

        public List<Kullanici> GetUsers()
        {
            List<Kullanici> users = db.Users.ToList();
            return users;
        }

        public List<Kullanici> GetUsersByUserName(string username) 
        {
            List<Kullanici> users = db.Users.Where(u => u.UserName == username).ToList();
            return users;
        }

        public Kullanici GetUserByUserName(string username) 
        {
            Kullanici kullanici = db.Users.FirstOrDefault(u => u.UserName == username);
            return kullanici;
        }

        public Kullanici GetUserById(int id) 
        {
            Kullanici k = db.Users.FirstOrDefault(x => x.Id == id);
            return k;
        }

        public void AddUser(Kullanici user)
        {
            db.Add(user);
            db.SaveChanges();
        }

        public void UpdateUser(Kullanici user) 
        {
            db.Update(user);
            db.SaveChanges();
        }
    }
}
