using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(KeyboardInput))]
public class InputData : MonoBehaviour {

    [SerializeField] KeyboardInput KD;
    public bool Fo, Ba, Ju, Spf, Spb, Bu, Es = false;

    void Update()
    {
        KeyboardCheck();
    }

    void KeyboardCheck()
    {
        Fo = Ba = Ju = Spf = Spb = Bu = Es = false;

        if (KD.forward) { Fo = true; }
        if (KD.backward) { Ba = true; }
        if (KD.jump) { Ju = true; }
        if (KD.sprintF) { Spf = true; }
        if (KD.sprintB) { Spb = true; }
        if (KD.build) { Bu = true; }
        if (KD.escape) { Es = true; }
    }
}
