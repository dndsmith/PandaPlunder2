using UnityEngine;
using System.Collections;

public class DestroyOnHideProgramCard : MonoBehaviour
{
    public ProgramCardInteractable PCI;
    public GameObject[] objectsToDestroy;

    void Start()
    {
        FindObjectOfType<ProgramCardViewer>().HideProgramCard += C_OnHideProgramCard;
    }

    public void C_OnHideProgramCard(object sender, HideProgramCardEventArgs e)
    {
        if (PCI == e.programCard)
        {
            foreach(GameObject obj in objectsToDestroy)
                if(obj != null) Destroy(obj);
        }
    }
}
