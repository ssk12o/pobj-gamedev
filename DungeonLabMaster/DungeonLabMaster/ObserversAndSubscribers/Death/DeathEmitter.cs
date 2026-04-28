using DungeonLabMaster.Logging;

namespace DungeonLabMaster.SoundPropagation;

public class DeathEmitter: ISubscribtionDealer
{
    private string enemyName;

    public DeathEmitter(string name)
    {
        enemyName = name;
    }
    private List<IObserverSubscriber> _observers = new List<IObserverSubscriber>();
    
    public void AddObserver(IObserverSubscriber observerSubscriber)
    {
        if (!_observers.Contains(observerSubscriber))
        {
            _observers.Add(observerSubscriber);
        }
    }

    public void RemoveObserver(IObserverSubscriber observerSubscriber)
    {
        if (!_observers.Contains(observerSubscriber))
        {
            _observers.Remove(observerSubscriber);
        }
    }

    public void Notify(INotification notification)
    {
        foreach (var observer in _observers)
        {
            observer.OnNotify(notification);
        }
    }

    public int GetObserverCount()
    {
        return _observers.Count;
    }

    public void NotifyDeath(int deadY, int deadX)
    {
        Logger.Instance.Log($"Enemy {enemyName} makes sound of death at coordinates ({deadY}, {deadX}");
        INotification deathNotification = new DeathNotification(deadY, deadX, enemyName);
        Notify(deathNotification);
    }
}