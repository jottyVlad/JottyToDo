using System;

namespace JottyFitness.BL.Model
{
    /// <summary>
    /// Gender
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Create a new gender
        /// </summary>
        /// <param name="name">Name of Gender</param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender is can't be empty or null!", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
