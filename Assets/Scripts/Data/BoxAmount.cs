using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxAmount : MonoBehaviour {

    public int BoxNr;

    [SerializeField] private Text HoldBoxes;

    void Awake()
    {
        BoxNr = 3;
    }

    void Update()
    {
        SetBoxes();
    }

    void SetBoxes()
    {
        HoldBoxes.text = BoxNr.ToString();
    }
}
