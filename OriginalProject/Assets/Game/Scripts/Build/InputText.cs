using UnityEngine;
using UnityEngine.UI;
using Datas;
using System;
using System.Collections;
using System.Collections.Generic;

public class InputText : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider oSilder;
    private InputField m_oInputField;
    private ModeData modeData;
    private void Awake()
    {
        m_oInputField = GetComponent<InputField>();
        m_oInputField.text = "0";
    }
    private void Start()
    {
        m_oInputField.onValueChanged.AddListener(OnValueChange);
        modeData = DataManager.Instance.modeData;
    }
    private void OnValueChange(string value)
    {
    	if(modeData == null)
    		modeData = DataManager.Instance.modeData;

    	int nMaxMoney = Mathf.Min(modeData.moneyMode.count, 12000);
        int nInputNum = Convert.ToInt32(value);
        if(nInputNum < 0)
            nInputNum = 0;
        else if(nInputNum > 0 && nInputNum > nMaxMoney)
            nInputNum = nMaxMoney;
        
        m_oInputField.text = "" + nInputNum;
        oSilder.value = nInputNum;

        Camp.Instance.SetCarryBattleMoney(nInputNum);
    }

}
