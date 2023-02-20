/*** 
 * @Author: yeyuezhouxing 1751826093@qq.com
 * @Date: 2022-11-22 10:50:51
 * @LastEditors: yeyuezhouxing 1751826093@qq.com
 * @LastEditTime: 2023-02-21 03:00:49
 * @FilePath: \DarkSouls\Assets\ActorController.cs
 * @Description: 
 * @
 * @Copyright (c) 2023 by ${git_name_email}, All Rights Reserved. 
 */
/*
 * @Author: yeyuezhouxing 1751826093@qq.com
 * @Date: 2022-11-22 10:50:51
 * @LastEditors: yeyuezhouxing 1751826093@qq.com
 * @LastEditTime: 2022-11-28 16:32:22
 * @FilePath: \DarkSouls\Assets\ActorController.cs
 * @Description: 
 * 
 * Copyright (c) 2022 by yeyuezhouxing 1751826093@qq.com, All Rights Reserved. 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ActorController : MonoBehaviour
{
    public GameObject model;
    public PlayerInput pi;

    /// <summary>
    /// 角色行走速度
    /// </summary>
    public float walkSpeed;

    [SerializeField]
    private Animator anim;
    private Rigidbody rigid;
    
    /// <summary>
    /// 模型移动向量
    /// </summary>
    private Vector3 movingVec;

    // Start is called before the first frame update
    void Awake()
    {
        pi = GetComponent<PlayerInput>();
        anim = model.GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("forward",pi.Dmag);
        if(0.1f < pi.Dmag)
        {
            model.transform.forward = pi.Dvec;
        }
        movingVec = pi.Dmag * model.transform.forward * walkSpeed;
    }

    void FixedUpdate()
    {
        rigid.position += movingVec * Time.fixedDeltaTime;
    }
}
