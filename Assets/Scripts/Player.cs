using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public RuntimeAnimatorController[] animatorControllers;
    public AnimationController animationController;

    public string _name;
    public float speed;
    public float jumpPower;
    public int HP;

    private void Awake()
    {
        Debug.Log(PlayerInformManager.instance.playerName);
        animationController.animator = GetComponent<Animator>();
        // TODO : 추후 수정 각캐릭에 맞는 스탯을 받아오도록
        SetPlayer(PlayerInformManager.instance.playerId);
    }

    void Start()
    {
    }

    private void OnEnable()
    {
    }

    public void ChangeAnimController()
    {
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];
        // 애니메이터 컨트롤러를 현재 선택된 playerId에 맞는 걸로 바꿈
    }

    private void SetPlayer(int playerID)
    {
        Debug.Log("test");
        _name = PlayerInformManager.instance.playerName;
        if (playerID == 0)
        {
            speed = 7f;
            jumpPower = 9f;
            HP = 5;
        }
        else if (playerID == 1)
        {
            speed = 10f;
            jumpPower = 10f;
            HP = 3;
        }

        animationController.animator.runtimeAnimatorController = animatorControllers[PlayerInformManager.instance.playerId];
    }
}
