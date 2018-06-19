using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changec : MonoBehaviour {

    public Material materialb;

    public void Change()
    {
      if (Input.GetKeyDown("space")) gameObject.GetComponent<Renderer>().material = materialb;

    }
}
