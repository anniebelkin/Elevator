using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    int floors = 6;
    int currentFloor = 0;
    bool isShabat = false;

    // thired method from assignmnet
    void announceFloor()
    {
        switch (currentFloor)
        {
            case -1:
                Debug.Log("Current floor: Parking");
                break;
            case 0:
                Debug.Log("Current floor: Lobby");
                break;
            default:
                Debug.Log($"Current floor: {currentFloor}");
                break;

        }
    }
    // GoUp and GoDown  - first methods from assignment
    void GoUp(int floors)
    {
        while (floors > 0)
        {
            currentFloor++;
            floors--;
            Debug.Log("going up...");
            if (isShabat)
            {
                announceFloor();
            }
        }
        announceFloor();
    }
    void GoDown(int floors)
    {
        while(floors > 0)
        {
            currentFloor--;
            floors--;
            Debug.Log("going down...");
            if (isShabat)
            {
                announceFloor();
            }
        }
        announceFloor();
    }
    // second method from assignment
    void GoToFloor(int input)
    {
        Debug.Log($"going to floor {input}");
        if (input < -1 || input > floors)
        {
            Debug.Log($"no such floor {input}");
        }
        else if (input > currentFloor)
        {
            GoUp(input - currentFloor);
        }
        else
        {
            GoDown(currentFloor - input);
        }
    }

    void Start()
    {
        GoToFloor(3);
        GoDown(2);
    }
}
