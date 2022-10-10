using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class draganddrop : MonoBehaviour
{
    /*public GameObject correctForm;*/
    
    public GameObject sprite;
    public GameObject correctForm;
    private bool moving;
    private float startPosX;
    private float startPosY;
    private Vector3 resetPosition;
    private bool done;
    //public static Vector3 RotateTowards(Vector3 current, Vector3 target, float maxRadiansDelta, float maxMagnitudeDelta);
    // Start is called before the first frame update
    void Start()
    {
        resetPosition = this.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(done == false)
        {
            if (moving)
            {
                Instantiate(sprite, new Vector3(resetPosition.x, resetPosition.y, resetPosition.z), Quaternion.identity);
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                this.gameObject.transform.localPosition = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.gameObject.transform.localPosition.z);
                if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
                {
                    sprite.transform.Rotate(Vector3.forward * 10f);
                }
                if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                {
                    sprite.transform.Rotate(Vector3.forward * -10f);
                }
                


            }
        }
        


    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;
            moving = true;
        }
    }

    private void OnMouseUp()
    {
        moving = false;
        if (Mathf.Abs(this.transform.position.x - correctForm.transform.position.x) <= 0.2f &&
            Mathf.Abs(this.transform.position.y - correctForm.transform.position.y) <= 0.2f &&
            Mathf.Abs(this.transform.localRotation.z - correctForm.transform.localRotation.z) <= 0.1f)
        {
            this.transform.position = new Vector3(correctForm.transform.position.x, correctForm.transform.position.y, correctForm.transform.position.z);
            transform.rotation = correctForm.transform.rotation;
            done = true;
            FindObjectOfType<timer>().AddPoints();
            sprite.SetActive(false);
        }
        else
        {
            this.transform.localPosition = new Vector3(resetPosition.x, resetPosition.y, resetPosition.z);
        }
        
    }
}
