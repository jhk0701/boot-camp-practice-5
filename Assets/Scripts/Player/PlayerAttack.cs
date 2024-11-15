using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Skill
{
    public SkillSO data;
    public void Activate(Vector3 position, Vector3 direction)
    {
        // 작동
        SkillObject obj = GameObject.Instantiate(data.skillObject);

        obj.transform.rotation = Quaternion.LookRotation(direction);
        obj.transform.position = position;

        obj.Act(data);
    }   
}

public class PlayerAttack : MonoBehaviour
{
    
    PlayerCondition condition;

    public int selectedSkill = -1;
    public Skill[] skills;

    [SerializeField] Image tempIcon;

    void Start()
    {
        condition = CharacterManager.Instance.Player.condition;

        PlayerInputController inputController = CharacterManager.Instance.Player.inputController;
        inputController.OnMagicEvent += MagicAttack;
        inputController.OnSwitchSkillEvent += () =>
        {
            selectedSkill++;
            if(selectedSkill >= skills.Length)
                selectedSkill = 0;
            
            SelectSkill(selectedSkill);
        };

        SelectSkill(0);
    }

    void MagicAttack()
    {
        Debug.Log($"{skills[selectedSkill].data.skillName}");
        skills[selectedSkill].Activate(transform.position + transform.forward, transform.forward);
    }

    // TODO : 현재 버튼에 직접 넣어둠, 자동화 시킬 것 
    public void SelectSkill(int id)
    {
        selectedSkill = id;
        tempIcon.sprite = skills[id].data.icon;
    }
}
