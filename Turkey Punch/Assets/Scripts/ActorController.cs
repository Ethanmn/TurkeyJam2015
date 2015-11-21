using UnityEngine;
using UnityEngine.UI;

public class ActorController : MonoBehaviour
{
    //private HeroStats stats; CHARACTER STATS

    // State the character starts in
    protected I_ActorState startState;

    // The current state
    protected I_ActorState state;
    public I_ActorState State
    {
        get { return state; }
    }

    public virtual void Start()
    {
        state = startState;
        state.OnEnter(transform);

        // Characters should set up stats here
    }

    // Update is called once per frame
    public virtual void Update()
    {
        // Update the state
        I_ActorState newState = state.HandleInput(transform);

        if (newState != null)
        {
            Debug.Log("New state is " + newState.GetType());
            SwitchState(newState);
        }

        newState = state.Update(transform, Time.deltaTime);

        if (newState != null)
        {
            SwitchState(newState);
        }
    }
    // Called once per 2 frames (on physics update)
    public virtual void FixedUpdate()
    {
        
    }

    /// <summary>
    /// Switch to a new state
    /// </summary>
    /// <param name="newState"></param>
    protected virtual void SwitchState(I_ActorState newState)
    {
        state.OnExit(transform);
        state = newState;
        state.OnEnter(transform);
    }

    /// <summary>
    /// Set this character's state
    /// </summary>
    /// <param name="newState"></param>
    public virtual void SetState(I_ActorState newState)
    {
        SwitchState(newState);
    }
}