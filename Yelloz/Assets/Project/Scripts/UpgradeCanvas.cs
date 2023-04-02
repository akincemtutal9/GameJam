using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeCanvas : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    private Player player;
    private TopDownMovement topDownMovement;
    private WeaponController weaponController;    
    [SerializeField] private GameObject upgradeCanvas;
    [SerializeField] private Button increaseHealthButton;
    [SerializeField] private Button movementSpeedButton;
    [SerializeField] private Button critChanceButton;
    [SerializeField] private Button attackDamageButton;

    private void Start(){
        player = Player.GetComponent<Player>();
        topDownMovement = Player.GetComponent<TopDownMovement>();
        weaponController = Player.GetComponent<WeaponController>();
        upgradeCanvas.SetActive(false);
    }

    public void HideUpgradeCanvas(){
        // Hide the canvas and resume the game time
        upgradeCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CritChance(){
        weaponController.CritChance += 0.1f;
        HideUpgradeCanvas();
    }

    public void MovementSpeed(){
        topDownMovement.Speed += 1f;
        HideUpgradeCanvas();
    }

    public void AttackDamage(){
        weaponController.AttackDamage += 5;
        HideUpgradeCanvas();
    }

    public void IncreaseHealth(){
        player.CurrentHealth += 10;
        player.MaxHealth += 10;
        HideUpgradeCanvas();
    }
}
