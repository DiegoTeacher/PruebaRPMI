using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    public abstract bool Check(GameObject owner);

    public abstract void DrawGizmo(GameObject owner);
}
