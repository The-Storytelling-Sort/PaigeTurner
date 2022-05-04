using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach this script to a empty gameobject with a BoxCollider.
//Make the Box Collider a trigger.
//Tag the Empty GameObject as a WindZone.
public class VentWind : MonoBehaviour
{
    public float windStrength;
    public Vector3 direction;
}
