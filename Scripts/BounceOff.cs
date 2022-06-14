using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOff : MonoBehaviour
{
  public float bounciness;
  public bool verticalBounce;
  void OnCollisionStay2D(Collision2D obj)
  {
    if(obj.gameObject.name == "Player" && verticalBounce)
    {
      CharacterController playerController = obj.gameObject.GetComponent<CharacterController>();
      obj.collider.attachedRigidbody.AddForce(obj.transform.right * -playerController.velocity * bounciness, ForceMode2D.Impulse);
      obj.collider.attachedRigidbody.AddForce(obj.transform.up * (bounciness * 1.5f), ForceMode2D.Impulse);
      playerController.Bounced();
    }
    else if(obj.gameObject.name == "Player")
    {
      CharacterController playerController = obj.gameObject.GetComponent<CharacterController>();
      obj.collider.attachedRigidbody.AddForce(obj.transform.right * -playerController.velocity * bounciness, ForceMode2D.Impulse);
      playerController.Bounced();
    }

  }
}
