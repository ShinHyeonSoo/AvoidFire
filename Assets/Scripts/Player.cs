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
        // TODO : ���� ���� ��ĳ���� �´� ������ �޾ƿ�����
    }

    private void OnEnable()
    {
        // �÷����̾� ���̵�(ĳ����Ÿ��)������ �ִϸ����� �����ϴ� �ڵ�
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];
    }

    public void ChangeAnimController()
    {
        // animator.runtimeAnimatorController = animatorControllers[GameManager.instance.playerId];
        // �ִϸ����� ��Ʈ�ѷ��� ���� ���õ� playerId�� �´� �ɷ� �ٲ�
    }
}
