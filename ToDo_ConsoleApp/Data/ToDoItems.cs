using System;
using System.Collections.Generic;
using ToDo_ConsoleApp.Model;

namespace ToDo_ConsoleApp.Data
{
    public class ToDoItems
    {

        private static ToDo[] myItems;

        /// <summary>
        /// Constructor for ToDoItems that instance a empty Array of ToDo.
        /// </summary>
        public ToDoItems()
        {
            myItems = new ToDo[0];
        }

        /// <summary>
        /// Size returns the size of the Array collection.
        /// </summary>
        /// <returns>int size</returns>
        public int Size()
        {
            return myItems.Length;
        }

        /// <summary>
        /// returns all items
        /// </summary>
        /// <returns>ToDo[]</returns>
        public ToDo[] FindAll()
        {
            return myItems;
        }

        /// <summary>
        /// Method creates a new ToDo item, assignes it to the Assignee if any.
        /// The new ToDo item is then inserted into the items list and finally returned.
        /// </summary>
        /// <param name="assignee"></param>
        /// <param name="description"></param>
        /// <returns>Returns the object of the created ToDo item</returns>
        public ToDo AddToDoItem(Person assignee = null, string description = "Nothing")
        {
            int nextItemId = ToDoSequencer.NextId();

            ToDo newTodo = new ToDo(nextItemId, description);
            newTodo.Assignee = assignee;

            //extend array by one.
            int arrayLength = this.Size();
            Array.Resize(ref myItems, arrayLength + 1);
            myItems[arrayLength] = newTodo;

            return newTodo;
        }

        /// <summary>
        /// The method returns the ToDo item with the requested Id
        /// </summary>
        /// <param name="todoId">The unique ToDo identification number.</param>
        /// <returns>Returns the ToDo item if found. Otherwise returns null.</returns>
        public ToDo FindById(int todoId)
        {
            int returnIndex = -1;

            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].TodoId == todoId)
                {
                    returnIndex = i;
                }
            }

            if (returnIndex != -1)
            {
                return myItems[returnIndex];
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// The method creates a new empty list of ToDo items and
        /// discards the old Array. Reset is also done on the sequenser.
        /// </summary>
        public void Clear()
        {
            myItems = new ToDo[0];
            ToDoSequencer.Reset();
        }

        public ToDo[] FindByDoneStatus(bool doneStatus)
        {

            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Done == doneStatus)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }


        /// <summary>
        /// Finds all ToDo items by the assigned person based on the personal Id.
        /// </summary>
        /// <param name="personId">The unique Id of a person in the array collection.</param>
        /// <returns>Returns all ToDo items assigned to the specified person in an Array.
        /// If person do not have assignment the return array is empty.</returns>
        public ToDo[] FindByAssignee(int personId)
        {
            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Assignee != null &&
                    myItems[i].Assignee.PersonId == personId)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Finds all ToDo items by the assigned person based on the personal object.
        /// </summary>
        /// <param name="assignee">The person input is an object of Person contained in the collection.</param>
        /// <returns>Returns all ToDo items assigned to the specified person in an Array.
        /// If person do not have assignment the return array is empty.</returns>
        public ToDo[] FindByAssignee(Person assignee)
        {
            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Assignee == assignee)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Looks upp all the ToDo items that are not assigned.
        /// </summary>
        /// <returns>Returns an Array of unassigned ToDos. If no unassigned
        /// ToDos is found the returned Array is empty.</returns>
        public ToDo[] FindUnassignedTodoItems()
        {
            ToDo[] returnArray = new ToDo[0];
            List<ToDo> returnList = new List<ToDo>();


            for (int i = 0; i < myItems.Length; i++)
            {
                if (myItems[i].Assignee == null)
                {
                    int arrayLength = returnArray.Length;
                    Array.Resize(ref returnArray, arrayLength + 1);

                    returnArray[arrayLength] = myItems[i];
                }
            }
            return returnArray;
        }

        /// <summary>
        /// Remove takes one specified object of ToDo out of the Array
        /// collection and resizes the remainding Array acordingly.
        /// </summary>
        /// <param name="myToDo">The ToDo object to remove from Array
        /// Collection. If not found notheing will happen.</param>
        public void Remove(ToDo myToDo)
        {
            int myToDoCollection = myItems.Length;
            int myIndexedToDo = -1;
            bool notDoneYet = true;

            int myLoop = 0;

            if (myToDo != null)
            {

                while (notDoneYet)
                {

                    if (myItems[myLoop].TodoId == myToDo.TodoId)
                    {
                        myIndexedToDo = myLoop;
                        notDoneYet = false;
                    }
                    myLoop++;

                    if (myLoop == myToDoCollection)
                    {
                        notDoneYet = false;
                    }
                }

                if (myIndexedToDo != -1)
                {
                    for (int removeLoop = myIndexedToDo; removeLoop < myToDoCollection - 1; removeLoop++)
                    {
                        myItems[removeLoop] = myItems[removeLoop + 1];
                    }

                    Array.Resize(ref myItems, myToDoCollection - 1);
                }
            }

        }

    }

}
