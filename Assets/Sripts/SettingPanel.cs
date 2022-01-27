using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanel : MonoBehaviour
{
    [SerializeField] private CameraController controller;
    [SerializeField] private GameObject target;
    [SerializeField] private Slider sliderX;
    [SerializeField] private float maxValueX;
    [SerializeField] private float minValueX;
    [SerializeField] private Slider sliderY;
    [SerializeField] private float maxValueY;
    [SerializeField] private float minValueY;
    [SerializeField] private Slider sliderZ;
    [SerializeField] private float maxValueZ;
    [SerializeField] private float minValueZ;
    [SerializeField] private Slider sliderT;
    [SerializeField] private float maxValueT;
    [SerializeField] private float minValueT;

    private Animator animator;
    private bool open;
    private static bool gameStart = true;
   
    void Start()
    {
        animator = GetComponent<Animator>();
        open = false;
        target.GetComponent<Renderer>().enabled = false;


        sliderX.maxValue = maxValueX;
        sliderX.minValue = minValueX;
        
        sliderY.maxValue = maxValueY;
        sliderY.minValue = minValueY;
        
        sliderZ.maxValue = maxValueZ;
        sliderZ.minValue = minValueZ;
        sliderT.maxValue = maxValueT;
        sliderT.minValue = minValueT;

        if (gameStart)
        {
            sliderX.value = 14;
            sliderY.value = 8;
            sliderZ.value = -.75f;
            sliderT.value = 2;
        }
        else
        {
            sliderX.value = controller.xPos;
            sliderY.value = controller.yPos;
            sliderZ.value = controller.zPos;
            sliderT.value = controller.zPosTarget;
        }
    }

    public void Click()
    {
        if (!open)
        {
            open = true;
            animator.SetBool("Open", true);
            target.GetComponent<Renderer>().enabled = true;
        }
        else
        {
            open = false;
            animator.SetBool("Open", false);
            controller.SaveCamera();
            gameStart = false;
            target.GetComponent<Renderer>().enabled = false;
        }
    }
    void Update()
    {
        controller.xPos = sliderX.value;
        controller.yPos = sliderY.value;
        controller.zPos = sliderZ.value;
        controller.zPosTarget = sliderT.value;
    }
}
