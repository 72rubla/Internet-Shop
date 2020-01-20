using Shop.Domain.Abstract;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shop.Domain.Concrete
{
    public class EFUserRepository:IUserRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<User> Users
        {
            get { return context.Users; }
        }

        public void SaveUser(User user)
        {
            if (user.ID == 0)
                context.Users.Add(user);
            else
            {
                User dbEntry = context.Users.Find(user.ID);
                if (dbEntry != null)
                {
                    //dbEntry.Name = user.Name;
                    //dbEntry.Description = user.Description;
                    //dbEntry.Price = user.Price;
                    //dbEntry.Category = user.Category;
                    //dbEntry.ImageData = user.ImageData;
                    //dbEntry.ImageMimeType = IUserRepository.ImageMimeType;
                    dbEntry.FirstName = user.FirstName;
                    dbEntry.SecondName = user.SecondName;
                    dbEntry.LastName = user.LastName;
                    dbEntry.Login = user.Login;
                    dbEntry.Password = user.Password;
                    dbEntry.RoleId = user.RoleId;
                    dbEntry.Position = user.Position;
                    dbEntry.ImageData = user.ImageData;
                    dbEntry.ImageMimeType = user.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public User DeleteUser(int ID)
        {
            User dbEntry = context.Users.Find(ID);
            if (dbEntry != null)
            {
                context.Users.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}