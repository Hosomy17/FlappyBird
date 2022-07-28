using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioSource;

    public void OnClickPlay()
    {
        AudioSource.PlayClipAtPoint(_audioSource, Vector3.zero);
        
        FlowController.Global.OpenGame();
    }
    
}
