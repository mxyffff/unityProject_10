using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfLikeBar : MonoBehaviour
{
    //public static ProfLikeBar pl;
    public static int likedegree = 10;

    public int mxlikedegree = 100;

    public Slider ldslider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ldslider.value = (float)likedegree / mxlikedegree;
    }
}
