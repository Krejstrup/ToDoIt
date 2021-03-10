using System;
using ToDo_ConsoleApp.Model;

namespace ToDo_ConsoleApp.Data
{
    public class People
    {
        private static Person[] _myPeople;

        /// <summary>
        /// The constructor of the people collection allocates a new array of no persons inside.
        /// </summary>
        public People()
        {
            _myPeople = new Person[0];
        }

        /// <summary>
        /// Size gives you the number of persons in the collecction.
        /// </summary>
        /// <returns>Returns an int representing the number of persons in the collection.</returns>
        public int Size()
        {
            return _myPeople.Length;
        }

        /// <summary>
        /// FindAll will give you the array of the collection of peoples.
        /// </summary>
        /// <returns>Returns the stored Array of persons.</returns>
        public Person[] FindAll()
        {
            return _myPeople;
        }


        /// <summary>
        /// FindById finds your person in the array based on its personId.
        /// </summary>
        /// <param name="personId">The unique id of a person in the Array collection of people.</param>
        /// <returns>Returns the found person. If Id is not in collection return value is null.</returns>
        public Person FindById(int personId)
        {
            int myIndex = 0;
            bool notFound = false;
            bool justLooking = true;
            int myCollectionNumber = _myPeople.Length;

            if (myCollectionNumber == 0) return null;

            while (!notFound && justLooking)
            {
                if (_myPeople[myIndex].PersonId == personId)
                {
                    justLooking = false;
                }
                else if (myIndex + 1 == myCollectionNumber)
                {
                    notFound = true;
                }
                myIndex++;
            }

            if (notFound)
            {
                return null;
            }
            else
            {
                return _myPeople[myIndex - 1];

            }

        }




        /// <summary>
        /// AddPerson creates a new person and inserts it into the existing array of
        /// persons in the people collection.
        /// </summary>
        /// <param name="firstName">The actual first name of person.</param>
        /// <param name="lastName">The actual last name of person.</param>
        /// <returns>Returns the object of the created person.</returns>
        public Person AddPerson(string firstName, string lastName)
        {
            int indexedPersonId = PersonSequencer.getNext(); // nextPersonId();
            Person newPerson = new Person(indexedPersonId, firstName, lastName);

            // Now extend the Array by one so insert is possible
            int lengthOfField = _myPeople.Length;
            Array.Resize(ref _myPeople, lengthOfField + 1);
            _myPeople[lengthOfField] = newPerson;

            return newPerson;
        }

        /// <summary>
        /// Clear method discards the old collection of people and creates a new empty one.
        /// Note that the Id handler will also reset!
        /// </summary>
        public void Clear()
        {
            _myPeople = new Person[0];
            PersonSequencer.Reset();
        }

        /// <summary>
        /// Remove erases a person in the Array collection. The array is adjusted in length.
        /// </summary>
        /// <param name="myPerson">The person to erase in the collection.</param>
        public void Remove(Person myPerson)
        {
            int myPeopleCollection = _myPeople.Length;
            int myIndexedPerson = -1;
            bool notDone = true;
            int myLoop = 0;

            do
            {
                if (_myPeople[myLoop].PersonId == myPerson.PersonId)
                {
                    notDone = false;
                    myIndexedPerson = myLoop;
                }
                myLoop++;
                if (myLoop == myPeopleCollection) notDone = false;

            } while (notDone);


            if (myIndexedPerson > -1)
            {

                for (int removeLoop = myIndexedPerson; removeLoop < myPeopleCollection - 1; removeLoop++)
                {
                    _myPeople[removeLoop] = _myPeople[removeLoop + 1];
                }
                Array.Resize(ref _myPeople, myPeopleCollection - 1);
            }

        }

    }
}
