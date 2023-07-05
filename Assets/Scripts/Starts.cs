using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starts : MonoBehaviour
{
    XLuaManager lua;
    // Start is called before the first frame update
    void Start()
    {
        lua = new XLuaManager();
        lua.Init();
        lua.StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        lua.MainUpdata();
    }
}
