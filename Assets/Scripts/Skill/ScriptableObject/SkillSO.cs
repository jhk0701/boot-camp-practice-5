using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Data", menuName = "New Skill Data", order = 0)]
public class SkillSO : ScriptableObject 
{
    public string skillName = "Skill";
    public Sprite icon;

    public float damage = 50f;
    public float coolDown = 10f;
    public float requiredMana = 100f;

    public SkillObject skillObject;
}