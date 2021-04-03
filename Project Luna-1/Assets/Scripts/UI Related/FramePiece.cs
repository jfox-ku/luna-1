using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FramePiece : MonoBehaviour, IDropHandler
{
    private bool IsFree=true;

    public void OnDrop(PointerEventData eventData) {
        //Debug.Log("On drop event!");
        if (eventData.pointerDrag != null) {
            //eventData.pointerDrag.GetComponent<Transform>().position = this.transform.position;
            var drgbl = eventData.pointerDrag.GetComponent<Draggable>();
            //Debug.Log(drgbl);
            if (drgbl!=null) {

                if (IsFree) {
                    IsFree = false;
                    //Debug.Log("Setting parent "+this.transform.name);
                    drgbl.setFrameParent(this);
                }

            }
        }
    }

    public void DraggableLeft() {
        IsFree = true;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
