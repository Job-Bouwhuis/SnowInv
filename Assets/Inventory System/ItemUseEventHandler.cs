using UnityEngine;
using UnityEngine.Events;

public class ItemUseEventHandler : UnityEvent<int, GameObject>
{
    public void Content(int d, GameObject player)
    {
        Debug.Log($"Recieved Event Call with ID {d} and from object {player}");
    }
}
