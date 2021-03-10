using ToDo_ConsoleApp.Data;
using Xunit;

namespace ToDo_ConsoleApp.Tests.Data
{
    public class PersonSequencerTest
    {


        [Fact]
        public void NextPersonId_StepupId_Increase()
        {
            //Arrange
            int expectedId = 1;
            PersonSequencer.Reset();

            //Act
            int getId = PersonSequencer.getNext();

            // Assert
            Assert.Equal(expectedId, getId);
        }

        [Fact]
        public void NextPessonId_StepupId3_Increase3()
        {
            //Arrange
            int expectedId = 3;
            PersonSequencer.Reset();
            //Act
            int getId = PersonSequencer.getNext();
            getId = PersonSequencer.getNext();
            getId = PersonSequencer.getNext();
            // Assert
            Assert.Equal(expectedId, getId);
        }

        [Fact]
        public void NextPessonId_Stepup3ResetId_GetOne()
        {
            //Arrange
            int expectedId = 1;
            PersonSequencer.Reset();
            //Act
            int getId = PersonSequencer.getNext();
            getId = PersonSequencer.getNext();
            getId = PersonSequencer.getNext();
            PersonSequencer.Reset();
            getId = PersonSequencer.getNext();
            // Assert
            Assert.Equal(expectedId, getId);

        }

    }
}
