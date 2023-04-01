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
            [Test]
            public void TestNoZeroAttributes()
            {
                // Arrange
                ArmorandWeapon myEquipment = new ArmorandWeapon(5, 10, PieceClass.Weapon, 2, 20, PieceClass.Armor, true, true);

                // Act
                bool noZeroAttributes = myEquipment.Power != 0 && myEquipment.Durability != 0;

                // Assert
                Assert.IsTrue(noZeroAttributes);
            }
            [Test]
            public void TestMinimumLife()
            {
                // Arrange
                int expectedLife = 1;

                // Act
                character myCharacter = new character("John", 0, 5, 2, 3, 4, 100, 200, true, true);

                // Assert
                Assert.AreEqual(expectedLife, myCharacter.life);
            }
            [Test]
            public void ArmorandWeapon_DurabilityCannotBeLessThanOne()
            {
                // Arrange & Act
                var weapon = new ArmorandWeapon(10, 0, PieceClass.Weapon);
                var armor = new ArmorandWeapon(0, 0, PieceClass.Armor);

                // Assert
                Assert.That(weapon.Durability, Is.EqualTo(1));
                Assert.That(armor.Durability, Is.EqualTo(1));
            }
        }
    }
}