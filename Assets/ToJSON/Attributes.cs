﻿using UnityEngine;
using System.Collections;
using System;

[AttributeUsage(
    AttributeTargets.Field,
    AllowMultiple = false,
    Inherited = true)]
public class IgnoreAttribute : Attribute {

}
