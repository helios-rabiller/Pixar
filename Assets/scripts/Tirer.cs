using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tirer : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    public float bulletforce;

    public int munitionsMaxChargeur = 10; 
    public int munitionsTotalesMax = 90;  
    public float tempsRechargement = 1.5f; 

    
    private int munitionsChargeur;
    private int munitionsTotales;
    private bool estEnRechargement = false;

  
    void Start()
    {

        munitionsChargeur = munitionsMaxChargeur;
        munitionsTotales = munitionsTotalesMax;
        
        // Afficher l'état initial dans la console
        Debug.Log($"Munitions initiales: {munitionsChargeur}/{munitionsTotales}");
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Gérer le Tir (Clic Gauche)
        if (Input.GetKeyDown(KeyCode.Mouse0) && !estEnRechargement)
        {
            if (munitionsChargeur > 0)
            {
                Shoot();
            }
            else
            {
                Debug.Log("Chargeur vide. Veuillez recharger.");
            }
        }
        
        // 2. Gérer le Rechargement (Touche R)
        if (Input.GetKeyDown(KeyCode.R) && !estEnRechargement)
        {
            // Vérifie s'il manque des balles dans le chargeur ET s'il reste des balles totales
            if (munitionsChargeur < munitionsMaxChargeur && munitionsTotales > 0)
            {
                StartCoroutine(Recharger());
            }
            else if (munitionsTotales == 0)
            {
                Debug.Log("Plus de munitions de réserve.");
            }
        }

    }

    void Shoot()
    {
        // Logique de tir existante
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(shootPoint.up * bulletforce, ForceMode2D.Impulse);
        Destroy(projectile, 5.0f);
        
        // Décrémenter le compteur
        munitionsChargeur--;
        
        Debug.Log($"Tir effectué. Munitions restantes: {munitionsChargeur}/{munitionsTotales}");
    }
    
    // Coroutine pour gérer le délai de rechargement
    IEnumerator Recharger()
    {
        estEnRechargement = true;
        Debug.Log("Rechargement en cours...");

        yield return new WaitForSeconds(tempsRechargement);

        // Calcul des balles à transférer
        int ballesManquantes = munitionsMaxChargeur - munitionsChargeur;
        int ballesATransferer = Mathf.Min(ballesManquantes, munitionsTotales);

        munitionsChargeur += ballesATransferer;
        munitionsTotales -= ballesATransferer;

        estEnRechargement = false;
        Debug.Log($"Rechargement terminé. Nouvelles munitions: {munitionsChargeur}/{munitionsTotales}");
    }
}