// --------------------------------------------------------------------------------------------------------------------
// <copyright file=BoardPoint.cs company=League of HTC Vive Developers>
/*
11111111111111111111111111111111111111001111111111111111111111111
11111111111111111111111111111111111100011111111111111111111111111
11111111111111111111111111111111100001111111111111111111111111111
11111111111111111111111111111110000111111111111111111111111111111
11111111111111111111111111111000000111111111111111111111111111111
11111111111111111111111111100000011110001100000000000000011111111
11111111111111111100000000000000000000000000000000011111111111111
11111111111111110111000000000000000000000000000011111111111111111
11111111111111111111111000000000000000000000000000000000111111111
11111111111111111110000000000000000000000000000000111111111111111
11111111111111111100011100000000000000000000000000000111111111111
11111111111111100000110000000000011000000000000000000011111111111
11111111111111000000000000000100111100000000000001100000111111111
11111111110000000000000000001110111110000000000000111000011111111
11111111000000000000000000011111111100000000000000011110001111111
11111110000000011111111111111111111100000000000000001111100111111
11111111000001111111111111111111110000000000000000001111111111111
11111111110111111111111111111100000000000000000000000111111111111
11111111111111110000000000000000000000000000000000000111111111111
11111111111111111100000000000000000000000000001100000111111111111
11111111111111000000000000000000000000000000111100000111111111111
11111111111000000000000000000000000000000001111110000111111111111
11111111100000000000000000000000000000001111111110000111111111111
11111110000000000000000000000000000000111111111110000111111111111
11111100000000000000000001110000001111111111111110001111111111111
11111000000000000000011111111111111111111111111110011111111111111
11110000000000000001111111111111111100111111111111111111111111111
11100000000000000011111111111111111111100001111111111111111111111
11100000000001000111111111111111111111111000001111111111111111111
11000000000001100111111111111111111111111110000000111111111111111
11000000000000111011111111111100011111000011100000001111111111111
11000000000000011111111111111111000111110000000000000011111111111
11000000000000000011111111111111000000000000000000000000111111111
11001000000000000000001111111110000000000000000000000000001111111
11100110000000000001111111110000000000000000111000000000000111111
11110110000000000000000000000000000000000111111111110000000011111
11111110000000000000000000000000000000001111111111111100000001111
11111110000010000000000000000001100000000111011111111110000001111
11111111000111110000000000000111110000000000111111111110110000111
11111110001111111100010000000001111100000111111111111111110000111
11111110001111111111111110000000111111100000000111111111111000111
11111111001111111111111111111000000111111111111111111111111100011
11111111101111111111111111111110000111111111111111111111111001111
11111111111111111111111111111110001111111111111111111111100111111
11111111111111111111111111111111001111111111111111111111001111111
11111111111111111111111111111111100111111111111111111111111111111
11111111111111111111111111111111110111111111111111111111111111111
*/
//   
// </copyright>
// <summary>
//  Chinese Chess VR
// </summary>
// <author>胡良云（CloudHu）</author>
//中文注释：胡良云（CloudHu） 3/25/2017

// --------------------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// FileName: BoardPoint.cs
/// Author: 胡良云（CloudHu）
/// Corporation: 
/// Description: 
/// DateTime: 3/25/2017
/// </summary>
public class BoardPoint : MonoBehaviour {

    #region Public Variables  //公共变量区域

    [Tooltip("是否被占用")]
    public bool isOccupied;

    [Tooltip("是红方")]
    public bool isRed;

    [Tooltip("光圈预设，用于提示玩家")]
    public GameObject beamsPreb;

    [Tooltip("战斗UI预设")]
    public GameObject warUiPre;
    #endregion


    #region Private Variables   //私有变量区域

    GameObject beams,warUI;

	#endregion
	
	
	#region MonoBehaviour CallBacks //回调函数区域
	// Use this for initialization
	void Start () {
        beams = transform.FindChild("Beams(Clone)").gameObject;
        warUI = transform.FindChild("WarUI(Clone)").gameObject;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
	#endregion
	
	#region Public Methods	//公共方法区域
	
    public void Occupied()
    {
        if (beams==null)
        {
            beams= transform.FindChild("Beams(Clone)").gameObject;

        }
        if (warUI==null)
        {
            warUI= transform.FindChild("WarUI(Clone)").gameObject;
        }
        warUI.SetActive(false);
        beams.SetActive(false);
        isOccupied = true;
    }

    public void ShowBeams()
    {
        if (isOccupied) //如果这个位置已被占用，则返回
        {
            return;
        }
        if (beams==null)
        {
            beams = GameObject.Instantiate(beamsPreb, transform, false) as GameObject;

        }
        else
        {
            if (!beams.activeSelf)
            {
                beams.SetActive(true);
            }
        }

        if (warUI==null)
        {
            warUI = GameObject.Instantiate(warUiPre, transform, false) as GameObject;
            warUI.transform.localPosition = new Vector3(transform.localPosition.x,1f,transform.localPosition.z);
        }
        else
        {
            if (!warUI.activeSelf)
            {
                warUI.SetActive(true);
            }
        }
    }
	
	#endregion
	
}
