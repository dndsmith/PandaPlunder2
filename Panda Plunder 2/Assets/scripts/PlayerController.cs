using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Game 2

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
    //moveCharacter MC; // might use to disallow movement when dancing

    // integers & enums
    private const int NUM_LEVELS = 3;
    private int comboLevel = 0;
    private KeyCode interactKey;

    // boolean states
    private bool isCarryingObject = false;
    //private bool isDancingOne = false;
    //private bool isDancingTwo = false;
    //private bool isDancingThree = false;
    //private bool isDancingFour = false;

    private void Awake()
    {
        playerInventory = GameObject.FindGameObjectWithTag("PlayerInventory").GetComponent<Inventory>();
    }

    void Start()
    {
        particles = GetComponentInChildren<ParticleSystem>();
        animator = GetComponentInChildren<Animator>();
        //MC = GetComponentInChildren<moveCharacter>();
        // interactKey gotten from streamingassets
        interactKey = KeyCode.Space;
        currentInteractable = null;
        SetComboLevel(0);
    }

    private void Update()
    {
        // // INTERACTIONS USING E button
        if (Input.GetKeyDown(interactKey))
        {
            if(currentInteractable != null)
            {
                InteractableEvent e;
                if (currentInteractable.CompareTag("Gem"))
                {
                    //e = new GemEvent(InteractableEvent.Character.Player, true, !isCarryingObject, isCarryingObject, 0);
                    //isCarryingObject = !isCarryingObject;
                    e = new GemEvent(InteractableEvent.Character.Player, false, false, false, false, 0); // out of proximity to remove prompt
                    currentInteractable.ReceiveEvent(e);
                    InventoryItemComponent item = currentInteractable.gameObject.GetComponent<InventoryItemComponent>();
                    playerInventory.Stash(item);
                }
                else if (currentInteractable.CompareTag("Chest"))
                    e = new ChestEvent(InteractableEvent.Character.Player, true, false, true);
                else if (currentInteractable.CompareTag("ProgramCard"))
                    e = new ProgramCardEvent(InteractableEvent.Character.Player, true, false, true);
                else if (currentInteractable.CompareTag("Door"))
                    e = new DoorEvent(InteractableEvent.Character.Player, true, false, true);
                else if (currentInteractable.CompareTag("FourCorners"))
                    e = new FourCornersEvent(InteractableEvent.Character.Player, true, false, true);
                else e = new GemEvent();
                currentInteractable.ReceiveEvent(e);
            }
        }

        // Damage control: if object is being carried that doesn't exist, then it isn't carrying anything
        else if(currentInteractable == null && isCarryingObject)
        {
            isCarryingObject = !isCarryingObject;
        }

        /* INTERACTIONS USING SPACE BAR
        else if(Input.GetKeyDown(interactKey))
        {
            if(currentInteractable != null)
            {
                if(currentInteractable.CompareTag("Gem"))
                {
                    GemEvent ge = new GemEvent(InteractableEvent.Character.Player, false, false, false, 0); // out of proximity to remove prompt
                    currentInteractable.ReceiveEvent(ge);
                    InventoryItemComponent item = currentInteractable.gameObject.GetComponent<InventoryItemComponent>();
                    playerInventory.Stash(item);
                }
            }
        }*/

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
        Interactable I;
        if (interactables.Contains(other.GetComponentInChildren<Interactable>())) // look for interactable in children of collided object
            I = other.GetComponentInChildren<Interactable>();
        else if (interactables.Contains(other.GetComponentInParent<Interactable>())) // look for interactable in parent of collided object
            I = other.GetComponentInParent<Interactable>();
        else
            return; // exit if there is no interactable

        if(currentInteractable == null)
        {
            InteractableEvent e;
            if (I.CompareTag("Gem")) e = new GemEvent(InteractableEvent.Character.Player, true, false, false, false, 0);
            else if (I.CompareTag("Chest")) e = new ChestEvent(InteractableEvent.Character.Player, true, false, false);
            else if (I.CompareTag("StopPad")) e = new StopPadEvent(InteractableEvent.Character.Player, true);
            else if (I.CompareTag("ProgramCard")) e = new ProgramCardEvent(InteractableEvent.Character.Player, true, false, false);
            else if (I.CompareTag("Door")) e = new DoorEvent(InteractableEvent.Character.Player, true, false, false);
            else if (I.CompareTag("FourCorners")) e = new FourCornersEvent(InteractableEvent.Character.Player, true, false, false);
            else e = new GemEvent();
            I.ReceiveEvent(e);
        }
        else
            if (I.CompareTag("StopPad") && !currentInteractable.CompareTag("StopPad")) MessagePanelController.DisplayMessage("plz put down the object to stop timer", 3f);
    }

    // if stay inside trigger, then this is the current interactable
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
            if (other.CompareTag("Gem")) currentInteractable.ReceiveEvent(new GemEvent(InteractableEvent.Character.Player, false, true, false, false, 0));
            else if (other.CompareTag("Chest")) currentInteractable.ReceiveEvent(new ChestEvent(InteractableEvent.Character.Player, false, true, false));
            else if (other.CompareTag("ProgramCard")) currentInteractable.ReceiveEvent(new ProgramCardEvent(InteractableEvent.Character.Player, false, true, false));
            else if (other.CompareTag("Door")) currentInteractable.ReceiveEvent(new DoorEvent(InteractableEvent.Character.Player, false, true, false));
            else if (other.CompareTag("FourCorners")) currentInteractable.ReceiveEvent(new FourCornersEvent(InteractableEvent.Character.Player, false, true, false));
        }
    }

    // creates an out-of-proximity event
    private void OnTriggerExit(Collider other)
    {
        Interactable I;
        if (interactables.Contains(other.GetComponentInChildren<Interactable>())) // look for interactable in children of collided object
            I = other.GetComponentInChildren<Interactable>();
        else if (interactables.Contains(other.GetComponentInParent<Interactable>())) // look for interactable in parent of collided object
            I = other.GetComponentInParent<Interactable>();
        else
            return; // exit if there is no interactable

        // if currently interacting with something...
        if (currentInteractable != null)
        {
            // ...and if that thing we are interacting with is the collided object
            if (currentInteractable.Equals(I))
            {
                // Damage control: if carrying an object, put it down
                if (isCarryingObject)
                {
                    currentInteractable.ReceiveEvent(new GemEvent(InteractableEvent.Character.Player, true, false, false, true, 0));
                    isCarryingObject = !isCarryingObject;
                }
                currentInteractable = null;
            }
            InteractableEvent e;
            // note that the if and else statements create the same GemEvent
            if (I.CompareTag("Gem")) e = new GemEvent(InteractableEvent.Character.Player, false, false, false, false, 0);
            else if (I.CompareTag("Chest")) e = new ChestEvent(InteractableEvent.Character.Player, false, false, false);
            else if (I.CompareTag("ProgramCard")) e = new ProgramCardEvent(InteractableEvent.Character.Player, false, false, false);
            else if (I.CompareTag("Door")) e = new DoorEvent(InteractableEvent.Character.Player, false, false, false);
            else if (I.CompareTag("FourCorners")) e = new FourCornersEvent(InteractableEvent.Character.Player, false, false, false);
            else e = new GemEvent();
            I.ReceiveEvent(e);
        }

        // special case for stop pad since it is not allowed to be currentInteractable
        if (other.CompareTag("StopPad"))
        {
            StopPadEvent spe = new StopPadEvent(InteractableEvent.Character.Player, false);
            I.ReceiveEvent(spe);
        }
    }

    private void SetComboLevel(int lvl)
    {
        comboLevel = lvl;
        TriggerEffects();
    }

    private void TriggerEffects()
    {
        if(comboLevel == 0)
        {
            particles.Stop();
        }
        else
        {
            switch (comboLevel)
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
        //if (isDancingTwo) SwitchDanceTwo();
        //if (isDancingThree) SwitchDanceThree();
        //if (isDancingFour) SwitchDanceFour();
        //isDancingOne = !isDancingOne;
        animator.SetTrigger("danceOne");
    }

    private void SwitchDanceTwo()
    {
        //if (isDancingOne) SwitchDanceOne();
        //if (isDancingThree) SwitchDanceThree();
        //if (isDancingFour) SwitchDanceFour();
        //isDancingTwo = !isDancingTwo;
        animator.SetTrigger("danceTwo");
    }

    private void SwitchDanceThree()
    {
        //if (isDancingOne) SwitchDanceOne();
        //if (isDancingTwo) SwitchDanceTwo();
        //if (isDancingFour) SwitchDanceFour();
        //isDancingThree = !isDancingThree;
        animator.SetTrigger("danceThree");
    }

    private void SwitchDanceFour()
    {
        //if (isDancingOne) SwitchDanceOne();
        //if (isDancingTwo) SwitchDanceTwo();
        //if (isDancingThree) SwitchDanceThree();
        //isDancingFour = !isDancingFour;
        animator.SetTrigger("danceFour");
    }
}
