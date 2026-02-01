using System.Data;
using UnityEngine;

public class MaskBuilder : MonoBehaviour
{
    [SerializeField] Transform crownPivot;
    [SerializeField] Transform facePivot;
    [SerializeField] Transform teethPivot;
    [SerializeField] bool isP1;

    Sprite crown, face, teeth;



    private void Start()
    {
        if (isP1)
        {
            crown = PlayerMaskSelections.p1Sprites.crown;
            face = PlayerMaskSelections.p1Sprites.face;
            teeth = PlayerMaskSelections.p1Sprites.teeth;
        }
        else
        {

            crown = PlayerMaskSelections.p2Sprites.crown;
            face = PlayerMaskSelections.p2Sprites.face;
            teeth = PlayerMaskSelections.p2Sprites.teeth;
        }
        // CROWN
        var crownSp = new GameObject("CrownSprite", typeof(SpriteRenderer));
        crownSp.transform.SetParent(crownPivot);
        crownSp.transform.localScale = Vector3.one * 0.2f;
        crownSp.transform.localRotation = Quaternion.identity;
        crownSp.transform.localPosition = Vector3.zero;

        var crownSpR = crownSp.GetComponent<SpriteRenderer>();
        crownSpR.sprite = crown;
        crownSpR.sortingLayerName = "Foreground";
        crownSpR.sortingOrder = 101;


        // FACE
        var faceSp = new GameObject("FaceSprite", typeof(SpriteRenderer));
        faceSp.transform.SetParent(crownPivot);
        faceSp.transform.localScale = Vector3.one * 0.2f;
        faceSp.transform.localRotation = Quaternion.identity;
        faceSp.transform.localPosition = Vector3.zero;

        var faceSpR = faceSp.GetComponent<SpriteRenderer>();
        faceSpR.sprite = face;
        faceSpR.sortingLayerName = "Foreground";
        faceSpR.sortingOrder = 100;


        // TEETH
        var teethSp = new GameObject("TeethSprite", typeof(SpriteRenderer));
        teethSp.transform.SetParent(crownPivot);
        teethSp.transform.localScale = Vector3.one * 0.2f;
        teethSp.transform.localRotation = Quaternion.identity;
        teethSp.transform.localPosition = Vector3.zero;

        var teethSpR = teethSp.GetComponent<SpriteRenderer>();
        teethSpR.sprite = teeth;
        teethSpR.sortingLayerName = "Foreground";
        teethSpR.sortingOrder = 102;

    }
}
