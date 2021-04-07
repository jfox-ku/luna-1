using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.UI;

public class FramePiece : MonoBehaviour, IDropHandler
{
    [SerializeField]public static List<FramePiece> FramesList;
    //public static void AddTo(FramePiece fp) {
    //    FramesList.Add(fp);
    //}

    //public static void RemoveFrom(FramePiece fp) {
    //    FramesList.Remove(fp);
    //}

    public static void ActivateIndex(int i) {
        FramesList[i].CardActivate();
    }



    private bool IsFree=true;
    [SerializeField] private Draggable currentCard;
    [SerializeField] private int Index;
    public Action<int,Draggable> CardActivateEvent;

    private void Awake() {
        UIImage = GetComponent<Image>();
        oldImgColor = UIImage.color;

        if (FramesList == null) FramesList = new List<FramePiece>();
        //This might break indexing ._.
        FramesList.Add(this);
        //**
        Debug.Log(FramesList.ToArray());

    }
    private Image UIImage;
    private Color oldImgColor;
    public Color ActivationImageColor;
    public float ActivationLength;

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
                    currentCard = drgbl;
                    drgbl.setFrameParent(this);
                }

            }
        }
    }

    public void DraggableLeft() {
        IsFree = true;
        currentCard = null;
    }

   public void CardActivate() {
        StartCoroutine(ShowActivation());
        if (currentCard != null) {
            
            CardActivateEvent?.Invoke(Index,currentCard);

        }
    }




    private IEnumerator ShowActivation() {
        
        UIImage.color = ActivationImageColor;
        yield return new WaitForSeconds(ActivationLength);
        UIImage.color = oldImgColor;

    }


 
}
