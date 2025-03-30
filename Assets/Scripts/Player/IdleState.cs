using System.Data;
using UnityEngine;

public class IdleState : State
{
    // Controlador do player
    public ControllerPlayer controller;
    
    // Construtor
    public IdleState(ControllerPlayer controllerPlayer) : base("IdleState")
    {
        this.controller = controllerPlayer;
    }

    // ENTRAR NO ESTADO
    public override void Enter()
    {
        base.Enter();
    }

     public override void Exit(){

        base.Exit();
    }

    public override void Update()
    {
        Debug.Log("--TESTE--");

        if(controller.moveV != 0 || controller.moveH != 0){
            controller.stateMachine.ChangeState(controller.walkingState);
        }
        base.Update();
    }
}
