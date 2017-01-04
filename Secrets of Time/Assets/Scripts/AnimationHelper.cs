#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AnimationHelper : EditorWindow {

    public GameObject Target;
    public AnimationClip idle;
    public AnimationClip choose;
    public AnimationClip teleporting;
    
    [MenuItem ("Window/Animation Helper")]
    static void OpenWindow ()
    {
        GetWindow<AnimationHelper>();
    }

    void OnGUI()
    {
        Target = EditorGUILayout.ObjectField("Target Object", Target, typeof(GameObject), true) as GameObject;
        idle = EditorGUILayout.ObjectField("Idle", idle, typeof(AnimationClip), false) as AnimationClip;
        choose = EditorGUILayout.ObjectField("Choose", choose, typeof(AnimationClip), false) as AnimationClip;
        teleporting = EditorGUILayout.ObjectField("teleporting", teleporting, typeof(AnimationClip), false) as AnimationClip;

        if (GUILayout.Button("Create"))
        {
            if(Target == null)
            {
                Debug.Log("NO TARGET LULULULULULULUL.");
                return;
            }

            Create();
        }
    }
	
    void Create()
    {
        AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/" + Target.name + " .controller");
        controller.AddParameter("Active", AnimatorControllerParameterType.Float);
        AnimatorState idleState = controller.layers[0].stateMachine.AddState("Idle");
        idleState.motion = idle;

        BlendTree blendTree;
        AnimatorState moveState = controller.CreateBlendTreeInController("Move", out blendTree);
        blendTree.blendType = BlendTreeType.Simple1D;
        blendTree.blendParameter = "Active";
        blendTree.AddChild(choose);
        blendTree.AddChild(teleporting);

        AnimatorStateTransition leaveidle = idleState.AddTransition(moveState);
        AnimatorStateTransition leaveActive = moveState.AddTransition(idleState);

        leaveidle.AddCondition(AnimatorConditionMode.Greater, 0f, "Active");
        leaveActive.AddCondition(AnimatorConditionMode.Less, 0f, "Active");

        Target.GetComponent<Animator>().runtimeAnimatorController = controller;

    }
}
#endif