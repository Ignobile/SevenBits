using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_objeto : MonoBehaviour {
    float distance = 10;

    //metodo para agarrar el objeto y arrastrarlo
    void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
        
    }
}