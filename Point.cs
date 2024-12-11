using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] 
public class Point : MonoBehaviour
{
    public bool Runtime = true;
    public Rigidbody2D rbd;
    public Vector2 PointID;
    public List<Bar> ConnectedBars;

    private void Start()   // Configuració per detectar si existeix un punt i si és així no crear-ne un a sobre quan s'el clicki.
    {
        if (Runtime == false)
        {
            rbd.bodyType = RigidbodyType2D.Static;
            PointID = transform.position;
            if (GameLevelManager.AllPoints.ContainsKey(PointID) == false) GameLevelManager.AllPoints.Add(PointID, this);
        }
    }

    private void Update() // Configuració perquè el punt es mogui per cada punt de la graella i no lliurament.
    {
        if(Runtime == false) 
        {   
            if (transform.hasChanged == true) 
            {
                transform.hasChanged = false;
                transform.position = Vector3Int.RoundToInt(transform.position);
            }
        }
    } 
}


