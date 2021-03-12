using ToDo_ConsoleApp.Model;
using Xunit;

namespace ToDo_ConsoleApp.Tests.Model
{
    public class ToDoTests
    {

        [Fact]
        public void ToDo_constructor_checkAllFields()
        {
            //arrange
            string description = "Bake cookies";
            int id = 1;

            //act
            ToDo todo1 = new ToDo(id, description);

            //assert
            Assert.Equal(description, todo1.Description);
            Assert.False(todo1.Done);
            Assert.Equal(id, todo1.TodoId);
            Assert.Null(todo1.Assignee);
        }

        [Fact]
        public void Todo_ChangeDescript_GetDescript()
        {
            //Arrange
            string originalDescription = "Run home";
            string setStringDescription = "Go walk";
            string constructedDescription;
            string changedDescription;

            //Act

            ToDo myToDo = new ToDo(1, originalDescription);
            constructedDescription = myToDo.Description;
            //change description
            myToDo.Description = setStringDescription;
            changedDescription = myToDo.Description;

            //Assert
            Assert.Equal(originalDescription, constructedDescription);
            Assert.Equal(setStringDescription, changedDescription);
        }

        [Fact]
        public void Todo_ChangeDescriptToNull_GetDescript()
        {
            //Arrange
            string originalDescription = "Run home";
            string setStringDescription = null;
            string constructedDescription;
            string changedDescription;
            string expectedChangedDescription = "Run home";

            //Act
            ToDo myToDo = new ToDo(1, originalDescription);
            constructedDescription = myToDo.Description;
            //change description
            myToDo.Description = setStringDescription;
            changedDescription = myToDo.Description;

            //Assert
            Assert.Equal(originalDescription, constructedDescription);
            Assert.Equal(expectedChangedDescription, changedDescription);
        }

        [Fact]
        public void ToDo_ConstructNoAssignee_GetAssigneeNull()
        {
            //arrange
            string description = "Get to work.";
            int id = 1;
            Person expectedPerson = null;

            //act
            ToDo todo1 = new ToDo(id, description);
            Person myAssignedPerson = todo1.Assignee;

            //assert
            Assert.Equal(expectedPerson, myAssignedPerson);

        }

        [Fact]
        public void ToDo_CreateEmpty_CreatedAndIdZero()
        {
            //Arrange
            ToDo myToDo = new ToDo();

            //Act
            int myToDoId = myToDo.TodoId;
            bool ExpectedFalse = myToDoId > 0 ? true : false;

            //Assert
            Assert.NotNull(myToDo);
            Assert.False(ExpectedFalse);
        }


        [Fact]
        public void ToDo_CreateIdOne_GetIdOne()
        {
            //Arrange
            ToDo myToDo = new ToDo(1, "Hello");
            int expectedOneId = myToDo.TodoId;

            //Act
            bool expectedTrue = expectedOneId == 1 ? true : false;

            //Assert
            Assert.True(expectedTrue);

        }

        [Fact]
        public void ToDo_CreateSetDescipt_GetDescript()
        {
            //Arrange
            string setStringDesciption = "Go walk";
            ToDo myToDo = null;
            string expectedDesciption;

            //Act
            myToDo = new ToDo(1, setStringDesciption);
            expectedDesciption = myToDo.Description;

            //Assert
            Assert.Equal(setStringDesciption, expectedDesciption);

        }

        [Fact]
        public void ToDo_CreateSetAssignee_GetAssignee()
        {
            //Arrange
            string setStringDesciption = "Go walk";
            ToDo myToDo = null;
            Person myPerson = null;

            //Act
            myPerson = new Person(1, "Charlie", "Brown");
            myToDo = new ToDo(1, setStringDesciption);
            myToDo.Assignee = myPerson;


            //Assert
            Assert.NotNull(myToDo.Assignee);

        }

        [Fact]
        public void ToDo_CreateSetDone_GetDoneOk()
        {
            //Arrange
            string setStringDesciption = "Go walk";
            ToDo myToDo = null;

            //Act
            myToDo = new ToDo(1, setStringDesciption);
            myToDo.Done = true;


            //Assert
            Assert.True(myToDo.Done);

        }
    }
}
