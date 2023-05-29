using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    #region Singleton
    public static CountManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }
    #endregion

    public int level = 1;
    public int countForWin;

    public bool EndCount()
    {
        if(countForWin == LevelManager.instance.count)
        {
            return true;
        }
        return false;
    }
}
