using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Registro : MonoBehaviour {
    public GameObject num;
    public GameObject date;
    private int Mesa;
    private string Date;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            if (num.GetComponent<InputField>().isFocused)
            {
                date.GetComponent<InputField>().Select();

            }
               }
        
        Mesa = Convert.ToInt32( num.GetComponent<InputField>().text);
        Date = date.GetComponent<InputField>().text;



    }
}
