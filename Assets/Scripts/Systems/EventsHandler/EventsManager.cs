using System.Collections.Generic;

/// <summary>
/// Events manager
/// </summary>
public class EventsManager
{
    public delegate void EventReceiver();
    private static Dictionary<string, EventReceiver> _events;

    /// <summary>
    /// Call this method to subscribe to events
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public static void SubscribeToEvent(string eventName, EventReceiver listener)
    {
        //If the dictionary is not initialised, then it will do. Lazy initialization.
        if (_events == null)
            _events = new Dictionary<string, EventReceiver>();

        //Event exists?, if yes, use it, otherwise, create it.
        if (!_events.ContainsKey(eventName))
            _events.Add(eventName, null);
        
        //Assigns the method to the event
        _events[eventName] += listener;
    }

    /// <summary>
    /// Call this method to unsuscribe events
    /// </summary>
    /// <param name="eventName"></param>
    /// <param name="listener"></param>
    public static void UnsubscribeToEvent(string eventName, EventReceiver listener)
    {
        //Searches the method in the events dictionary. Erases it if found
        if (_events != null)
        {
            if (_events.ContainsKey(eventName))
                _events[eventName] -= listener;
        }
    }

    /// <summary>
    /// Call this function to trigger an event
    /// </summary>
    /// <param name="eventName"></param>
    public static void TriggerEvent(string eventName)
    {
        //If event doesn't exists, it throws a Warning and finished the method execution
        if(_events == null)
        {
            UnityEngine.Debug.LogWarning("No events subscribed");
            return;
        }
        
        //If event name and method exist, then it is triggered
        if (_events.ContainsKey(eventName))
            _events[eventName]?.Invoke();
    }
}