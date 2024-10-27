using Photon.Pun;
using System.Collections.Generic;

public abstract class Subject : MonoBehaviourPun
{
    private List<IObserver> _observersActionSpecial = new();
    private List<IObserver> _observersActionBasic = new();

    public void AddObserverForActionSpecial(IObserver observer)
    {
        _observersActionSpecial.Add(observer);
    }

    public void AddObserverForActionBasic(IObserver observer)
    {
        _observersActionBasic.Add(observer);
    }

    public void RemoveObserverForActionSpecial(IObserver observer)
    {
        _observersActionSpecial.Remove(observer);
    }

    public void RemoveObserverForActionBasic(IObserver observer)
    {
        _observersActionBasic.Remove(observer);
    }

    public void NotifyObserversForActionSpecial(string action)
    {
        _observersActionSpecial.ForEach((observer) =>
        {
            observer.OnNotify(action);
        });
    }

    public void NotifyObserversForActionBasic(string action)
    {
        _observersActionBasic.ForEach((observer) =>
        {
            observer.OnNotify(action);
        });
    }
}