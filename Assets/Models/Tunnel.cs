﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Tunnel : Pipeline
{
    [SerializeField]
    private int _depth;

    public int Depth
    {
        get { return _depth; }
        private set { _depth = value; }
    }
}