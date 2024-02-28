using System.Linq;
using UnityEngine;
using UnityEngine.Events;

/*Quiero que este modulo solo detecte y devuelva el objetivo detectado
 * este modulo puede guardar la informacion de si el objetivo detectado
 * se ve o tiene enfrente un obstaculo*/
[RequireComponent(typeof(Actor))]
public class DetectionModule : MonoBehaviour
{
    [Tooltip("The point representing the source of target-detection raycasts for the enemy AI")]
    public Transform DetectionSourcePoint;

    [Tooltip("The max distance at which the enemy can see targets")]
    public float DetectionRange = 20f;
    /*El saber si esta dentro del rango de ataque lo quiero desde el detector
     * sino el modulo de ataque va tener que "detectar" eso y la idea es que cada
     * modulo haga solo 1 accion logica, en este caso detectar donde esta el objetivo
     * y si es atacable o hay que defenderse*/
    [Tooltip("The max distance at which the enemy can attack its target")]
    public float AttackRange = 10f;

    [Tooltip("Time before an enemy abandons a known target that it can't see anymore")]
    public float KnownTargetTimeout = 4f;

    public UnityAction onDetectedTarget;
    public UnityAction onLostTarget;

    public GameObject KnownDetectedTarget { get; private set; }
    public bool IsTargetInAttackRange { get; private set; }
    public bool IsSeeingTarget { get; private set; }
    public bool HadKnownTarget { get; private set; }

    protected float TimeLastSeenTarget = Mathf.NegativeInfinity;

    ActorsManager m_ActorsManager;

    protected virtual void Start()
    {
        m_ActorsManager = FindObjectOfType<ActorsManager>();
    }

    public virtual void HandleTargetDetection(Actor selfActor, Collider[] selfColliders)
    {
        // Handle known target detection timeout
        if (KnownDetectedTarget && !IsSeeingTarget && (Time.time - TimeLastSeenTarget) > KnownTargetTimeout)
        {
            KnownDetectedTarget = null;
        }

        // Find the closest visible hostile actor
        float sqrDetectionRange = DetectionRange * DetectionRange;
        IsSeeingTarget = false;
        float closestSqrDistance = Mathf.Infinity;
        foreach (Actor otherActor in m_ActorsManager.Actors)
        {
            if (otherActor.Affiliation != selfActor.Affiliation)
            {
                /*Es posible que en este punto quiera quedarme 
                 * con el objetivo que tenga mas serca*/
                float sqrDistance = (otherActor.transform.position - DetectionSourcePoint.position).sqrMagnitude;
                if (sqrDistance < sqrDetectionRange && sqrDistance < closestSqrDistance)
                {
                    // Check for obstructions
                    RaycastHit[] hits = Physics.RaycastAll(DetectionSourcePoint.position,
                        (otherActor.AimPoint.position - DetectionSourcePoint.position).normalized, DetectionRange,
                        -1, QueryTriggerInteraction.Ignore);
                    RaycastHit closestValidHit = new RaycastHit();
                    closestValidHit.distance = Mathf.Infinity;
                    bool foundValidHit = false;
                    foreach (var hit in hits)
                    {
                        if (!selfColliders.Contains(hit.collider) && hit.distance < closestValidHit.distance)
                        {
                            closestValidHit = hit;
                            foundValidHit = true;
                        }
                    }

                    if (foundValidHit)
                    {
                        Actor hitActor = closestValidHit.collider.GetComponentInParent<Actor>();
                        if (hitActor == otherActor)
                        {
                            IsSeeingTarget = true;
                            closestSqrDistance = sqrDistance;

                            TimeLastSeenTarget = Time.time;
                            KnownDetectedTarget = otherActor.AimPoint.gameObject;
                        }
                    }
                }
            }
        }

        IsTargetInAttackRange = KnownDetectedTarget != null &&
                                Vector3.Distance(transform.position, KnownDetectedTarget.transform.position) <=
                                AttackRange;

        // Detection events
        if (!HadKnownTarget &&
            KnownDetectedTarget != null)
        {
            OnDetect();
        }

        if (HadKnownTarget &&
            KnownDetectedTarget == null)
        {
            OnLostTarget();
        }

        // Remember if we already knew a target (for next frame)
        HadKnownTarget = KnownDetectedTarget != null;
    }
    public void ResetTarget()
    {
        KnownDetectedTarget = null;
        IsSeeingTarget = false;
        IsTargetInAttackRange = false;
    }
    public virtual void OnLostTarget() => onLostTarget?.Invoke();

    public virtual void OnDetect() => onDetectedTarget?.Invoke();
    //este metodo se usa para marcar como detectado a un enemigo que 
    //hizo daño a este individuo
    public virtual void OnDamaged(GameObject damageSource)
    {
        TimeLastSeenTarget = Time.time;
        KnownDetectedTarget = damageSource;
    }
}
