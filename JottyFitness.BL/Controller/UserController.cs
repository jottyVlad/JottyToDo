using JottyFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace JottyFitness.BL.Controller
{
    /// <summary>
    /// User's controller
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Application's user
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Create a new controller
        /// </summary>
        /// <param name="user"></param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }
        /// <summary>
        /// Save user's data
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate) )
            {
                formatter.Serialize(fs, User);
            }
        }
        /// <summary>
        /// Load user's data
        /// </summary>
        /// <returns>Application's user</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if(formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                //TODO: что делать, если пользователь не найден?
            }
        }
    }
}
