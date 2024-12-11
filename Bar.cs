using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float Cost = 1;
    public float maxLength = 1f;
    public Vector2 StartPosition;
    public SpriteRenderer barSpriteRenderer;
    public BoxCollider2D boxCollider;
    public HingeJoint2D StartJoint;
    public HingeJoint2D EndJoint;

    float StartJoinCurrentLoad = 0;
    float EndJoinCurrentLoad = 0;
    MaterialPropertyBlock propBlock;
    public float actualCost;

    public void UpdateCreatingBar(Vector2 ToPosition) // Direccions de posició de la barra i màxima longitud
    {
        transform.position = (ToPosition + StartPosition) / 2;
        
        Vector2 dir = ToPosition - StartPosition;
        float angle = Vector2.SignedAngle(Vector2.right, dir);
        transform.rotation = Quaternion.Euler(new Vector3(0,0, angle));

        float Length = dir.magnitude;   
        barSpriteRenderer.size = new Vector2(Length, barSpriteRenderer.size.y);

        boxCollider.size = barSpriteRenderer.size;

        actualCost = Length * Cost;
    }

    public void UpdateMaterial() // Físiques de destrucció de les barres
    {
        if (StartJoint != null) StartJoinCurrentLoad = StartJoint.reactionForce.magnitude / StartJoint.breakForce;
        if (EndJoint != null) EndJoinCurrentLoad = EndJoint.reactionForce.magnitude / EndJoint.breakForce;
        float maxLoad = Mathf.Max(StartJoinCurrentLoad, EndJoinCurrentLoad);

        propBlock = new MaterialPropertyBlock();
        barSpriteRenderer.GetPropertyBlock(propBlock);
        propBlock.SetFloat("_Load",maxLoad);
        barSpriteRenderer.SetPropertyBlock(propBlock);
    }

    private void Update() // Inici del temps per a les físiques de les barres
    {
        if (Time.timeScale == 1) UpdateMaterial();
    }
}
