using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class DragHandler_back_1 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject GameSceneScript;
    public static GameObject item;
    Vector3 startPosition;
    Transform startParent;

    public GameObject TargetCard;

    private void Awake()
    {
        GameSceneScript = GameObject.Find("GameSceneScript");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        item = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        //controller.GetComponent<Controller>().Shop.gameObject.SetActive(false);
        transform.SetParent(transform.root);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        item = null;

        if (TargetCard != null)
        {
            print(TargetCard.name);


            transform.SetParent(TargetCard.transform.parent);
            TargetCard.transform.SetParent(startParent);

        }
        else if (transform.parent == startParent || transform.parent == transform.root)
        {
         //   transform.position = startPosition;
            transform.SetParent(startParent);
        }

    }

    public void OnDrag(PointerEventData eventData)
    {


        // if ((Count_Friend < 6) && (controller.GetComponent<Controller>()._money >= _price_unit))
        //  {
        transform.position = Input.mousePosition;
        //  }
        //   if (transform.parent == startParent || transform.parent == transform.root)
        //   {
        //      transform.position = startPosition;
        //      transform.SetParent(startParent);
        //  }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Hand_btn")
        {
            //print("OnTriggerStay2D " + collision.name);
            GameSceneScript.GetComponent<GameSceneScript>().GoHand();
        }
      //  print(collision.name);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        TargetCard = null;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        //print(collision.name);
        TargetCard = collision.gameObject;
    }
}