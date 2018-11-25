using System;
using System.Collections.Generic;
using System.Text;
using FirstFantazy_Hero_Weapon;
using FirstFantazy_StoryText;
using FirstFantazy_Battle;
using FirstFantazy_Hero;

namespace FirstFantazy.Story
{
    class BattleText: StoryText
    {
        private const int i = 4;

        public static void BattleStart()
        {
            Console.Clear();

            Console.WriteLine("Bitwa!!!");
            Console.WriteLine();
            Console.WriteLine("Jesteś zmuszony stawić czoło przeciwnikom.");

            SelectWayDisplayDelay(i);
        }

        public static void BattleStats(Weapon weapon, Hero enemy)
        {
            Console.Clear();

            Console.WriteLine($"Broń zadaje [{weapon.Damage}] obrażeń.");
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"Stan :");
            HeroColorText(enemy);
            Console.WriteLine($"Życie: {enemy.Life}");
            Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
            Console.WriteLine("");
            Console.WriteLine();

            SelectWayDisplayDelay(i);

        }

        public static void PresentationOfAttacker(Hero hero)
        {
            Weapon weapon = hero.Inventory[0] as Weapon;

            Console.Clear();

            Console.WriteLine("Atak !");
            Console.WriteLine();
            Console.Write($"Kolej: ");
            HeroColorText(hero);
            Console.WriteLine($"Używa broni [{weapon.WeponName}]");
            Console.WriteLine($"O wytrzymałości [{ weapon.Hardness}]");
            Console.WriteLine($"Zadającej obrażenia na poziomie [{weapon.Damage}].");
            
            Console.WriteLine();

            SelectWayDisplayDelay(i);

        }

        public static void PresentationEnemies(List<Hero> enemies)
        {
            int enemyNumber = 1;

            Console.Clear();

            foreach (Hero enemy in enemies)
            {
                Console.WriteLine("Atakuj przeciwnika !");
                Console.WriteLine();
                Console.WriteLine(enemy.Name + "- żeby zaatakować wybranego przeciwnika podaj przypisaną mu cyfrę " + "[" + enemyNumber + "]");
                Console.WriteLine();
                Console.Write($"Stan wroga: ");
                HeroColorText(enemy);
                Console.WriteLine($"Życie: {enemy.Life}");
                Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
                Console.WriteLine("");
                Console.WriteLine();
                enemyNumber++;
                Console.WriteLine();
            }
        }

        public static void SelectEnemyNumber()
        {
            Console.Write("Podaj numer przeciwnia: ");
        }

        public static void SelectValueHandlingExceptionsText()
        {
            Console.WriteLine();
            Console.Write("Błedny format danych, wporwadź cyfrę!  ");
        }

        public static void BattleDurabilityDown(Hero hero)
        {
            Console.Clear();

            Console.Write("Wytrzynmałość bohatera");
            HeroColorText(hero);
            Console.WriteLine("W wyniku trudu jaki włożył w walkę spadła");
            Console.WriteLine($"i wynosi teraz {hero.Durability}, będzie odzyskiwał ją odpoczywając.");
            Console.WriteLine();

            SelectWayDisplayDelay(i);
        }

        public static void DurabilityDownZero(Hero hero)
        {
            Console.Clear();

            Console.Write("Bohater ");
            HeroColorText(hero);
            Console.WriteLine("Stacił wytrzymałość, brkuje mu sił, żeby atakować.");
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void OpponentDefeated()
        {
            Console.Clear();

            Console.WriteLine("Przeciwnik pokonany.");
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void TheWeaponDoesNotHurt()
        {
            Console.Clear();

            Console.WriteLine("Broń nie czyni krzywdy przeciwnikowi, za to traci 1 punkt wytrzymałości.");

            StoryText.SelectWayDisplayDelay(i);
        }
        
        public static void StateOfArms(Weapon weapon)
        {
            Console.Clear();

            Console.WriteLine($"Po stracie punktu broń ma wytrzymałość: {weapon.Hardness}");

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void WeaponDestroyed(Weapon weapon)
        {
            Console.Clear();

            Console.WriteLine("Twoja broń {0}, uległa zniszczeniu!", weapon.WeponName);

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void InformationWeaponDestroyed()
        {
            Console.Clear();

            Console.WriteLine("Twoja broń uległa zniszczeniu, nie możesz atakowć.");
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void HeroRandomAttack(List<Hero> heroes, List<Hero> enemies, int j, int selectedEnemy)
        {
            Console.Clear();

            Console.WriteLine($"{heroes[j].Name}, atkuje losowo wybranego przeciwnika {enemies[selectedEnemy].Name}");
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void RandomEnemyAttack(List<Hero> heroes, List<Hero> enemies, int j, int i)
        {
            Console.Clear();

            Console.WriteLine("Tura ataku przeciwników !!!");

            Console.WriteLine("Atakuje losowo przeciwnik " + enemies[i].Name);

            Console.WriteLine("Atkuje losowo bohatera " + heroes[j].Name);
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(4);
        }

        public static void NoWeapon()
        {
            Console.Clear();

            Console.WriteLine();
            Console.WriteLine("Nie posiadasz żadnej broni, nie możesz atakowac. Atakuje ten kto ma broń.");
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(i);
        }

        public static void VictoryInBattle()
        {
            Console.Clear();

            Console.WriteLine("Zwycięstwo!");

            StoryText.SelectWayDisplayDelay(i);
        }
        
        public static void CompanionAtackEnemyPresentation(List<Hero> enemies)
        {
            int enemyNumber = 1;

            Console.Clear();

            Console.WriteLine("Wrogowie, których może zaatakować bohater.");

            foreach (Hero enemy in enemies)
            {
                Console.WriteLine();
                Console.WriteLine(enemy.Name);
                Console.WriteLine();
                Console.Write($"Stan wroga: ");
                HeroColorText(enemy);
                Console.WriteLine($"Życie: {enemy.Life}");
                Console.WriteLine($"Wytrzymałość: {enemy.Durability}");
                Console.WriteLine("");
                Console.WriteLine();
                enemyNumber++;
                Console.WriteLine();
            }

            StoryText.SelectWayDisplayDelay(i);
        }
    }
}
