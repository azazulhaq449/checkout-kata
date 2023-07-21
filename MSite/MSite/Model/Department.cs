using System.Collections.Generic;

namespace MSite.Model
{
    public class Department
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Person> Members { get; set; }

        public Department()
        {
            Members = new List<Person>();
        }
    }
}
