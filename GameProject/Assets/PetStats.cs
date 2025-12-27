// PetStats.cs
using UnityEngine;

/// <summary>
/// 寵物狀態類別
/// </summary>
public class PetStats
{
    /// <summary>
    /// 飽食度
    /// </summary>
    public float hunger;

    /// <summary>
    /// 心情
    /// </summary>
    public float happiness;

    /// <summary>
    /// 體力
    /// </summary>
    public float energy;

    /// <summary>
    /// 建構一個新的 PetStats 執行個體
    /// </summary>
    /// <param name="startingHunger">初始飽食度</param>
    /// <param name="startingHappiness">初始心情</param>
    /// <param name="startingEnergy">初始體力</param>
    public PetStats(float startingHunger, float startingHappiness, float startingEnergy)
    {
        hunger = startingHunger;
        happiness = startingHappiness;
        energy = startingEnergy;
    }

    /// <summary>
    /// 隨時間減少寵物狀態
    /// </summary>
    /// <param name="decayAmount">要減少的量</param>
    public void Decay(float decayAmount)
    {
        hunger -= decayAmount;
        if (hunger < 0) hunger = 0;

        happiness -= decayAmount;
        if (happiness < 0) happiness = 0;

        energy -= decayAmount;
        if (energy < 0) energy = 0;
    }
}
