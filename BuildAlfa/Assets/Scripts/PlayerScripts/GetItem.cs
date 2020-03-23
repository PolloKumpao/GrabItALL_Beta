using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetItem : MonoBehaviour
{

    ObjectID objeto;
    Inventory inventory;
    public GameObject inventario;
    public TextMeshProUGUI texto;
    public GameObject paneltext;

    enemyScript enemyScript;

    private void Start()
    {
        //texto = GameObject.FindGameObjectWithTag("Feedbacktxt").GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        
        if(other.gameObject.tag == "Collectable")
        {
            paneltext.SetActive(true);
            texto.text = "Pulsa[F] para recoger";
            objeto = other.gameObject.GetComponent<ObjectID>();
            if(Input.GetKeyUp(KeyCode.F))
            {
                inventory = inventario.GetComponent<Inventory>();
                inventory.AddItem(objeto.ID);
                Destroy(other.gameObject);
                paneltext.SetActive(false);
            }
        }
        if (other.gameObject.tag == "StealRange")
        {
            enemyScript = other.gameObject.GetComponentInParent<enemyScript>();
            if (Input.GetKeyUp(KeyCode.F))
            {
                inventory = inventario.GetComponent<Inventory>();
                inventory.AddItem(enemyScript.itemEnemyID);
                Destroy(other.gameObject);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Collectable")
        {
            paneltext.SetActive(false);
            
        }
    }
}
