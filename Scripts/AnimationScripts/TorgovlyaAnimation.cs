using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TorgovlyaAnimation : MonoBehaviour
{
    Animator torgAnim;
    public bool animPlay = true;
    MoneyScript moneyScr;

    // Start is called before the first frame update
    void Start()
    {
        torgAnim = GetComponent<Animator>();
        moneyScr = FindObjectOfType<MoneyScript>().GetComponent<MoneyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        float distance = Vector3.Distance(transform.position, mousePos);
        Debug.Log(distance);

        if (distance < 25f && animPlay)
        {
            torgAnim.SetBool("jump",true);
        }
        else
        {
            torgAnim.SetBool("jump",false);
        }
        if (Input.GetMouseButtonDown(0) && distance < 25 && animPlay)
        {
            torgAnim.SetTrigger("pressed");
            Invoke("ReplayAnim", 0.6f);
        }
    }

    void ReplayAnim()
    {
        if (animPlay)
        {
            torgAnim.Play("HighlightedCheck");
        }
    }
}
