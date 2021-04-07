using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 oldPos;
    private CanvasGroup canvasGroup;
    public FramePiece CurrentFrame;

    public AttackSO attackData;

    public bool SuccesfulDrop = false;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        CurrentFrame.DraggableLeft();
        oldPos = this.transform.position;
        //Debug.Log("Begin drag: "+eventData.position+ ": "+this.transform.name);
    }

    public void OnDrag(PointerEventData eventData) {
        //ugly af, but its fine, I will fix this. Some day xd
        if(canvasGroup.alpha != 0.6f) canvasGroup.alpha = 0.6f;
        this.transform.position = new Vector3(eventData.position.x,eventData.position.y,this.transform.position.z);
    }

    public void setFrameParent(FramePiece fp) {
        if(fp != CurrentFrame) {
            CurrentFrame.DraggableLeft();
        }
            SuccesfulDrop = true;
            CurrentFrame = fp;
            oldPos = CurrentFrame.transform.position;
       

    }

    public void OnEndDrag(PointerEventData eventData) {
        StartCoroutine(CheckValidDrop());
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    private IEnumerator CheckValidDrop() {
        yield return new WaitForSeconds(0.05f);
        if (SuccesfulDrop) {
            SuccesfulDrop = false;
        } 
        this.transform.position = oldPos;

    }

    public void OnPointerEnter(PointerEventData eventData) {
        canvasGroup.alpha = 0.8f;
    }

    public void OnPointerExit(PointerEventData eventData) {
        canvasGroup.alpha = 1f;
    }
}
