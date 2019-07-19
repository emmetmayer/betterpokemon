using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Move", menuName = "Move")]
public class Move : ScriptableObject
{
    public string moveName;
    public float damage;
    public string type;
    public Color color;
    public int energy;
    public GameObject moveEffect;
}
