
using ToDo_ConsoleApp.Data;
using Xunit;

namespace ToDo_ConsoleApp.Tests.Data
{
    public class ToDoSequencerTests
    {



        [Fact]
        public void NextTodoId_getNextTodoId_id()
        {
            //arrange
            ToDoSequencer.Reset();
            int expectedNextId = 1;

            //act
            int fetchedNextId = ToDoSequencer.NextId();

            //assert
            Assert.Equal(expectedNextId, fetchedNextId);
        }

        [Fact]
        public void Reset_ResetIdGetNewIdsReset_RightToDoIdFromNewGet()
        {
            //arrange
            ToDoSequencer.Reset();
            int expectedResetId = 1;

            //act
            // consume 2 id's to make a first grip of the static member
            int nextId = ToDoSequencer.NextId();
            nextId = ToDoSequencer.NextId();

            ToDoSequencer.Reset();
            int newId = ToDoSequencer.NextId();

            //assert
            Assert.NotEqual(nextId, newId);
            Assert.Equal(expectedResetId, newId);
        }

    }
}
