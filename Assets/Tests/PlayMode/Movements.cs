using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.InputSystem;

public class Movements : InputTestFixture
{

    Keyboard keyboard;
    CharacterController controller;

    public override void Setup()
    {
        SceneManager.LoadScene("Scenes/Main");
        base.Setup();
        keyboard = InputSystem.AddDevice<Keyboard>();

        var mouse = InputSystem.AddDevice<Mouse>();
        Press(mouse.rightButton);
        Release(mouse.rightButton);
    }

    private void GetController()
    {
        var character = GameObject.Find("Character");
        controller = character.GetComponent<CharacterController>();
    }

    [UnityTest]
    public IEnumerator CheckJump()
    {
        GetController();
        Press(keyboard.spaceKey);
        yield return new WaitForSeconds(0.5f);
        Assert.That(!controller.isGrounded);
        yield return new WaitForSeconds(1);
        Assert.That(controller.isGrounded);
    }

    [UnityTest]
    public IEnumerator CheckForward()
    {
        GetController();
        for (var i = 0; i < 100; i++)
        {
            Press(keyboard.upArrowKey);
            yield return new WaitForSeconds(0.1f);
        }
        Assert.That(controller.isGrounded);
    }

}
