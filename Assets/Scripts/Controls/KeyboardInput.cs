using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KC = UnityEngine.KeyCode;
using In = UnityEngine.Input;

public class KeyboardInput : MonoBehaviour {

    public bool forward, backward, jump, sprintF, sprintB, build, escape = false;

    void Update() {
        CheckInput();
	}

    void CheckInput()
    {
        forward = backward = jump = sprintF = sprintB = build = escape = false;

        if (forward && backward)
        {
            forward = false;
            backward = false;
        }
        forward = In.GetKey(KC.D) || In.GetKey(KC.LeftArrow);
        backward = In.GetKey(KC.A) || In.GetKey(KC.RightArrow);
        jump = In.GetKey(KC.Space) || In.GetKey(KC.W) || Input.GetKey(KC.UpArrow);
        sprintF = In.GetKey(KC.D) && In.GetKey(KC.LeftShift) || In.GetKey(KC.RightArrow) && In.GetKey(KC.LeftShift);
        sprintB = In.GetKey(KC.A) && In.GetKey(KC.LeftShift) || In.GetKey(KC.LeftArrow) && In.GetKey(KC.LeftShift);
        build = In.GetKeyDown(KC.R);
        escape = In.GetKeyDown(KC.Escape);
        
    }
}
