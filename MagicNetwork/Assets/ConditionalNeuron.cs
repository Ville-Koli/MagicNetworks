using System;
using UnityEngine;
public class Branch{}
public class ConditionalNeuron
{
    private Func<float> transformer;
    private float theta;
    private Branch branch;
}
