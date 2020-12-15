using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "主機")
        {
            playerInArea = true;
            Dialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "主機")
        {
            playerInArea = false;
        }
    }
    private void Dialog()
    {
        //print(data.dialougA);
        //for(int i = 0; i < 10;i++)
        //{
        //    print("我是迴圈:" + i);
        //}

        for(int i = 0; i < data.dialougA.Length; i++)
        {
            print(data.dialougA[i]);
        }
    }
}
