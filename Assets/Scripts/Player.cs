using UnityEngine;

public class Player : MonoBehaviour
{
    public RuntimeAnimatorController[] animatorControllers;
    public Animator animator;

    public string _name;
    public float speed;
    public float jumpPower;
    public int HP;
    public bool isDead;

    private void Awake()
    {
        isDead = false;
        animator = GetComponent<Animator>();
        // ------- 테스트 끝나면 삭제 -------
        speed = 7f;
        jumpPower = 9f;
        HP = 5;
        animator.runtimeAnimatorController = animatorControllers[0];
        // ------- 테스트 끝나면 삭제 -------
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


        animator.runtimeAnimatorController = animatorControllers[PlayerInformManager.instance.playerId];
    }
}
