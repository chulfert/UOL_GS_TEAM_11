using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDController : MonoBehaviour
{
    public Slider HPbar;
    public void SetMaxHP(float HP)
    {
        HPbar.maxValue = HP;
        HPbar.value = HP;
    }
    public void SetHP(float HP)
    {
        HPbar.value = HP;
    }
}
