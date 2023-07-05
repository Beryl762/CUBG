using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class XLuaManager
{

    public readonly LuaEnv luaEnv = new LuaEnv();


    public readonly string gameMainScriptName = "GameLuaMain";
    public const string gameMainStartFunction = "GameLuaMain.Start()";

    
    public void Init()
    {
        InitLuaEnv();
    }
    void InitLuaEnv()
    {
        if (luaEnv != null)
        {
            luaEnv.AddLoader(CustomLoader);
            //×¢²ápblua
            //luaEnv.AddBuildin("pb", XLua.LuaDLL.Lua.LoadPb);
        }
        else
        {
            Debug.LogError("InitLuaEnv null!!!");
        }
    }

    private byte[] CustomLoader(ref string filepath)
    {
        string scriptPath = string.Empty;
        filepath = filepath.Replace(".", "/") + ".lua";
#if UNITY_EDITOR
#endif
        //scriptPath = PathUtility.GetLuaScriptsSystemFolderPath();
        scriptPath = Path.Combine(Application.dataPath, "Scripts/Lua", filepath);
        return File.ReadAllBytes(scriptPath);
    }
    public void SafeDoString(string scriptContent)
    {
        if (luaEnv != null)
        {
            try
            {
                luaEnv.DoString(scriptContent);
            }
            catch (System.Exception ex)
            {
                string msg = string.Format("xLua exception : {0}\n {1}", ex.Message, ex.StackTrace);
                Debug.LogError(msg);
            }
        }
    }
    public void LoadScript(string scriptName)
    {
        SafeDoString(string.Format("require('{0}')", scriptName));
    }

    public void StartGame()
    {
        if (luaEnv != null)
        {
            LoadScript(gameMainScriptName);
            SafeDoString(gameMainStartFunction);

            luaUpdate = luaEnv.Global.Get<Action>("Update");
        }
    }
    Action luaUpdate;
    public void MainUpdata()
    {
        if (luaUpdate != null) luaUpdate();
    }

}
