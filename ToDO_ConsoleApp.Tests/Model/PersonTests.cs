using ToDo_ConsoleApp.Data;
using ToDo_ConsoleApp.Model;
using Xunit;


namespace ToDo_ConsoleApp.Tests.Model
{
    public class PersonTests
    {



        [Fact]
        public void Person_CreateValidPerson_NamesOk()
        {
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = "Larsson";
            string myNameResult = "Bosse Larsson";
            PersonSequencer.Reset();
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }



        [Fact]
        public void Person_CreateEmptyPersonName_GetEmptyStandardName()
        {
            int myPersonID = 0;
            string myFirstName = "";
            string myLastName = "Larsson";
            string myNameResult = "John Larsson";

            PersonSequencer.Reset();
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void Person_CreateNullLastName_GetEmptyStandardName()
        {
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = null;
            string myNameResult = "Bosse Doe";

            PersonSequencer.Reset();
            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myNameResult, myPerson.Name);
        }

        [Fact]
        public void Person_CreateID_IdOk()
        {
            int myPersonID = 0;
            string myFirstName = "Bosse";
            string myLastName = "Larsson";
            int myIdResult = 0;


            Person myPerson = new Person(myPersonID, myFirstName, myLastName);

            // Assert
            Assert.Equal(myIdResult, myPerson.PersonId);
        }

    }
}
