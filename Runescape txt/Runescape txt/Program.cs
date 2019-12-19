using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runescape_txt
{
    class Program
    {
        class Mob
        {
            public string name;
            public int strenght;
            public int health;
            public void Printhero()
            {
                Console.WriteLine("Your health: " + health);
                Console.WriteLine("Your strenght:" + strenght);
            }

            public void Printbase ()
            {
                Console.WriteLine("You're fighting: " + name);
                Console.WriteLine("Health: " + health);
                Console.WriteLine("Strenght: " + strenght);
            }
        }

        class Goblin : Mob
        {
            public int defence;
        }
        class Dragon : Mob
        {
            public int heal;
        }
        class Human : Mob
        {
            public int defence;
        }
        static void Main(string[] args)
        {
            int q = 0;
            int stop = 0;
            //int option = Convert.ToInt32( Console.ReadLine());
            //Console.WriteLine(option);
            //TextWriter tw = new StreamWriter("E:/Runescape txt/player.txt", true);
            //TextWriter bw = new StreamWriter("E:/Runescape txt/playerinventory.txt", true);
            //TextWriter cw = new StreamWriter("E:/Runescape txt/playerid.txt", true);
            //TextWriter dw = new StreamWriter("E:/Runescape txt/playercount.txt", true);
            //tw.Close();
            //cw.Close();
            //bw.Close();
            //dw.Close();
            Console.WriteLine("Hello please enter your username");
            string name=Console.ReadLine();
            
            while (stop <= 1) 
            {
                if (Register(name) == 2)
                {
                    //Console.Clear();
                    break;
                }
                Register(name);
                
            }
            while (q == 0)
            {
                Console.WriteLine("What whould you like to do next");
                Console.WriteLine("1.Fight");
                Console.WriteLine("2.Shop");
                Console.WriteLine("3.Check inventory");
                Console.WriteLine("4.Quit");
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1)
                {
                    Console.WriteLine("What monster you wish to fight?");
                    Console.WriteLine("1.Goblin");
                    Console.WriteLine("2.Dragon");
                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    if (choice1 == 1)
                    {
                        string[] inv = System.IO.File.ReadAllLines(@"E:/Runescape txt/" + name + "inventory.txt");
                        Console.Clear();
                        Goblin goblin = new Goblin();
                        goblin.name = "Goblin";
                        goblin.health = 10;
                        goblin.strenght = 2;
                        goblin.defence = 1;
                        goblin.Printbase();
                        Console.WriteLine("");
                        Human human = new Human();
                        human.health = 10;
                        human.strenght = 3;
                        human.defence = 1;
                        if (inv[0] == "sword and shield")
                        {
                            human.strenght = 1003;
                            human.defence = 1000;
                        }
                        human.Printhero();
                        Console.WriteLine("");

                        while (goblin.health >= 1 && human.health >= 1)
                        {
                            //int num = 1;
                            Console.WriteLine("You hit Goblin for: " + human.strenght + " points of damage");
                            Console.WriteLine("Goblin manages to defend: " + goblin.defence + " point of damage");
                            goblin.health = goblin.health - human.strenght + goblin.defence;
                            //Console.WriteLine("Goblin health:" + goblin.health);
                            Console.WriteLine("Goblin hit's you back for: " + goblin.strenght + " points of damage");
                            Console.WriteLine("You manage to defend: " + human.defence + " points of damage");
                            human.health = human.health - goblin.strenght + human.defence;
                            Console.WriteLine("");
                            Console.WriteLine("Goblin health: " + goblin.health);
                            Console.WriteLine("Your health: " + human.health);
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        if (goblin.health <= 0)
                        {
                            string loot = "5";
                            Console.WriteLine("You killed Goblin and got 5 gold");
                            System.IO.File.WriteAllText(@"E:/Runescape txt/" + name + "gold.txt", loot);
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("You fainted and lost your gold");
                            System.IO.File.WriteAllText(@"E:/Runescape txt/" + name + "gold.txt", "0");
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();
                        }


                    }
                    else
                    {
                        string[] inv = System.IO.File.ReadAllLines(@"E:/Runescape txt/" + name + "inventory.txt");
                        Console.Clear();
                        Dragon dragon = new Dragon();
                        dragon.name = "Dragon";
                        dragon.health = 1000;
                        dragon.strenght = 50;
                        dragon.heal = 10;
                        dragon.Printbase();
                        Console.WriteLine("");
                        Human human = new Human();
                        human.health = 10;
                        human.strenght = 3;
                        human.defence = 1;
                        if (inv[0]=="sword and shield")
                        {
                            Console.WriteLine("tiesa");
                            human.strenght = 1003;
                            human.defence = 1000;
                        }
                        human.Printhero();
                        Console.WriteLine("");

                        while (dragon.health >= 1 && human.health >= 1)
                        {
                            Console.WriteLine("You hit Dragon for: " + human.strenght + " points of damage");
                            Console.WriteLine("Dragon heals: " + dragon.heal + " health");
                            dragon.health = dragon.health - human.strenght + dragon.heal;
                            Console.WriteLine("Dragon hit's you back for: " + dragon.strenght + " points of damage");
                            Console.WriteLine("You manage to defend: " + human.defence + " points of damage");
                            human.health = human.health - dragon.strenght + human.defence;
                            Console.WriteLine("");
                            if (human.health>10)
                            {
                                human.health = 10;
                            }
                            Console.WriteLine("Dragon health: " + dragon.health);
                            Console.WriteLine("Your health: " + human.health);
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        if (dragon.health <= 0)
                        {
                            string dragonloot = "999";
                            Console.WriteLine("You killed Dragon and got 999 gold");
                            System.IO.File.WriteAllText(@"E:/Runescape txt/" + name + "gold.txt", dragonloot);
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("You fainted and lost your gold");
                            System.IO.File.WriteAllText(@"E:/Runescape txt/" + name + "gold.txt", "0");
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                }
                if(choice==2)
                {
                    Console.Clear();
                    string[] lines = System.IO.File.ReadAllLines(@"D:/Runescape txt/" + name + "gold.txt");
                    Console.WriteLine("What whould you like to buy");
                    Console.WriteLine("You have:" + lines[0] + " gold");
                    Console.WriteLine("1.Sword and shield (gives you +1000 strenght and defence)");
                    int weaponch = Convert.ToInt32(Console.ReadLine());
                    if (weaponch==1)
                    {
                        if (Convert.ToInt32(lines[0])>= 5)
                        {
                            Console.Clear();
                            Console.WriteLine("You have succesfully bought sword and shield");
                            string[] inventory = System.IO.File.ReadAllLines(@"D:/Runescape txt/" + name + "inventory.txt");
                            System.IO.File.WriteAllText(@"D:/Runescape txt/" + name + "inventory.txt", "sword and shield");
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You dont have enouh gold");
                            Console.WriteLine("Press any key to continue..");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }

                }
                if(choice==3)
                {
                    Console.Clear();
                    string text = System.IO.File.ReadAllText(@"E:/Runescape txt/" + name + "inventory.txt");
                    System.Console.WriteLine("You have {0}", text);
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadKey();
                    Console.Clear();
                }
                if(choice==4)
                {
                    break;
                }
            }
            


            Console.ReadLine();

        }
        static int Register(string name)
        {
            int stop;
            int empty = 0;
            //string curFile = @"E:/Runescape txt/player.txt";
            string[] lines = System.IO.File.ReadAllLines(@"E:/Runescape txt/playercount.txt");
            string[] username = System.IO.File.ReadAllLines(@"E:/Runescape txt/player.txt");
            int playercount = Convert.ToInt32(lines[0]);
            Console.WriteLine(playercount);
            Console.WriteLine(username[0]);
            Console.WriteLine(name);
            empty = empty + 1;
            //for(int i=0;i<playercount;i++)
            //{
            //    if (name.Equals(username[i])==true)
            //    {
            //        Console.WriteLine("Toks vartotojas jau egzituoja");
            //        Console.WriteLine("Buvote prijungtas");

            //        stop = 2;
            //        return stop;
            //    }
            //    else
            //    {
            //        empty=empty+1;
            //    }
                
           // }
            if(empty==1)
            {
                Console.WriteLine("Tokio vartotojo nera buvote uzregistruotas");
                using (System.IO.StreamWriter user =
            new System.IO.StreamWriter(@"E:/Runescape txt/player.txt", true))
                using (System.IO.StreamWriter inv =
                new System.IO.StreamWriter(@"E:/Runescape txt/playerinventory.txt", true))
                using (System.IO.StreamWriter id =
                new System.IO.StreamWriter(@"E:/Runescape txt/playerid.txt", true))
                {
                    //System.IO.File.WriteAllText(@"E:/Runescape txt/playercount.txt",);
                    id.WriteLine(playercount + 1);
                    //user.Write(playercount);
                    user.WriteLine(name);
                    for(int i =0;i<10;i++)
                    {
                        inv.WriteLine("empty");
                    }
                }
                using (StreamWriter sw = new StreamWriter(@"E:/Runescape txt/playerid.txt", true))
                {
                    sw.Write(playercount+99999);
                }
                stop = 2;
                return stop;

            }
            stop = 2;
            return stop;

        }
    }
}
