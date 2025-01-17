using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    #region States
    public StateMachine<BubbleState> stateMachine {  get; private set; }
    public BubbleState idleState {  get; private set; }
    public BubbleState floatState { get; private set; }
    public BubbleState fallState { get; private set; }
    #endregion

    #region Components
    Animator anim;
    Rigidbody2D rb;
    #endregion

    public void Awake()
    {
        #region Components
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        #endregion

        #region States
        stateMachine = new StateMachine<BubbleState>();
        idleState = new BubbleStateIdle(anim, "isIdle", this);
        floatState = new BubbleStateFloat(anim, "isFloat", this);
        fallState = new BubbleStateFall(anim, "isFall", this);
        #endregion
    }

    public void Start()
    {
        stateMachine.Initialize(idleState);
    }

    public void Update()
    {
        stateMachine.currentState.OnUpdate();
    }
}
