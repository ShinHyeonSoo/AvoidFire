using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public int HP;

    public RuntimeAnimatorController[] animatorControllers;
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        // TODO : 추후 수정 각캐릭에 맞는 스탯을 받아오도록
    }

    private void OnEnable()
    {
        // 플레이이어 아이디(캐릭터타입)에따라 애니메이터 선택하는 코드
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];
    }

    public void ChangeAnimController()
    {
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];
        // 애니메이터 컨트롤러를 현재 선택된 playerId에 맞는 걸로 바꿈
    }
}
