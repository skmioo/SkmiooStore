using UnityEngine;
using UnityEngine.UI;
using Datas;
using System;
using System.Collections;
using System.Collections.Generic;

public class SliderText : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField oText;
    private Slider m_oSilder;
    private ModeData modeData;
    private void Awake()
    {
        m_oSilder = GetComponent<Slider>();
    }
    private void Start()
    {
        m_oSilder.onValueChanged.AddListener(OnSilderChange);

        modeData = DataManager.Instance.modeData;
        if(modeData != null)
        {
        	int nMaxMoney = Mathf.Min(modeData.moneyMode.count, 12000);
        	m_oSilder.maxValue = nMaxMoney;
        	if(modeData.carryBattleMoneyMode != null)
        		m_oSilder.value = modeData.carryBattleMoneyMode.count;
        }
    }
    private void OnSilderChange(float value)
    {
        AudioManager.Instance.PlayAudio(AudioName.Slider_srol, AudioType.Common);
        if (modeData == null)
    		modeData = DataManager.Instance.modeData;

    	int nMaxMoney = Mathf.Min(modeData.moneyMode.count, 12000);
        m_oSilder.maxValue = nMaxMoney;

        oText.text = "" + value;
    }

}
