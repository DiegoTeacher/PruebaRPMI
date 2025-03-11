using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "HearAction (A)", menuName = "ScriptableObjects/Actions/HearAction")]
public class HearAction : Action
{
    public float radius = 20f;
    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position,
            radius, Vector3.up);
        GameObject target = owner.GetComponent<TargetReference>().target;

        foreach(RaycastHit hit in hits)
        {
            if(hit.collider.gameObject == target)
            {
                // le hemos escuchado / oler
                return true;
            }
        }

        return false; // no le escucho
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }
}
