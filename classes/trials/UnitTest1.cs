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
                
                character myCharacter = new character("John", 20, 5, 2, 3, 4, 100, 200, true, true, 5 , 10);

                
                bool noNegativeAttributes = myCharacter.life >= 0 && myCharacter.BaseAtk >= 0 && myCharacter.BaseDef >= 0;

                
                Assert.IsTrue(noNegativeAttributes);
            }
            [Test]
            public void TestNoZeroAttributes()
            {
                
                ArmorandWeapon myEquipment = new ArmorandWeapon(5, 10, PieceClass.Weapon, 2, 20, PieceClass.Armor, true, true);

                
                bool noZeroAttributes = myEquipment.Power != 0 && myEquipment.Durability != 0;

                
                Assert.IsTrue(noZeroAttributes);
            }
            [Test]
            public void TestMinimumLife()
            {
                
                int expectedLife = 1;

               
                character myCharacter = new character("John", 0, 5, 2, 3, 4, 100, 200, true, true, 5, 10);

                
                Assert.AreEqual(expectedLife, myCharacter.life);
            }
            [Test]
            public void ArmorandWeapon_DurabilityCannotBeLessThanOne()
            {
                
                var weapon = new ArmorandWeapon(10, 0, PieceClass.Weapon);
                var armor = new ArmorandWeapon(0, 0, PieceClass.Armor);

                
                Assert.That(weapon.Durability, Is.EqualTo(1));
                Assert.That(armor.Durability, Is.EqualTo(1));
            }
            [Test]
            public void TestMatchingClass()
            {
                
                character myCharacter = new character("John", 20, 5, 2, 3, 4, 100, 200, true, true, 5, 10);
                ArmorandWeapon myEquipment = new ArmorandWeapon(5, 10, PieceClass.Weapon, 2, 20, PieceClass.Armor, CharacterClass.Human, true, true);

                
                bool matchingClass = (myEquipment.Class == PieceClass.Any || myCharacter.Class == CharacterClass.Human) && myEquipment.Class == PieceClass.Armor;

                
                Assert.IsTrue(matchingClass);
            }
            [Test]
            public void AttackAndDefend_ShouldReduceDurability()
            {
                
                int initialDurabilityWeapon = 5;
                int initialDurabilityArmor = 7;
                character player1 = new character("Player 1", 20, 5, 2, 10, 5, initialDurabilityWeapon, initialDurabilityArmor, true, true, initialDurabilityWeapon, initialDurabilityArmor);
                character player2 = new character("Player 2", 20, 5, 2, 10, 5, initialDurabilityWeapon, initialDurabilityArmor, true, true, initialDurabilityWeapon, initialDurabilityArmor);
                int expectedDurabilityWeapon = initialDurabilityWeapon - 1;
                int expectedDurabilityArmor = initialDurabilityArmor - 1;

                
                player1.Attack(player2);
                player2.Defend();

                
                Assert.AreEqual(expectedDurabilityWeapon, player1.DurabilityWeapon);
                Assert.AreEqual(expectedDurabilityArmor, player2.DurabilityArmor);
            }
        }
    }
}