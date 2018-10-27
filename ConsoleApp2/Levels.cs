
using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy_GameObject;
using FirstFantazy_Battle;
using FirstFantazy_Hero;
using FirstFantazy_Hero_Weapon;
using FirstFantazy_StoryText;
using FirstFantazy_StoryText_Story_Level;
using FirstFantazy_Scene;

namespace FirstFantazy_Levels
{
    public class Levels
    {
        public Hero LoadLevel1(Hero hero)
        {

            int direction;

            

            TheBeginningOfTheLevel("1");

            CreateScene.LoadScene("Level1"); 

            StoryText.HeroCondition(hero);

            #region BodyLevel

            Level1Story.Text1(hero);

            do
            {
                Level1Story.Text2();

                direction = Convert.ToInt16(Console.ReadLine());

                if (direction == 1)
                {
                    if (!hero.backPack.ContainsKey("items"))
                    {
                        Level1Story.Text3();
                        hero.IsLife = false;
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Level1Story.Text4();
                        Console.ReadKey();
                        hero.LevelEnd = true;
                    }
                }
                else
                {
                    if (hero.backPack.Count == 0)
                    {
                        Level1Story.Text5();
                        hero.backPack["items"] = new List<object>();
                        hero.backPack["items"].Add("torch");
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Level1Story.Text6();
                    }
                }

                if (hero.Life == 0)
                {
                    hero.IsLife = false;
                }
            }
            while (hero.IsLife && !hero.LevelEnd);

            #endregion BodyLevel

            return hero;
        }

        public Hero LoadLevel2(Hero hero)
        {

            TheBeginningOfTheLevel("2");

            StoryText.HeroCondition(hero);

            #region BodyLevel

            Level2Story.Text1();
            do
            {
                if (Level2Story.Text2(hero) == 1)
                {
                    Console.WriteLine("Pułka skalna urywa się nagle i z dużą prędkością spadasz w dół, " +
                        "tracisz punkjty wytrzymałości, ale docierasz do wyjści z z jaskiń");

                    hero.HurtHero();

                    Console.WriteLine();
                    Console.WriteLine("Gratulacje, ukończyłeś poziom!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();

                    hero.LevelEnd = true;

                }
                else
                {
                    Level2Story.Text3();
                    hero.IsLife = false;
                }
            } while (hero.IsLife && !hero.LevelEnd);

            #endregion BodyLevel

            return hero;
        }

        public Hero LoadLevel3(Hero hero, Hero hero2)
        {

            TheBeginningOfTheLevel("3");

            StoryText.HeroCondition(hero);

            #region BodyLevel

            do
            {
                if (Level3Story.Text1(hero) == 1)
                {
                    Level3Story.Text2(hero2);

                    hero.Inventory[0] = new Weapon(2, 15, 5, "Stick");

                    StoryText.HeroCondition(hero2);

                    #region CreatingHeroesAndEnemies

                    List<Hero> heroes = new List<Hero>();

                    heroes.Add(hero);
                    heroes.Add(hero2);

                    List<Hero> enemy = new List<Hero>()
                    {
                        new Hero()
                        {
                            HeroID = 3,
                            Durability = 10,
                            IsLife = true,
                            Name = "Ogr 1",
                            Life = 2,
                            Inventory = new Weapon[]{new Weapon(1, 5, 1, "Arm") }

                        },
                        new Hero()
                        {
                            HeroID = 4,
                            Durability = 10,
                            IsLife = true,
                            Name = "Ogr 2",
                            Life = 2,
                            Inventory = new Weapon[]{new Weapon(1, 5, 1, "Arm") }

                        }
                    };

                    #endregion CreatingHeroesAndEnemies


                    Battle battle = new Battle(heroes, enemy);
                    heroes = battle.Initialize();
                    
                    if (hero.IsLife)
                    {
                        hero.LevelEnd = true;
                        Level3Story.Text3();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Level3Story.Text4();
                    hero.IsLife = false;
                }

            } while (hero.IsLife && !hero.LevelEnd);

            return hero;

            #endregion BodyLevel

        }

        public Hero LoadLevel4(Hero hero, Hero hero2)
        {
            GameObject gameObject = new GameObject();

            TheBeginningOfTheLevel("4");
            StoryText.HeroCondition(hero);
            StoryText.HeroCondition(hero2);

            StoryText.SelectWayDisplayDelay(1);

            Level4Story.Text1();

            gameObject.Campfire(10, hero);
            gameObject.Campfire(10, hero2);

            StoryText.HeroCondition(hero);
            StoryText.HeroCondition(hero2);

            Level4Story.Text2();

            hero.Inventory[1] = new Weapon(5, 20, 10, "Sword");
            hero2.Inventory[1] = new Weapon(5, 20, 10, "Sword");

            StoryText.SelectWayDisplayDelay(1);  

            StoryText.HeroCondition(hero);
            StoryText.HeroCondition(hero2);

            return hero;
        }

        public void TheBeginningOfTheLevel(string levelNumber)
        {
            string levelNumberText = levelNumber;

            Console.Title = "FirstFantazy Level" + levelNumberText;

            Console.Clear();

            Console.SetCursorPosition(40, 11);

            Console.WriteLine("Level{0}", levelNumberText);
            Console.WriteLine();

            StoryText.SelectWayDisplayDelay(2);

        }
    }
}
