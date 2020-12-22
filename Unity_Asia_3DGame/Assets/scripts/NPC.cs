using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;

    public bool playerInArea;
    //**
    //private void Start()
    //{
       // StartCoroutine(Test());
   // }

    //private IEnumerator Test()
   // {
        //print("嗨~");
        //yield return new WaitForSeconds(1.5f);
        //print("嗨,我是一點五秒後");
    //}

        public enum NPCState
    {
        FirstDialog, Missioning, Finish
    }

    public NPCState state = NPCState.FirstDialog;

/// <summary>
/// 開始對話
/// </summary>
/// <returns></returns>
        private IEnumerator Dialog()
    {
        dialog.SetActive(true);
        textContent.text = "";
        textName.text = name;

        string dialogString = data.dialougB;

        switch(state)
        {
            case NPCState.FirstDialog:
                dialogString = data.dialougA;
                break;
            case NPCState.Missioning:
                dialogString = data.dialougB;
                break;
            case NPCState.Finish:
                dialogString = data.dialougC;
                break;
        }

        for (int i = 0; i < dialogString.Length; i++)
        {
            //print(data.dialougA[i]);
            textContent.text += dialogString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
  
/// <summary>
/// 停止對話
/// </summary>
    private void StopDialog()
    {
        dialog.SetActive(false);
        StopAllCoroutines();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "主機")
        {
            playerInArea = true;
            StartCoroutine(Dialog());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "主機")
        {
            playerInArea = false;
            StopDialog();
        }
    }
    
}
