using UnityEngine;

public class SkillSplashBlaster : SkillObject
{
    Rigidbody _rigidbody;
    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public override void Act(SkillSO data)
    {
        
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.AddForce(transform.forward * data.speed, ForceMode.Impulse);
        Invoke("Destroy", data.duration);
    }

    void Destroy()
    {
        // TODO : 오브젝트 풀에 넣을 것
        Destroy(gameObject);
    }
}