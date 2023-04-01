using classes;

namespace trials
{
    namespace trials
    {
        public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void TestNoNegativeAttributes()
            {
                // Arrange
                character myCharacter = new character("John", 20, 5, 2, 3, 4, 100, 200, true, true);

                // Act
                bool noNegativeAttributes = myCharacter.life >= 0 && myCharacter.BaseAtk >= 0 && myCharacter.BaseDef >= 0;

                // Assert
                Assert.IsTrue(noNegativeAttributes);
            }
        }
    }
}