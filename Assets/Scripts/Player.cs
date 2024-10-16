using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
    public GameManager GameManager;

    public RuntimeAnimatorController[] animatorControllers;
    public AnimationController animationController;

    public float speed;
    public float jumpPower;
    public int HP;

    private void Awake()
    {
        GameManager = GetComponent<GameManager>();
        speed = 7f;
        jumpPower = 1000f;
        HP = 3;
}

    void Start()
    {
        //animationController.animator = GetComponent<Animator>();
        // TODO : 추후 수정 각캐릭에 맞는 스탯을 받아오도록
    }

    private void OnEnable()
    {
        // 플레이이어 아이디(캐릭터타입)에따라 애니메이터 선택하는 코드
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];

        // SetPlayer(GameManager.instance.playerId);
    }

    public void ChangeAnimController()
    {
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];
        // 애니메이터 컨트롤러를 현재 선택된 playerId에 맞는 걸로 바꿈
    }

    private void SetPlayer(int playerID)
    {
        if (playerID == 0)
        {
            speed = 7f;
            jumpPower = 1000f;
            HP = 4;
        }
        if (playerID == 0)
        {
            speed = 10f;
            jumpPower = 1100f;
            HP = 3;
        }
    }
}
