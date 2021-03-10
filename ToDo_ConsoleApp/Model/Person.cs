namespace ToDo_ConsoleApp.Model
{
    public class Person
    {
        private readonly int _personId;
        string _firstName;
        string _lastName;



        /// <summary>
        /// Person is constructor for a Person. Sets up a persons initial
        /// values. If no name input, a default name will be assigned to person.
        /// </summary>
        /// <param name="myPersonId">The unique Id for this person.</param>
        /// <param name="myFirstName">The first name of this person.</param>
        /// <param name="myLastName">The last or family name of this person.</param>
        public Person(int myPersonId = 0, string myFirstName = "John", string myLastName = "Doe")
        {
            _personId = myPersonId;

            // Roll back to standard "empty names" if  really enpty or unassigned
            if (myFirstName == null)
            {
                _firstName = "John";
            }
            else
            {
                _firstName = (myFirstName.Length == 0) ? "John" : myFirstName;

            }
            if (myLastName == null)
            {
                _lastName = "Doe";
            }
            else
            {
                _lastName = (myLastName.Length == 0) ? "Doe" : myLastName;

            }
        }

        /// <summary>
        /// Returns the full name of the person.
        /// </summary>
        public string Name
        {
            get
            {
                return _firstName + " " + _lastName;
            }
        }

        /// <summary>
        /// Returns the personal Id from this person.
        /// </summary>
        public int PersonId
        {
            get
            {
                return _personId;
            }
        }

    }
}
