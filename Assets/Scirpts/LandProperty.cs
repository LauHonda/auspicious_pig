﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandProperty : MonoBehaviour {

    public class Kaiken
    {
        public bool isKaiken;
    }
    public class Bozhong
    {
        public bool isBoZhong;
    }
	public Dictionary<string, string> Message = new Dictionary<string, string>();

    public GameObject IsKaiKenLand;
    public GameObject NoKaiKenLand;

    public GameObject IsBoZhong;

    public Kaiken KaiKen_ = new Kaiken();
    public Bozhong Bozhong_ = new Bozhong();

    public Material SelfMaterial;
    public Material SaveSelfMaterial;

	public int i;

	public GameObject TuDiObj;


    public Material SelfMaterial_
    {
        get
        {
            return SelfMaterial;
        }
        set
        {
            SaveSelfMaterial = SelfMaterial;
            SelfMaterial = value;
        }
    }

    public string GetValue(string Name)
    {
        string ValueGet = null;
        Message.TryGetValue(Name, out ValueGet);
        return ValueGet;
    }
    public void AddValue(string Name, string ValueAdd)
    {
        string a = GetValue(Name);
        if (a == null)
            Message.Add(Name, ValueAdd);
    }

    // Use this for initialization

    private void Start()
    {
        SelfMaterial_ = GetMaterial();
    }

    void Test()
    {
		if (Message.Count != 0)
			KaiKen_.isKaiken = true;
		else
        KaiKen_.isKaiken = false;
		if (GetTreeMessage ("cf_jinbi") == "0") 
		{
			Bozhong_.isBoZhong = false;
		}
		else
			Bozhong_.isBoZhong = true;    
    }

    public void Refresh()
    {
		Test();
		TuDiKaiKen(KaiKen_.isKaiken);
		TuDiBozhong(Bozhong_.isBoZhong);
    }

    public void ResetLand()
    {
        Message.Clear();
        KaiKen_.isKaiken = false;
        Bozhong_.isBoZhong = false;
        TuDiKaiKen(KaiKen_.isKaiken);
        TuDiBozhong(Bozhong_.isBoZhong);
    }

    public void TuDiKaiKen(bool isLand)
    {
        if (isLand)
        {
            SetActive(IsKaiKenLand,true);
            SetActive(NoKaiKenLand,false);
        }
        else
        {
            SetActive(IsKaiKenLand, false);
            SetActive(NoKaiKenLand, true);
        }
    }

    public void TuDiBozhong(bool isLand)
    {
        if (isLand)
        {
            this.IsBoZhong.gameObject.SetActive(true);
        }
        else
        {
            this.IsBoZhong.gameObject.SetActive(false);
        }
    }

    Material GetMaterial()
    {
		return TuDiObj.transform.GetComponent<Renderer>().material;
    }

    void SetActive(GameObject obj,bool TF)
    {
        if (!TF)
            if (SaveSelfMaterial)
            {
			TuDiObj.transform.GetComponent<Renderer>().material = SaveSelfMaterial;
            }
       

        obj.SetActive(TF);
    }

    GameObject GetLand()
    {

        if (IsKaiKenLand.activeSelf || NoKaiKenLand.activeSelf)
        {
            if (IsKaiKenLand.activeSelf)
                return IsKaiKenLand;
            else
                return NoKaiKenLand;
        }
        else
            return null;
    }

    public void SetMaterial(Material newMaterial)
    {
        if (GetLand())
        {
			TuDiObj.transform.GetComponent<Renderer>().material = newMaterial;
            SelfMaterial_ = newMaterial;
        }
    }

	public string GetTreeMessage(string message)
	{
		string GetTreeValue = null;
		Message.TryGetValue(message, out GetTreeValue);
		return GetTreeValue;
	}
}
