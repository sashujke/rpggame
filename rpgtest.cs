using System;

class RPGGame
{
    static Random random = new Random();

    static int playerHealth = 100;
    static int playerMana = 50;
    static int monsterHealth = 120;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the text-based RPG!");

        while (playerHealth > 0 && monsterHealth > 0)
        {
            PlayerTurn();
            if (monsterHealth <= 0)
            {
                Console.WriteLine("You have defeated the monster!");
                break;
            }

            MonsterTurn();
            if (playerHealth <= 0)
            {
                Console.WriteLine("You have died. Game over.");
                break;
            }
        }
    }

    static void PlayerTurn()
    {
        Console.WriteLine("\nYour turn!");
        Console.WriteLine("Your health: " + playerHealth);
        Console.WriteLine("Monster's health: " + monsterHealth);
        Console.WriteLine("Your mana: " + playerMana);

        Console.WriteLine("Choose an action:");
        Console.WriteLine("1. Sword attack (deals 15-25 damage)");
        Console.WriteLine("2. Magic attack (deals 20-40 damage, costs 20 mana)");

        string input = Console.ReadLine();

        switch (input)
        {
            case "1":
                SwordAttack();
                break;
            case "2":
                if (playerMana >= 20)
                {
                    MagicAttack();
                }
                else
                {
                    Console.WriteLine("Not enough mana! You lost your turn.");
                }
                break;
            default:
                Console.WriteLine("Invalid choice. You lost your turn.");
                break;
        }
    }

    static void SwordAttack()
    {
        int damage = random.Next(15, 26); // Damage between 15 and 25
        Console.WriteLine("You swung your sword and dealt " + damage + " damage.");
        monsterHealth -= damage;
    }

    static void MagicAttack()
    {
        int damage = random.Next(20, 41); // Damage between 20 and 40
        Console.WriteLine("You used a magic attack and dealt " + damage + " damage.");
        monsterHealth -= damage;
        playerMana -= 20;
    }

    static void MonsterTurn()
    {
        Console.WriteLine("\nMonster's turn!");

        // Monster deals random damage
        int monsterDamage = random.Next(10, 31); // Damage between 10 and 30
        Console.WriteLine("The monster attacks and deals " + monsterDamage + " damage.");
        playerHealth -= monsterDamage;
    }
}
