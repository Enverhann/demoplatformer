using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintWall : MonoBehaviour
{
    public GameObject Brush;
    public float brushSize = 0.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //paint the wall with mouse touches/swerve mechanic
        if (Input.GetMouseButton(0))
        {
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(Ray, out hit))
            {
                var go = Instantiate(Brush, hit.point + Vector3.up * 0.1f,Quaternion.identity,transform);
                go.transform.localScale = Vector3.one * brushSize;
            }
        }
    }
}
