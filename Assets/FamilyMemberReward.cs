using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FamilyMemberReward : MonoBehaviour
{
    public Trunk familyTrunk;

    public GameObject reward;
    public TextMeshPro owner;
    public Transform rewardLocation;
    public Animator animator;

    private void Start()
    {
        owner.text = familyTrunk.owner;
        reward = familyTrunk.content;
        Instantiate(reward, rewardLocation.position, rewardLocation.rotation);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Family"))
        {
            animator.Play("OpenTrunkAnimation");
        }
    }
}
