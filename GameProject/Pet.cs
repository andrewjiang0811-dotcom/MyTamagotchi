using UnityEngine;

public class Pet : MonoBehaviour
{
    [Header("角色狀態")] 
    [SerializeField] private float hunger = 100f;    // 飽食度
    [SerializeField] private float happiness = 100f; // 心情
    [SerializeField] private float energy = 100f;    // 體力

    [Header("隨時間減少的速度")]
    public float decayRate = 2.0f; // 每秒扣多少數值

    void Update()
    {
        // Time.deltaTime 是為了讓數值減少的速度不受電腦效能影響
        hunger -= decayRate * Time.deltaTime;
        happiness -= decayRate * Time.deltaTime;
        energy -= decayRate * Time.deltaTime;

        // 簡單的防呆，不要減到變成負數
        if (hunger < 0) hunger = 0;
        if (happiness < 0) happiness = 0;
        if (energy < 0) energy = 0;
    }

    // 這是給按鈕呼叫的方法
    public void Feed()
    {
        hunger += 10f;
        if (hunger > 100f) hunger = 100f;
        
        Debug.Log("餵食成功！現在飽食度：" + hunger);
    }

     // === 存檔功能 ===
    public void SaveData()
    {
        // PlayerPrefs.SetFloat("鑰匙名稱", 數值);
        // 這行程式碼會把現在的 hunger 數值寫入硬碟
        PlayerPrefs.SetFloat("SavedHunger", hunger);
        PlayerPrefs.SetFloat("SavedHappiness", happiness);
        PlayerPrefs.SetFloat("SavedEnergy", energy);
        
        // 這一行是強制存檔（雖然 Unity 關掉時通常會自動存，但保險起見）
        PlayerPrefs.Save();
        
        Debug.Log("資料已儲存！");
    }

    // === 讀取功能 ===
    public void LoadData()
    {
        // PlayerPrefs.GetFloat("鑰匙名稱", 預設值);
        // 如果找不到 "SavedHunger" (例如第一次玩)，就會給預設值 100
        hunger = PlayerPrefs.GetFloat("SavedHunger", 100f);
        happiness = PlayerPrefs.GetFloat("SavedHappiness", 100f);
        energy = PlayerPrefs.GetFloat("SavedEnergy", 100f);
        
        Debug.Log("資料已讀取！");
    }
}