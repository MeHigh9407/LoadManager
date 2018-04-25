using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpData  {

    public int Key;
    public IStartUp ScriptToLoad;

    public StartUpData(int key, IStartUp scriptToLoad)
    {
        Key = key;
        ScriptToLoad = scriptToLoad;
    }
}
