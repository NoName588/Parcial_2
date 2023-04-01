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
            [Test]
            public void ArmorandWeapon_DurabilityCannotBeLessThanOne()
            {
                // Arrange
                var warrior = new Character(PieceClass.Armor);
                var mage = new Character(PieceClass.Weapon);

                // Act
                var sword = new ArmorandWeapon(10, 0, PieceClass.Weapon, 0, 0, PieceClass.Armor, true, false);
                var shield = new ArmorandWeapon(0, 0, PieceClass.Armor, 0, 0, PieceClass.Weapon, false, true);
                var staff = new ArmorandWeapon(10, 0, PieceClass.Weapon, 0, 0, PieceClass.Any, true, false);
                var plateArmor = new ArmorandWeapon(0, 0, PieceClass.Armor, 0, 0, PieceClass.Any, false, true);

                // Assert
                Assert.That(sword.Durability, Is.EqualTo(1));
                Assert.That(shield.Durability, Is.EqualTo(1));
                Assert.That(staff.Durability, Is.EqualTo(1));
                Assert.That(plateArmor.Durability, Is.EqualTo(1));

                Assert.That(sword.Class, Is.EqualTo(PieceClass.Weapon));
                Assert.That(shield.Class, Is.EqualTo(PieceClass.Armor));
                Assert.That(staff.Class, Is.EqualTo(PieceClass.Any));
                Assert.That(plateArmor.Class, Is.EqualTo(PieceClass.Any));

                Assert.That(warrior.CanEquip(sword), Is.True);
                Assert.That(warrior.CanEquip(shield), Is.True);
                Assert.That(warrior.CanEquip(staff), Is.True);
                Assert.That(warrior.CanEquip(plateArmor), Is.True);

                Assert.That(mage.CanEquip(sword), Is.False);
                Assert.That(mage.CanEquip(shield), Is.False);
                Assert.That(mage.CanEquip(staff), Is.True);
                Assert.That(mage.CanEquip(plateArmor), Is.True);
            }
        }
    }
}