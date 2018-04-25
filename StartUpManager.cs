using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StartUpManager : MonoBehaviour {

    private static List<StartUpData> StartUpSequence = new List<StartUpData>();

    public static void AddStartSequence(int sequence, IStartUp scriptToLoad,bool allowDuplicate)
    {
        if (allowDuplicate)
        {
            StartUpSequence.Add(new StartUpData(sequence, scriptToLoad));
        }
        else if (!allowDuplicate)
        {
            if (StartUpSequence.Exists(x => x.ScriptToLoad == scriptToLoad))
            {
                Debug.Log("This Type of script already exist, was this a error?");
            }
            else
            {
                StartUpSequence.Add(new StartUpData(sequence, scriptToLoad));
            }
        }
           
    }

    private void Start()
    {
        foreach (var sequence in StartUpSequence.OrderBy(x => x.Key))
        {
            sequence.ScriptToLoad.OnCreation();
            sequence.ScriptToLoad.OnAwake();
            sequence.ScriptToLoad.OnStart();

            Debug.Log(" Key Position : " + sequence.Key + " Value Position : " + sequence.ScriptToLoad);
        }
    }


    private void OnApplicationQuit()
    {
        if (StartUpSequence != null)
        {
            StartUpSequence.Clear();
            StartUpSequence = null;
        }
    }

    private void OnDisable()
    {
        if (StartUpSequence != null)
        {
            StartUpSequence.Clear();
            StartUpSequence = null;
        }        
    }

    private void OnEnable()
    {
        DontDestroyOnLoad(this);
    }
}
