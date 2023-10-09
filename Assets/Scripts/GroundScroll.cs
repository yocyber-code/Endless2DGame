using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    private Material bgMaterial;
    private float scrollSpeed = 1f;
    private bool isScroll = true;

    // Start is called before the first frame update
    void Awake()
    {
        bgMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (isScroll)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0f);
            bgMaterial.mainTextureOffset = offset;
        }
    }

    public void StopScroll()
    {
        isScroll = false;
    }
}
