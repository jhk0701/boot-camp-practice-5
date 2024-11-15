using System;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    [HideInInspector] public PlayerInputController inputController;
    [HideInInspector] public PlayerCondition condition;
    [HideInInspector] public PlayerInteraction interaction;
    [HideInInspector] public Rigidbody rigidBody;
    [HideInInspector] public Equipment equip;
    [HideInInspector] public PlayerAttack attack;


    public Action<ItemData> AddItem;
    

    void Awake()
    {
        CharacterManager.Instance.Player = this;

        inputController = GetComponent<PlayerInputController>();
        condition = GetComponent<PlayerCondition>();
        interaction = GetComponent<PlayerInteraction>();
        equip = GetComponent<Equipment>();
        attack = GetComponent<PlayerAttack>();

        rigidBody = GetComponent<Rigidbody>();
    }

}
