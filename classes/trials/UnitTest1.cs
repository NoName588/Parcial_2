using classes;
using System.Numerics;
using System;
using static classes.ArmorandWeapon;

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

                character myCharacter = new character("John", 20, 5, 2, 3, 4, 100, 200, true, true, 5, 10);


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
            [Test]
            public void Attack_EnemyWithNoArmor_TakesFullDamage()
            {

                character attacker = new character("Attacker", 20, 10, 5, 8, 0, 20, 0, true, true, 20, 0);
                character defender = new character("Defender", 20, 0, 0, 0, 0, 0, 0, false, false, 0, 0);


                attacker.Attack(defender);


                Assert.AreEqual(10, defender.life);
            }
            [Test]
            public void TestAttackWithEquippedWeaponAndOpponentHasArmor()
            {
               
                var characterWithWeapon = new character("Jhon", 20, 10, 5, 20, 5, 10, 10, true, true, 10, 10);
                var enemy = new character("Enemy", 20, 10, 5, 0, 10, 10, 10, true, true, 10, 10);


                characterWithWeapon.Attack(enemy);


                Assert.AreEqual(15, enemy.life);
            }
            [Test]
            public void AttackTest()
            {
                
                var character1 = new character("Gandalf", 20, 7, 3, 9, 5, 10, 5, true, true, 10, 10);
                var character2 = new character("Sauron", 30, 5, 2, 7, 4, 10, 10, true, true, 10, 10);

                
                character1.Attack(character2);

                
                Assert.AreEqual(26, character2.life);
                Assert.AreEqual(9, character1.DurabilityWeapon);
            }
            [Test]
            public void WeaponBreaksWhenDurabilityReachesZero()
            {
                
                var character1 = new character("Obi One", 20, 7, 3, 9, 5, 10, 1, true, true, 1, 10);
                var character2 = new character("Anakin", 30, 5, 2, 7, 4, 10, 10, true, true, 10, 10);

                
                character1.Attack(character2);
                character1.Attack(character2);

                
                Assert.AreEqual(21, character2.life);
                Assert.IsFalse(character1.equipweapon);
            }
            [Test]
            public void ArmorDurabilityZero_UnequipsArmor()
            {
                
                var character = new character("Eggman", 20, 7, 3, 9, 5, 10, 5, true, true, 10, 0);
                var enemy = new character("Sanic", 30, 5, 2, 7, 4, 10, 0, true, true, 10, 10);

                
                character.Attack(enemy);

                
                Assert.IsFalse(character.equiparmor);
            }
            [Test]
            public void ArmorDurabilityNotNegative_AfterTakingDamage()
            {
                
                var character = new character("Gandalf", 20, 7, 3, 9, 5, 10, 5, true, true, 10, 5);
                var enemy = new character("Sauron", 30, 5, 2, 7, 4, 10, 10, true, true, 10, 10);

                
                character.Attack(enemy);

               
                Assert.GreaterOrEqual(character.dur_armor, 0);
            }

            [Test]
            public void DurabilityWeaponTest()
            {
                var character = new character("Sam", 100, 10, 5, 10, 20, 1, 20, true, false, 0, 0);
                var Enemy = new character("Gandalf", 20, 7, 3, 9, 5, 10, 10, false, false, 0, 0);

                character.Attack(Enemy);

                Assert.IsFalse(character.wEquiped);

            }

            [Test]
            public void CannotEquipBrokenEquipment()
            {
                var character = new character("Gandalf", 20, 7, 3, 9, 5, 10, 10, false, false, 0, 0);
                Weapon weapon = new Weapon(10, 5, true);
                var armor = new Armor("Armadura rota", 0);

                Assert.Throws<ArgumentException>(() => character.EquipWeapon(weapon));
                Assert.Throws<ArgumentException>(() => character.EquipArmor(armor));
            }
            


        }

    }
    
}