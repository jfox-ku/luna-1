using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DmgPopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private Color textColor;
    public float moveSpeed = 2f;
    public float lifeTime = 1f;
    public float dissapearSpeed = 0.2f;

    public static DmgPopUp Create(Vector3 pos,int dmgAmount) {
        Transform t = Instantiate(GameAssets.i.dmgPopUp,pos,Quaternion.identity);
        DmgPopUp pu = t.GetComponent<DmgPopUp>();
        pu.SetUp(dmgAmount);
        return pu;

    }



    public void SetUp(int damageAmount) {
        textMesh.SetText(damageAmount.ToString());
        textColor = textMesh.color;
    }



    private void Awake() {
        textMesh = GetComponent<TextMeshPro>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveUp();
        FadeAndDestroy();
    }


    private void FadeAndDestroy() {
        
        if (lifeTime < 0) {
            textColor.a -= dissapearSpeed * Time.deltaTime;
            if (textColor.a < 0) Destroy(gameObject);
            else textMesh.color = textColor;

            
        } else {

            lifeTime -= Time.deltaTime;
        }

    }


    private void MoveUp() {
        transform.position += new Vector3(0,moveSpeed) * Time.deltaTime;
    }
}
