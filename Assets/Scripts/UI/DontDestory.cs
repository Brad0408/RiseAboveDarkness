using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class DontDestory : MonoBehaviour
{
    public static DontDestory Instance;

    public GameObject WholeCanvas;

    void Awake()
    {
        //Create Instance If There Isn't One
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public GameObject menu()
    {
        return WholeCanvas;
    }
}
