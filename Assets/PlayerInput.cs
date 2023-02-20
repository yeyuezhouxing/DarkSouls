/*
 * @Author: yeyuezhouxing 1751826093@qq.com
 * @Date: 2022-11-21 15:58:36
 * @LastEditors: yeyuezhouxing 1751826093@qq.com
 * @LastEditTime: 2022-11-28 16:56:12
 * @FilePath: \DarkSouls\Assets\PlayerInput.cs
 * @Description: 
 * 
 * Copyright (c) 2022 by yeyuezhouxing 1751826093@qq.com, All Rights Reserved. 
 */
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [Header("按键")]
    //移动按键
    public string keyUp = "w";
    public string keyDown = "s";
    public string keyLeft = "a";
    public string keyRight = "d";

    //技能按键
    public string keyA;
    public string keyB;
    public string keyC;
    public string keyD;
    
    [Header("输出信号")]
    public float Dup;
    public float Dright;
    public bool Drun;
    
    /// <summary>
    /// 移动向量的模长
    /// </summary>
    public float Dmag;

    /// <summary>
    /// 移动向量
    /// </summary>
    public Vector3 Dvec;

    [Header("其他")]
    //按键输入开关
    public bool inputEnabled = true;

    private float targetDup;
    private float targetDright;
    private float velocityDup;
    private float velocityDright;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //关闭输入功能
        if(false == inputEnabled)
        {
            targetDup = 0;
            targetDright = 0;
        }
        else
        {
            //按键输入转换为数字信号
            targetDup = Convert.ToSingle(Input.GetKey(keyUp)) - Convert.ToSingle(Input.GetKey(keyDown));
            targetDright = Convert.ToSingle(Input.GetKey(keyRight)) - Convert.ToSingle(Input.GetKey(keyLeft));
        }

        //平滑移动
        Dup = Mathf.SmoothDamp(Dup,targetDup,ref velocityDup,0.1f);
        Dright = Mathf.SmoothDamp(Dright,targetDright,ref velocityDright,0.1f);

        Dmag = Mathf.Sqrt(Dup * Dup + Dright * Dright);
        Dvec = Dup * transform.forward + Dright * transform.right;

    }
}