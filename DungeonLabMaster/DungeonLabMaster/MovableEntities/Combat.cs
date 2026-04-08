using System.ComponentModel;
using DungeonLabMaster.Items.Weapons;
using DungeonLabMaster.MovableEntities.Enemy;

namespace DungeonLabMaster.MovableEntities;

public class Combat
{
    private IWeaponVisitor vis;
    bool active = true;
    private IAliveEntity _enemy;
    private Player _player;

    public Combat(IAliveEntity fightEnemy,  Player fightPlayer)
    {
        _enemy = fightEnemy;
        _player = fightPlayer;
        PrintGreeter();
        
    }
    public void arenaFight()
    {
        int chosenOption;
        while (active)
        {
            PrintOptions();
            while(!int.TryParse(Console.ReadLine(), out chosenOption) )
            {
                Console.WriteLine("Invalid option. try again.");
                Thread.Sleep(1000);
            }

            if (chosenOption >= 0 && chosenOption <= 2)
            {
                vis = GetVisitorFromAttackType((AttackType)chosenOption);
                PlayerAttack(_player, _enemy);
            }
            else
            {
                Console.WriteLine("Player waits to long to attacks...");
            }

            vis = GetVisitorFromAttackType((AttackType)Random.Shared.Next(2));
            EnemyAttack(_player, _enemy);
        }
        
        Console.WriteLine("Fight ends");
        Console.ReadLine();
        Console.Clear();
    }
    
    private enum AttackType
    {
        Normal,
        Sneaky,
        Magical,
    }

    private void PlayerAttack(Player player, IAliveEntity enemy)
    {
        if(vis == null || active == false) return;

        int rawDamage = player.CalculateAttackDamage(vis);
        // Console.WriteLine($"raw damage {rawDamage}");
        int realDamage = Math.Max(0, rawDamage - ((IEnemy)enemy).Armor);
        
        Console.WriteLine($"Player attacks {enemy.Name} dealing {realDamage} dmg");
        if (enemy.TakeDamage(realDamage) <= 0)
        {
            active = false;
        }
    }

    private void EnemyAttack(Player player, IAliveEntity enemy)
    {
        if(vis == null || active == false) return;
        int rawDamage = ((IWeapon)((IEnemy)enemy).weapon).Accept(vis);
        int rawDefense = player.CalculateDefense(vis,  ((IWeapon)((IEnemy)enemy).weapon));
        int realDamage = Math.Max(0, rawDamage - rawDefense);
        
        Console.WriteLine($"{enemy.Name} attacks Player dealing {realDamage} dmg");

        IAliveEntity playerEnt = player as IAliveEntity;
        if (((IAliveEntity)player).TakeDamage(realDamage) <= 0)
        {
            active = false;
        }
    }

    private IWeaponVisitor GetVisitorFromAttackType(AttackType type)
    {
        switch (type)
        {
            case AttackType.Normal:
                vis = new NormalAttackVisitor();
                break;
            case AttackType.Sneaky:
                vis = new SneakyAttackVisitor();
                break;
            case AttackType.Magical:
                vis = new MagicalAttackVisitor();
                break;
            default:
                Console.WriteLine("Wrong attack!");
                return null;
        }

        return vis;
    }

    private void PrintGreeter()
    {
        Console.WriteLine("You are fighting against enemy!");
    }

    private void PrintOptions()
    {
        Console.WriteLine("\n[0] - Normal," +
                          "\n[1] - Sneaky," +
                          "\n[2] - Magical,");
    }

}