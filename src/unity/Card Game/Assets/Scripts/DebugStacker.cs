using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugStacker : MonoBehaviour
{
    public GameObject cardPrefab;

    public Camera cam;


    void Start()
    {
        Vector3 leftBorder = cam.ScreenToWorldPoint(new Vector3(0, Screen.height / 2));
        Vector3 rightBorder = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height / 2));

        Vector3 seventh = (rightBorder - leftBorder) / 7f;

        for (int i = 0; i < 7; i++)
        {
            Vector3 pos = (leftBorder + (seventh/2))  + (i * seventh);
            pos.z = 1f;
            pos.y = 0.5f;
            Instantiate(cardPrefab, pos, Quaternion.identity);
        }
    }
    




}
