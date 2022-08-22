using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveJoyStick : JoyStick
{
    public ActorController actorController;
    public override void onJoystickDown(Vector2 V, float R)
    {
        actorController.Move(V);
    }
    public override void onJoystickUp(Vector2 V, float R)
    {
        actorController.Move(Vector2.zero);
    }

    public override void onJoystickMove(Vector2 V, float R)
    {
        actorController.Move(V);
    }
}
