using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private LolTower lolTower;
    private float sqrDistanceToTarget;

    void Start()
    {
        lolTower = FindObjectOfType<LolTower>();
        // StartCoroutine(WaitAndDestroy());
    }
    void Update()
    {
        Minion currentMinion = lolTower.GetCurrentMinion();

        if (currentMinion != null)
        {
            transform.position = Vector3.Lerp(transform.position, currentMinion.transform.position, Time.deltaTime * 2f);
            sqrDistanceToTarget = (currentMinion.transform.position - transform.position).sqrMagnitude;
        }

        if (sqrDistanceToTarget <= 0.3f)
        {
            Destroy(gameObject);
        }

        if (currentMinion == null)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}