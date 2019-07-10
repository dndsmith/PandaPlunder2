using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// AN EVENT SOURCE
// A character controller

/* * * TODO
 * 1. OnTriggerEnter handle cases of weird Interactable component placement
 * 2. Switch from List to Dictionary for interactables (faster lookup)
 * 3. Weird things resulting from only being able to interact with one Interactable at a time and colliding with multiple interactables and ugh (need a queue?) (no, I need a moment *crunch*)
 * 4. Be able to handle more cases of interactable objects
 * */

public class PlayerController : MonoBehaviour
{
    // containers of objects
    public List<Interactable> interactables;

    // objects
    ParticleSystem particles;
    Animator animator;
    Interactable currentInteractable;
    Inventory playerInventory;

    // integers
    private const int NUM_LEVELS = 3;
    private int level = 0;

    // boolean states
    private bool isCarryingObject = false;
    private bool isDancingOne = false;
    private bool isDancingTwo = false;
    private bool isDancingThree = false;
    private bool isDancingFour = false;

    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
        playerInventory = GetComponentInChildren<Inventory>();
        currentInteractable = null;
        SetComboLevel(0);
    }

    private void Update()
    {
        // player interacts with something
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentInteractable != null)
            {
                InteractionEvent e;
                if (currentInteractable.CompareTag("Gem"))
                {
                    e = new GemEvent(InteractionEvent.Character.Player, true, !isCarryingObject, isCarryingObject, 0);
                    isCarryingObject = !isCarryingObject;
                }
                else if (currentInteractable.CompareTag("Chest"))
                    e = new ChestEvent(InteractionEvent.Character.Player, true, true, false, false, false);
                else if (currentInteractable.CompareTag("ProgramCard"))
                    e = new ProgramCardEvent(InteractionEvent.Character.Player, false, true);
                else e = new GemEvent();
                currentInteractable.ReceiveEvent(e);
            }
        }

        // Damage control: if object is being carried that doesn't exist, then it isn't carrying anything
        else if(currentInteractable == null && isCarryingObject)
        {
            isCarryingObject = !isCarryingObject;
        }

        else if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentInteractable != null)
            {
                if(currentInteractable.CompareTag("Gem"))
                {
                    GemEvent ge = new GemEvent(InteractionEvent.Character.Player, false, false, false, 0); // out of proximity to remove prompt
                    currentInteractable.ReceiveEvent(ge);
                    InventoryItemComponent item = currentInteractable.gameObject.GetComponent<InventoryItemComponent>();
                    playerInventory.Stash(item);
                }
            }
        }

        // The four dances
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchDanceOne();
        }

        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchDanceTwo();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchDanceThree();
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchDanceFour();
        }
    }

    // add an Interactable as a listener
    public void AddInteractable(Interactable I)
    {
        interactables.Add(I);
    }

    // creates an in-proximity event
    private void OnTriggerEnter(Collider other)
    {
        if (interactables.Contains(other.GetComponentInChildren<Interactable>()) || interactables.Contains(other.GetComponentInParent<Interactable>()))
        {
            if(currentInteractable == null)
            {
                Interactable I = other.GetComponentInChildren<Interactable>();
                if (I == null) I = other.GetComponentInParent<Interactable>();
                InteractionEvent e;
                if (I.CompareTag("Gem")) e = new GemEvent(InteractionEvent.Character.Player, true, false, false, 0);
                else if (I.CompareTag("Chest")) e = new ChestEvent(InteractionEvent.Character.Player, true, false, false, false, false);
                else if (I.CompareTag("StopPad")) e = new StopPadEvent(InteractionEvent.Character.Player, true);
                else if (I.CompareTag("ProgramCard")) e = new ProgramCardEvent(InteractionEvent.Character.Player, true, false);
                else e = new GemEvent();
                I.ReceiveEvent(e);
            }
            else
            {
                Interactable I = other.GetComponentInChildren<Interactable>();
                if (I == null) I = other.GetComponentInParent<Interactable>();
                if (I.CompareTag("StopPad") && !currentInteractable.CompareTag("StopPad")) Debug.Log("Plz put down " + currentInteractable.tag + " to stop activity");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("StopPad")) { }//don't interact with stop pad
        else if (interactables.Contains(other.GetComponentInChildren<Interactable>()) || interactables.Contains(other.GetComponentInParent<Interactable>()))
        {
            if (currentInteractable == null)
            {
                currentInteractable = other.GetComponentInChildren<Interactable>();
                if (currentInteractable == null) currentInteractable = other.GetComponentInParent<Interactable>();
            }
            if (other.CompareTag("Chest")) currentInteractable.ReceiveEvent(new ChestEvent(InteractionEvent.Character.Player, false, false, false, false, true));
        }
    }

    // creates an out-of-proximity event
    private void OnTriggerExit(Collider other)
    {
        if (interactables.Contains(other.GetComponentInChildren<Interactable>()) || interactables.Contains(other.GetComponentInParent<Interactable>()))
        {
            if (currentInteractable != null)
            {
                Interactable I = other.GetComponentInChildren<Interactable>();
                if (I == null) I = other.GetComponentInParent<Interactable>();
                if (currentInteractable.Equals(I))
                {
                    // Damage control: if carrying an object, put it down
                    if (isCarryingObject)
                    {
                        currentInteractable.ReceiveEvent(new GemEvent(InteractionEvent.Character.Player, true, false, true, 0));
                        isCarryingObject = !isCarryingObject;
                    }
                    currentInteractable = null;
                }
                InteractionEvent e;
                // note that the if and else statements create the same GemEvent
                if (I.CompareTag("Gem")) e = new GemEvent(InteractionEvent.Character.Player, false, false, false, 0);
                else if (I.CompareTag("Chest")) e = new ChestEvent(InteractionEvent.Character.Player, false, false, false, false, false);
                else if (I.CompareTag("ProgramCard")) e = new ProgramCardEvent(InteractionEvent.Character.Player, false, false);
                else e = new GemEvent();
                I.ReceiveEvent(e);
            }
            if (other.CompareTag("StopPad"))
            {
                Interactable I = other.GetComponentInChildren<Interactable>();
                StopPadEvent spe = new StopPadEvent(InteractionEvent.Character.Player, false);
                I.ReceiveEvent(spe);

            }
        }
    }

    private void SetComboLevel(int lvl)
    {
        level = lvl;
        TriggerEffects();
    }

    private void TriggerEffects()
    {
        if(level == 0)
        {
            particles.Stop();
        }
        else
        {
            switch (level)
            {
                case 1:
                    SetParticles(75, Color.red, 1f, false);
                    break;
                case 2:
                    SetParticles(200, new Color(0.9f, 0.6f, 0f, 1f), 1.5f, false);
                    break;
                case 3:
                    SetParticles(500, Color.yellow, 1.5f, true);
                    break;
                default:
                    break;
            }
        }
    }

    private void SetParticles(int maxParticles, Color startColor, float startSpeed, bool enableTrails)
    {
        var main = particles.main;
        var trails = particles.trails;
        main.maxParticles = maxParticles;
        main.startColor = startColor;
        main.startSpeed = startSpeed;
        trails.enabled = enableTrails;
        if (enableTrails)
            trails.inheritParticleColor = true;
        particles.Play();
    }

    // The dancing functions function as on/off switches
    private void SwitchDanceOne()
    {
        if (isDancingTwo) SwitchDanceTwo();
        if (isDancingThree) SwitchDanceThree();
        if (isDancingFour) SwitchDanceFour();
        isDancingOne = !isDancingOne;
        animator.SetBool("danceOne", isDancingOne);
    }

    private void SwitchDanceTwo()
    {
        if (isDancingOne) SwitchDanceOne();
        if (isDancingThree) SwitchDanceThree();
        if (isDancingFour) SwitchDanceFour();
        isDancingTwo = !isDancingTwo;
        animator.SetBool("danceTwo", isDancingTwo);
    }

    private void SwitchDanceThree()
    {
        if (isDancingOne) SwitchDanceOne();
        if (isDancingTwo) SwitchDanceTwo();
        if (isDancingFour) SwitchDanceFour();
        isDancingThree = !isDancingThree;
        animator.SetBool("danceThree", isDancingThree);
    }

    private void SwitchDanceFour()
    {
        if (isDancingOne) SwitchDanceOne();
        if (isDancingTwo) SwitchDanceTwo();
        if (isDancingThree) SwitchDanceThree();
        isDancingFour = !isDancingFour;
        animator.SetBool("danceFour", isDancingFour);
    }
}
