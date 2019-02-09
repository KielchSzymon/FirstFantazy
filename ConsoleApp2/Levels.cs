
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
using FirstFantazy.Story;
using FirstFantazy.Core;
using Microsoft.Extensions.DependencyInjection;

namespace FirstFantazy_Levels
{
    public class Levels
    {
        public Hero LoadLevel1(Hero hero, ServiceProvider serviceProvider)
        {
            int i = 0;
            int direction = 0;

            TheBeginningOfTheLevel("1");

            Level1Text level1Text = new Level1Text(serviceProvider);

            Level1Text.HeroCondition(hero);

            #region BodyLevel

            level1Text.WackeUp(hero);

            do
            {
                StoryText.SelectWayDisplayDelay(4);

                CreateScene.LoadScene("Level1EnterScene");

                if (i > 0)
                {
                    Level1Text.TheSamePlace();
                }

                Level1Text.ChooseYourWay();


                GameCore.GetInputValueHandlingExceptions(0, 1, 2);


                if (direction == 1)
                {
                    if (!hero.backPack.ContainsKey("items"))
                    {
                        Console.Clear();
                        Level1Text.YouAreDeadInTheCleft();
                        StoryText.SelectWayDisplayDelay(4);
                        hero.IsLife = false;
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Console.Clear();
                        Level1Text.YouEndTheLevelWithTheTorch();
                        StoryText.SelectWayDisplayDelay(4);
                        hero.LevelEnd = true;
                    }
                }
                else
                {
                    if (hero.backPack.Count == 0)
                    {
                        Console.Clear();

                        CreateScene.LoadScene("Level1TorchScene");
                        Console.WriteLine();
                        Level1Text.YouFoundATorch();
                       
                        hero.backPack["items"] = new List<object>();
                        hero.backPack["items"].Add("torch");
                    }
                    else if (hero.backPack.ContainsKey("items") && hero.backPack["items"].Contains("torch"))
                    {
                        Console.Clear();
                        Level1Text.ThereIsNothingHere();
                    }
                }

                if (hero.Life == 0)
                {
                    hero.IsLife = false;
                }

                i++;
            }
            while (hero.IsLife && !hero.LevelEnd);

            #endregion BodyLevel

            return hero;
        }

        public Hero LoadLevel2(Hero hero)
        {
            int direction;

            TheBeginningOfTheLevel("2");

            StoryText.HeroCondition(hero);

            #region BodyLevel

            Level2Text.SelectTheUpOrDownPath();

            Console.WriteLine();
            StoryText.SimpleRoadSelection();

            direction = GameCore.GetInputValueHandlingExceptions(0, 1, 2);

            do
            {
                if (direction == 1)
                {
                    Console.WriteLine();
                    Level2Text.RockShelfBend();

                    hero.HurtHero();

                    Level2Text.EndOfTheLevel();

                    hero.LevelEnd = true;

                    StoryText.SelectWayDisplayDelay(4);
                }
                else
                {
                    Console.WriteLine();
                    Level2Text.DeathInTheHole();
                    StoryText.SelectWayDisplayDelay(4);
                    hero.IsLife = false;
                }
            } while (hero.IsLife && !hero.LevelEnd);

            #endregion BodyLevel

            return hero;
        }

        public Hero LoadLevel3(Hero hero, Hero hero2)
        {
            int direction;

            TheBeginningOfTheLevel("3");

            StoryText.HeroCondition(hero);

            #region BodyLevel

            Level3Text.TwoExitsFromTheCave();

            Console.WriteLine();

            Level3Text.SimpleRoadSelection();

            direction = GameCore.GetInputValueHandlingExceptions(0, 1, 2);

            do
            {
                if (direction == 1)
                {
                    Console.WriteLine();

                    Level3Text.MeetingOfACompanion(hero2);

                    StoryText.SelectWayDisplayDelay(4);

                    hero.Inventory[0] = new Weapon(2, 15, 5, "Stick");

                    CreateScene.LoadScene("Level3StickScene");

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
                        BattleText.VictoryInBattle();
                        Console.ReadKey();
                    }
                }
                else
                {
                    Level3Text.KilledByAnAnimal();
                    hero.IsLife = false;

                    StoryText.SelectWayDisplayDelay(4);
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

            Console.WriteLine("Level {0}", levelNumberText);

            StoryText.SelectWayDisplayDelay(2);
            Console.Clear();

        }
    }
}
