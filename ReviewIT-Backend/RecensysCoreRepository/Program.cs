using System;
using RecensysCoreRepository.EF;
using RecensysCoreRepository.Entities;

namespace RecensysCoreRepository
{
    public class Program
    {
        /* Needed because of a bug in EFCore */
        public static void Main(string[] args)
        {

            using (var factory = new RepositoryFactory(new RecensysContext()))
            {
                var repo = factory.GetRepo<User>();
                repo.Create(new User
                {
                    FirstName = "Jacob",
                    LastName = "Cholewa",
                    Email = "jbec@itu.dk",
                    Password = "123",
                    PasswordSalt = "123"
                });

                foreach (var user in repo.GetAll())
                {
                    Console.WriteLine(user.FirstName);
                }
                Console.ReadLine();
            }
        }
    }
}