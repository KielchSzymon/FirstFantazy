
using System;
using System.Collections.Generic;
using System.Text;

using FirstFantazy.Story.LevelText;
using FirstFantazy_GameObject;
using FirstFantazy_Battle;
using FirstFantazy_Hero;
using FirstFantazy_Hero_Weapon;
using FirstFantazy_StoryText;
using FirstFantazy_Scene;

namespace FirstFantazy_Levels
{
    public class Levels
    {
        public Hero LoadLevel1(Hero hero)
        {

            int direction;

            TheBeginningOfTheLevel("1");

            Level1Text.HeroCondition(hero);

            #region BodyLevel

            Level1Text.WackeUp(hero);

            do
            {
                StoryText.SelectWayDisplayDelay(0);

                CreateScene.LoadScene("Level1");

                Level1Text.ChooseYourWay();

                direction = Convert.ToInt16(StoryText.DownloadingData());

                if (direction == 1)
                {
                    if (!hero.backPack.ContainsKey("items"))
                    {
                        Level1Text.YouAreDeadInTheCleft();
                        hero.IsLife = false;
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Level1Text.YouEndTheLevelWithTheTorch();
                        Console.ReadKey();
                        hero.LevelEnd = true;
                    }
                }
                else
                {
                    if (hero.backPack.Count == 0)
                    {
                        Level1Text.YouFoundATorch();
                        hero.backPack["items"] = new List<object>();
                        hero.backPack["items"].Add("torch");
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Level1Text.ThereIsNothingHere();
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

            Level2Text.SelectTheUpOrDownPath();

            do
            {
                if (Level2Text.ChooseYourWay(hero) == 1)
                {
                    Level2Text.RockShelfBend();

                    hero.HurtHero();

                    Level2Text.EndOfTheLevel();

                    hero.LevelEnd = true;

                }
                else
                {
                    Level2Text.DeathInTheHole();
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
                if (Level1Text.ChooseYourWay(hero) == 1)
                {
                    Level3Text.MeetingOfACompanion(hero2);

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
                        Level3Text.VictoryInBattle();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Level3Text.KilledByAnAnimal();
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

            Level4Text.AfterTheVictoriousBattleWithOgres();

            gameObject.Campfire(10, hero);
            gameObject.Campfire(10, hero2);

            StoryText.HeroCondition(hero);
            StoryText.HeroCondition(hero2);

            Level4Text.FindingASword();

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
