﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]

public class Door : InteractiveObject
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
}
