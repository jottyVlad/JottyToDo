using System;

namespace JottyFitness.BL.Model
{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// User gender
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// User birth date
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// User weight
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// User height
        /// </summary>
        public double Height { get; set; }
        #endregion
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="name">User name</param>
        /// <param name="gender">User's gender</param>
        /// <param name="birthDate">User's birth date</param>
        /// <param name="weight">User's weight</param>
        /// <param name="height">User's height</param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Condition check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name is can't be empty or null!", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Name is can't be null!", nameof(gender));
            }
            if(birthDate < DateTime.Parse("01.01.1900") && birthDate > DateTime.Now)
            {
                throw new ArgumentException("Birth date is incorrect!", nameof(birthDate));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("Weight is incorrect!", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentException("Height is incorrect!", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
