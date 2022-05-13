using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HealthUI : MonoBehaviour
{
    public EnemyStats E_Stats;
    public GameObject HealthPre;
    public Transform healthPoint;

    Enemy_Master E_Master;
    Transform ui;
    Transform healthCanvas;
    Image healthSlider, healthSlider2;
    Camera cam;

    void OnEnable()
    {
        cam = Camera.main;
        healthCanvas = GameObject.FindGameObjectWithTag(GameManager_References.healthCanvasTag).transform;

        ui = Instantiate(HealthPre, healthCanvas).transform;
        ui.forward = cam.transform.forward;
        healthSlider = ui.GetChild(1).GetComponentInChildren<Image>();
        healthSlider2 = ui.GetChild(0).GetComponentInChildren<Image>();

        E_Master = GetComponent<Enemy_Master>();
        
        E_Master.EventHealthUIUpdate += updateHealthUI;
        E_Master.EventOnEnemyDie += destroyHealth;
    }

    void OnDisable()
    {
        E_Master.EventOnEnemyDie += destroyHealth;
    }

    public void updateHealthUI(float currentHP)
    {
        float fAmount = currentHP / E_Stats.maxHP.Value;

        healthSlider.fillAmount = fAmount;
        StartCoroutine(fill(fAmount));
    }

    IEnumerator fill(float newFillAmount)
    {
        float t = 0f;
        float duration = 1f;
        float targetAmount = healthSlider.fillAmount;

        while (t <= duration)
        {
            healthSlider2.fillAmount = Mathf.Lerp(healthSlider2.fillAmount, newFillAmount, t / duration);
            t += Time.deltaTime;
            yield return null;
        }

        healthSlider2.fillAmount = targetAmount;
    }

    void LateUpdate()
    {
        ui.position = healthPoint.position;
    }

    void destroyHealth()
    {
        Destroy(ui.gameObject);
    }
}
