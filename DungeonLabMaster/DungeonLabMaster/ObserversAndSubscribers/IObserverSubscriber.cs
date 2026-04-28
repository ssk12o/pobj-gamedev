namespace DungeonLabMaster.SoundPropagation;

public interface IObserverSubscriber
{
    void OnNotify(INotification notification);
}