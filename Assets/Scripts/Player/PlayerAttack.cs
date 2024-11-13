using UnityEngine;

[System.Serializable]
public class Skill
{
    public SkillSO data;
    public void Activate()
    {
        // 작동
        GameObject.Instantiate(data.skillObject);
    }   
}

public class PlayerAttack : MonoBehaviour
{
    
    PlayerCondition condition;

    public int selectedSkill = -1;
    public Skill[] skills;

    void Start()
    {
        condition = CharacterManager.Instance.Player.condition;

        PlayerInputController inputController = CharacterManager.Instance.Player.inputController;
        inputController.OnMagicEvent += MagicAttack;
    }

    void MagicAttack()
    {
        Debug.Log($"{skills[selectedSkill].data.skillName}");
        skills[selectedSkill].Activate();
    }
}
