using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    public RuntimeAnimatorController[] animatorControllers;
    public AnimationController animationController;



    void Start()
    {
        //animationController.animator = GetComponent<Animator>();
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
