using System.Collections;
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
            //스테이지 넘기기
        }
    }
}
