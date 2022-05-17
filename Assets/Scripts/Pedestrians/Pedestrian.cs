using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    [SerializeField] protected Vector3 start;
    [SerializeField] protected Vector3 finish;
    [SerializeField] protected Animator animator;
    [SerializeField] protected float time;
    void Start()
    {
        Behavor();
    }

    public void Behavor()
    {
        FindPosition();
        if (Random.Range(0, 10) % 2 == 0)
        {
            ToStop();
        }
        else
        {
            transform.DOMove(finish, time).SetEase(Ease.Linear).OnComplete(() => ToStop());
        Debug.Log($"{finish}");
        }
    }

    protected virtual void FindPosition()
    {
        var pos =  Random.Range(start.x, finish.x);

        transform.position = new Vector3(pos, 0, start.z);
    }

    public void ToStop()
    {
        animator.SetTrigger("Stop");
    }
}
