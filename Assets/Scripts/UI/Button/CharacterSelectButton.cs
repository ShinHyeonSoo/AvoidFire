using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectButton : MonoBehaviour
{
    public void OnClickButtonCharacterSelect(int index)
    {
        PlayerInformManager.instance.SetId(index);
    }
}
