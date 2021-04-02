using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 oldPos;
    private CanvasGroup canvasGroup;
    public FramePiece CurrentFrame;

    public bool SuccesfulDrop = false;

    private void Awake() {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData) {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.6f;
        CurrentFrame.DraggableLeft();
        oldPos = this.transform.position;
        Debug.Log("Begin drag: "+eventData.position+ ": "+this.transform.name);
    }

    public void OnDrag(PointerEventData eventData) {

        this.transform.position = new Vector3(eventData.position.x,eventData.position.y,this.transform.position.z);
    }

    public void setFrameParent(FramePiece fp) {
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
            
        } else {

        }

        this.transform.position = oldPos;

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
