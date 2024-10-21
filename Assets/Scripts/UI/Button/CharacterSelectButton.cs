using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
    public void OnClickButtonCharacterSelect(int index)
    {
        PlayerInformManager.instance.SetId(index);
        SoundManager.Instance.Play("select", Sound.Sfx, 0.5f);
    }
}
