using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int money;

    public Tower[] towers;

    public void OnClickTower(int index)
    {
        if (money < towers[index].cost)
            return;


    }

}
