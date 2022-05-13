using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_HealthUI : MonoBehaviour
{
    public PlayerStats P_Stats;
    public GameObject HealthPre;
    public Transform healthPoint;

    Player_Master P_Master;
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

        P_Master = GetComponent<Player_Master>();
        
        P_Master.EventHealthUIUpdate += updateHealthUI;
    }

    void OnDisable()
    {
        P_Master.EventHealthUIUpdate -= updateHealthUI;
    }

    public void updateHealthUI()
    {
        float fAmount = P_Stats.currentHP.Value / P_Stats.maxHP.Value;

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
}
