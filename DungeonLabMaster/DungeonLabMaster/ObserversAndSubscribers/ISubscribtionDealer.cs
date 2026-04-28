namespace DungeonLabMaster.SoundPropagation;

public interface ISubscribtionDealer
{
    void AddObserver(IObserverSubscriber observerSubscriber);
    void RemoveObserver(IObserverSubscriber observerSubscriber);
    void Notify(INotification notification);
    int GetObserverCount();
}