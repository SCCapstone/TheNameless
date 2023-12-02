using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    [ContextMenu(itemName:"Open")]
    public void Open()
    {
        _animator.SetTrigger(name:"Open");
    }
}
