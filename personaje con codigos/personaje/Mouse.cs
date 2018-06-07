using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour {
    Vector2 mouseLook; 
    Vector2 snoothV; 
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;

    void Start()
    {
        character = this.transform.parent.gameObject;
    }


    void Update()
    {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        snoothV.x = Mathf.Lerp(snoothV.x, md.x, 1f / smoothing);
        snoothV.y = Mathf.Lerp(snoothV.y, md.y, 1f / smoothing);

        mouseLook += snoothV;

        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);



    }
}
