using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyObjects : MonoBehaviour
{
    public void Clear()
    {
        Destroy(GameObject.FindWithTag("Music"));
    }
}
