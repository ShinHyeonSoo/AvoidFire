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
        
        if(PlayerInformManager.instance != null)
            SetPlayer(PlayerInformManager.instance.playerId);
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
