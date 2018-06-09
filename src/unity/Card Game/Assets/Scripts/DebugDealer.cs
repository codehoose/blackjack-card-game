using UnityEngine;
using System.Collections;

public class DebugDealer : MonoBehaviour 
{
    public CardStack dealer;
    public CardStack player;

    // Sloan: Debug test code to provide known cards
    //int count = 0;
    //int[] cards = new int[] { 9, 7, 12 };

    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 256, 28), "Hit Me!"))
        {
            player.Push(dealer.Pop());
        }

        //if (GUI.Button(new Rect(10, 10, 256, 28), "Hit Me!"))
        //{
        //    player.Push(cards[count++]);
        //}
    }
}
