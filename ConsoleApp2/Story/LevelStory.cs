using System;
using System.Collections.Generic;
using System.Text;
using FirstFantazy_StoryText;
using FirstFantazy_Hero;


namespace FirstFantazy_StoryText_Story_Level
{
    //create new file for every class in this cs
    public class Level1Story : StoryText
    {

        //TODO change the methods name to more description name   
        public static void Text1(Hero hero)
        {
            Console.WriteLine("Budzisz się jedyne co pamiętasz to, że masz na imię {0}", hero.Name);
            Console.WriteLine();
        }

        public static void Text2()
        {
            Console.WriteLine();
            Console.WriteLine("Przed sobą widzisz dwie ścieżki, idziesz w (1) lewo lub (2) w prawo.");
        }

        public static void Text3()
        {
            Console.WriteLine("Giniesz! Nie widzisz gdzie idziesz i niestety potykasz się wpadając w rospadlinę.");
        }

        public static void Text4()
        {
            Console.WriteLine("Dzięki pochodni udaje Ci się przejść do kolejnej jaskini.");
            Console.WriteLine();
            Console.WriteLine("Gratulacje, ukończyłeś poziom!");
            Console.WriteLine("Press any key to continue...");
        }

        public static void Text5()
        {
            Console.WriteLine("Zanjdujesz palącą się pochodnię.");
        }

        public static void Text6()
        {
            Console.WriteLine("Tu już nic nie ma");
        }
    }
    public class Level2Story : StoryText
    {
        public static void Text1()
        {
            Console.WriteLine("Pochodznia oświetla nikłym blaskiem mroki kolejnej jaskini, " +
                "gdzieś w oddali słychać kapanie wody rozbryzgującej się na skale. " +
                "Twoja obecność przestraszyła nietoperze, które przeleciały ci nad gową uciekając  w mrok. " +
                "Przed sobą widzisz dwie drogi: jedna to pułka skalna ciągnąca się wzdłuż ściany jaskini (1), druga to ścieżka podążająca w dół (2).");
        }

        public static int Text2(Hero hero)
        {
            return hero.HeroDirection("Wybierz drogę (1) lub (2): ");
        }

        public static void Text3()
        {
            Console.WriteLine("Droga w doł, którą podążasz nagle zapada się i trafiasz do głębokiego dołu, pomimo usilnych starań, " +
                        "nie potrafisz się wydostać i umierasz z pragnienia i głodu!");
        }
    }
    public class Level3Story : StoryText
    {
        public static int Text1(Hero hero)
        {
            return hero.HeroDirection("Wybierz drogę (1) lub (2)");
        }

        public static void Text2(Hero hero2)
        {
            Console.WriteLine("Spotykasz bohatera o imieniu {0}, który rzuca ci kij z ostrzeżeniem. 'Uwaga nadchodzą!' ", hero2.Name);
            Console.WriteLine();
        }

        public static void Text3()
        {
            Console.WriteLine("Zwycięstwo!");
        }

        public static void Text4()
        {
            Console.WriteLine();
            Console.WriteLine("Atakuje cię nieznany zwierz i giniesz!");
        }
    }
    public class Level4Story : StoryText
    {
        public static void Text1()
        {
            Console.WriteLine("Bitwa wygrana, ocaliliście życie. Teraz trzeba obszukać wrogów, zobaczyć czy nie mają czegoś cennego.");
            Console.WriteLine("A potem ukryć się czym prędzej, znaleźdż jakieś miejsce na odpoczynek.");
            Console.WriteLine();
            Console.WriteLine("Znajdujecie miejsce na odpoczynek, rozpalacie ognisko, to pozwala zregenerować wytrzymałoś." +
                " Niestety przy wrogach nic nie było.");
            Console.WriteLine();

            Console.WriteLine("Ukrywacie się w pobliskiej rozpadlinie skalnej, u podnóża gory. Rozpalacie ognisko.");
            Console.WriteLine("Odzyskujecie utraconą wytrzymałość, każyd z was po 10 puktów");
            Console.WriteLine();
        }

        public static void Text2()
        {
            Console.WriteLine("Rozpadlina skalna, w której się ukryliście okazuje się grobem kilkunastu rycerzy, z uzbrojenia, " +
            " które tam odnaleźliście bierzecie po mieczu.");
        }
    }
}
