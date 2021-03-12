using ToDo_ConsoleApp.Data;
using ToDo_ConsoleApp.Model;
using Xunit;

namespace ToDo_ConsoleApp.Tests.Data
{
    public class ToDoItemsTests
    {


        [Fact]
        public void Clear_clearList_zero()
        {
            //arrange
            int expectedSizeOfToDoItems = 0;
            string description = "Wash the car.";

            ToDoItems todoItems = new ToDoItems();
            ToDo returnedTodo = todoItems.AddToDoItem(null, description);
            Assert.Equal(1, todoItems.Size());

            //act
            todoItems.Clear();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());

        }

        [Fact]
        public void AddTodoItem_WithAssignee_sizeCorrect_descriptionCorrect()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Anna";
            string familyName = "Jansson";
            Person assignee = new Person(personId, firstName, familyName);

            int expectedSizeOfToDoItems = 1;
            string description = "Wash the car.";
            ToDoItems todoItems = new ToDoItems();

            //act
            ToDo returnedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, returnedTodo.Description);
        }


        [Fact]
        public void AddTodoItem_WithoutDescription_DescriptionEmpty()
        {
            //arrange
            Person assignee = null;

            int expectedSizeOfToDoItems = 1;
            string expectedDescription = "";
            string description = null;
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //act
            ToDo addedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(expectedDescription, addedTodo.Description);
        }


        [Fact]
        public void AddTodoItem_WithoutAssignee_SizeDescription()
        {
            //arrange
            Person assignee = null;

            int expectedSizeOfToDoItems = 1;
            string description = "Shop for groceries.";
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //act
            ToDo returnedTodo = todoItems.AddToDoItem(assignee, description);

            //assert
            Assert.Equal(expectedSizeOfToDoItems, todoItems.Size());
            Assert.Equal(description, returnedTodo.Description);
        }

        [Fact]
        public void FindAllItems_FindsAll_ArraySizeOK()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Peter";
            string familyName = "Jansson";
            Person assignee = new Person(personId, firstName, familyName);

            int expectedSizeOfToDoItems = 3;
            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            ToDo[] itemArray = todoItems.FindAll();

            //assert
            Assert.Equal(expectedSizeOfToDoItems, itemArray.Length);
        }


        [Fact]
        public void FindItemById_FindOne_CorrectDescription()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            int size = todoItems.Size();

            //act
            ToDo foundLastItem = todoItems.FindById(size);
            ToDo foundFirstItem = todoItems.FindById(1);

            //assert
            Assert.Equal(description2, foundLastItem.Description);
            Assert.Equal(description1, foundFirstItem.Description);
        }

        [Fact]
        public void FindAllItems_ClearedItems_EmptyArray()
        {
            //arrange
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //act
            ToDo[] itemArray = todoItems.FindAll();

            //assert
            Assert.Empty(itemArray);
        }

        [Fact]
        public void FindItemById_Return1_Description()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            int size = todoItems.Size();

            //act
            ToDo foundItem = todoItems.FindById(size);

            //assert
            Assert.Equal(description2, foundItem.Description);
        }

        [Fact]
        public void FindItemById_UnknownId_NoneReturned()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            int size = todoItems.Size();

            //act
            ToDo foundItem = todoItems.FindById(size + 3);

            //assert
            Assert.Null(foundItem);
        }

        [Fact]
        public void FindByDoneStatus_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 2 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);

            //set one item to done.
            ToDo itemToBeDone = todoItems.FindById(1);
            itemToBeDone.Done = true;

            //act
            ToDo[] foundItemsArray = todoItems.FindByDoneStatus(true);

            //assert
            Assert.Single(foundItemsArray);
            Assert.Equal(description1, foundItemsArray[0].Description);
        }

        [Fact]
        public void FindByDoneStatus_FindOnlyNotDone_Arraysize2()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);
            int expectedNumberofAssigns = 2;

            string description1 = "Walk the dog";
            string description2 = "Cuddle with cat";
            string description3 = "Take a walk";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(assignee, description3);

            //set one item to done.
            ToDo itemToBeDone = todoItems.FindById(1);
            itemToBeDone.Done = true;

            //act
            ToDo[] foundItemsArray = todoItems.FindByDoneStatus(false);

            //assert
            Assert.Equal(expectedNumberofAssigns, foundItemsArray.Length);

        }


        [Fact]
        public void FindByDoneStatus_FindOnlyNotDone_Arraysize3()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 not done
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(assignee, description3);

            //set one of the items to done.
            ToDo itemToBeDone = todoItems.FindById(1);
            itemToBeDone.Done = true;

            //act
            ToDo[] foundItemsArray = todoItems.FindByDoneStatus(false);

            //assert
            Assert.Equal(2, foundItemsArray.Length);
        }

        [Fact]
        public void FindByAssigneeInt_FindTwo_Arraysize2()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            ToDo[] foundItemsArray = todoItems.FindByAssignee(personId);

            //assert
            Assert.Equal(2, foundItemsArray.Length);
        }

        [Fact]
        public void FindByAssigneeInt_NotFound_Arraysize0()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            ToDo[] foundItemsArray = todoItems.FindByAssignee(personId + 10);

            //assert
            Assert.Empty(foundItemsArray);
        }

        [Fact]
        public void FindByAssigneePerson_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            personId = PersonSequencer.getNext();
            Person assignee2 = new Person(personId, "Clara", familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            ToDo[] foundItemsArray = todoItems.FindByAssignee(assignee);

            //assert
            Assert.Single(foundItemsArray);
        }

        [Fact]
        public void FindByAssigneePerson_NullPerson_ReturnsUnassignedItems()
        {
            //findbyAssignee(null) will return the unassigned items

            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee1 = new Person(personId, firstName, familyName);

            personId = PersonSequencer.getNext();
            Person assignee2 = new Person(personId, "Clara", familyName);

            Person assignee3 = null;

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            //TodoSequencer.reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee1, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(assignee3, description3);

            //act
            ToDo[] foundItemsArray = todoItems.FindByAssignee(assignee3);

            //assert
            Assert.Single(foundItemsArray);
        }

        [Fact]
        public void FindUnassigned_FindOnlyOne_Arraysize1()
        {
            //arrange
            int personId = PersonSequencer.getNext();
            string firstName = "Fredrik";
            string familyName = "Persson";
            Person assignee = new Person(personId, firstName, familyName);

            personId = PersonSequencer.getNext();
            Person assignee2 = new Person(personId, "Clara", familyName);

            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            todoItems.AddToDoItem(assignee, description1);
            todoItems.AddToDoItem(assignee2, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            ToDo[] foundItemsArray = todoItems.FindUnassignedTodoItems();

            //assert
            Assert.Single(foundItemsArray);
            Assert.Equal(description3, foundItemsArray[0].Description);
        }



        [Fact]
        public void Remove_RemoveOneInMiddle_RemoveOnlyOne()
        {
            //arrange

            ToDo myToDo = null;
            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";
            string description4 = "Do the home work.";
            int expectedNumberOfItems = 3;

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 4 items
            int myInitialNumber = todoItems.Size();
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            myToDo = todoItems.AddToDoItem(null, description3);
            todoItems.AddToDoItem(null, description4);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(expectedNumberOfItems, myAdjustedNumber);
        }

        [Fact]
        public void Remove_RemoveLast_RemoveOnlyOne()
        {
            //arrange
            ToDo myToDo = null;
            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";
            string description4 = "Do the home work.";
            int expectedNumberOfItems = 3;

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 4 items
            int myInitialNumber = todoItems.Size();
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);
            myToDo = todoItems.AddToDoItem(null, description4);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(description4, myToDo.Description);
            Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(expectedNumberOfItems, myAdjustedNumber);
        }

        [Fact]
        public void Remove_RemoveFirst_RemoveOnlyOne()
        {
            //arrange
            ToDo myToDo = null;
            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";
            int expectedNumberOfItems = 2;

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 3 items
            int myInitialNumber = todoItems.Size();
            myToDo = todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(description1, myToDo.Description);
            Assert.NotEqual(myInitialNumber, myAdjustedNumber);
            Assert.Equal(expectedNumberOfItems, myAdjustedNumber);
        }

        [Fact]
        public void Remove_RemoveOneNotIncluded_RemoveNothing()
        {
            //arrange
            ToDo myToDo = null;
            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";
            string description4 = "Do the home work.";
            int expectedNumberOfItems = 4;

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 4 items
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);
            todoItems.AddToDoItem(null, description4);

            myToDo = new ToDo(0, "Not added todo");

            //act
            todoItems.Remove(myToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(myAdjustedNumber, expectedNumberOfItems);
        }

        [Fact]
        public void Remove_RemoveNull_NothingRemovedNoCrash()
        {
            //arrange
            ToDo myNullToDo = null;
            string description1 = "Walk the dog.";
            string description2 = "Cuddle with cat.";
            string description3 = "Take a walk.";
            string description4 = "Do the home work.";
            int expectedNumberOfItems = 4;

            ToDoSequencer.Reset();
            ToDoItems todoItems = new ToDoItems();
            todoItems.Clear();

            //add 4 items
            todoItems.AddToDoItem(null, description1);
            todoItems.AddToDoItem(null, description2);
            todoItems.AddToDoItem(null, description3);
            todoItems.AddToDoItem(null, description4);

            //act
            todoItems.Remove(myNullToDo);
            int myAdjustedNumber = todoItems.Size();

            //assert
            Assert.Equal(myAdjustedNumber, expectedNumberOfItems);
        }

    }
}
