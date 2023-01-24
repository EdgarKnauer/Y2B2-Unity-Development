using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public GameObject flask;
    [SerializeField] GameObject arm;
    private bool isTrigger;
    private Animator _animator;


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(isTrigger == true)
        {
            flask.transform.position = arm.transform.position + new Vector3(0, 0, -0.2f);
            //flask.transform.position = new Vector3(0, 0, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShakingFlask")
        {
            flask = other.gameObject;
            isTrigger = true;
            flask.transform.parent = arm.transform;
            _animator.SetTrigger("StartAnim");
            StartCoroutine(AnimEnd());
        }
    }

    private IEnumerator AnimEnd()
    {
        yield return new WaitForSeconds(3);
        isTrigger = false;
        _animator.SetTrigger("StopAnim");
        flask.transform.parent = null;
    }
}
