﻿using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkBind : MonoBehaviour
{
    private VRIK vrik;
    private bool isLArmHand = false;
    private bool isRArmHand = false;
    private void Awake()
    {
        vrik = GetComponent<VRIK>();
    }
    private void Start()
    {
        vrik.solver.spine.headTarget = GameObject.FindGameObjectWithTag("NickHead").transform;
    }
    private void Update()
    {
        if (isLArmHand == false)
        {
            vrik.solver.leftArm.target = GameObject.FindGameObjectWithTag("LArmHand").transform;
            isLArmHand = true;
        }
        if (isRArmHand == false)
        {
            vrik.solver.rightArm.target = GameObject.FindGameObjectWithTag("RArmHand").transform;
            isRArmHand = true;
        }
    }

}
