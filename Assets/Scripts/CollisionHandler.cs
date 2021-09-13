using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) 
    {
        switch(other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Off we go!");
                break;
            case "Fuel":
                Debug.Log("This is useful!");
                break;
            case "Finish":
                Debug.Log("Home at last!");
                break;
            default:
                Debug.Log("I blew up!");
                break;
        }
    }
}
