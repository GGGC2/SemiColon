﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    public int keytimes = 0;

    public void getkey()
    {
        keytimes--;
    }

    public void opendoor()
    {
        if(keytimes == 0)
        {
			Scene_manager.Instance.Scene_change();
        }
    }
}
