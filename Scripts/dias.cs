using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dias : MonoBehaviour {

    public Dropdown mdias;
    public Dropdown mes;
    List<string> mes28 = new List<string> {"FEBRERO"};
    List<string> mes30 = new List<string> { "ABRIL","JUNIO","SEPTIEMBRE","NOVIEMBRE" };
    List<string> mes31 = new List<string> { "ENERO", "MARZO", "MAYO", "JULIO", "AGOSTO","OCTUBRE","NOVIEMBRE","DICIEMBRE" };
    
    // Use this for initialization
    void Start () {
        mdias.ClearOptions();
	}
	
	// Update is called once per frame
	void Update () {
        mdias.ClearOptions();
        Dias();
	}

    void Dias()
    {
        
        if (mes31.Contains(mes.captionText.text))
        {
            List<string> dias = new List<string> { "01", "02", "03", "04", "05","06","07","08","09","10",
                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31"  };
            mdias.AddOptions(dias);
        } 
        else if (mes30.Contains(mes.captionText.text))
        {
            List<string> dias = new List<string> { "01", "02", "03", "04", "05","06","07","08","09","10",
                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"  };
            mdias.AddOptions(dias);
        }
        else if (mes28.Contains(mes.captionText.text))
        {
            List<string> dias = new List<string> { "01", "02", "03", "04", "05","06","07","08","09","10",
                "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28" };
            mdias.AddOptions(dias);
        }
    }
}
