using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Monster", menuName = "Monster")]
public class Monster : ScriptableObject
{
    public string monsterName;
    public float maxHealth;
    public string type;
    public float attack;
    public float defense;
}
