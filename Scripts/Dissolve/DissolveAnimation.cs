using System.Collections;
using UnityEngine;

// Add method that automatically takes object's scale into account for the dissolve effect

[RequireComponent(typeof(Renderer))]
public class DissolveAnimation : MonoBehaviour
{
    [Header("Shader property")]
    [SerializeField] private string cutoffProperty = "_CutoffHeight";

    [Header("Animation")]
    [SerializeField] private float speed = 2f;

    [SerializeField] private bool pingPongOnStart = false;
    
    [Header("Padding")]
    [Tooltip("Extra space in case the object moves during the dissolve")]
    [SerializeField] private float bottomPadding = 0.0f;
    [SerializeField] private float topPadding = 0.0f;

    private Renderer _renderer;
    private Material _material;
    private float _minHeight;
    private float _maxHeight;
    
    private float MinTarget => _minHeight - bottomPadding;
    private float MaxTarget => _maxHeight + topPadding;
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _material = _renderer != null ? _renderer.material : null;
        RecalculateHeights();
        SetCutoff(MinTarget);
    }

    private void OnEnable()
    {
        if (pingPongOnStart) DissolvePingPong();
    }

    private void OnValidate()
    {
        if (_renderer == null) _renderer = GetComponent<Renderer>();
        if (!Application.isPlaying)
        {
            RecalculateHeights();
            SetCutoff(MinTarget);
        }
    }

    public void RecalculateHeights()
    {
        if (_renderer == null) return;
        var b = _renderer.bounds;
        _minHeight = b.min.y;
        _maxHeight = b.max.y;
    }

    public void DissolveAppear()
    {
        if (!Validate()) return;
        StopAllCoroutines();
        StartCoroutine(AnimateCutoff(GetCutoff(), MinTarget));
    }

    public void DissolveDisappear()
    {
        if (!Validate()) return;
        StopAllCoroutines();
        StartCoroutine(AnimateCutoff(GetCutoff(), MaxTarget));
    }

    public void DissolvePingPong()
    {
        if (!Validate()) return;
        StopAllCoroutines();
        StartCoroutine(PingPongRoutine());
    }

    private IEnumerator PingPongRoutine()
    {
        float dir = Mathf.Sign(MaxTarget - GetCutoff());
        while (true)
        {
            float target = dir > 0 ? MaxTarget : MinTarget;
            yield return AnimateCutoff(GetCutoff(), target);
            dir *= -1;
        }
    }

    private IEnumerator AnimateCutoff(float from, float to)
    {
        float h = from;
        while (!Mathf.Approximately(h, to))
        {
            h = Mathf.MoveTowards(h, to, speed * Time.deltaTime);
            SetCutoff(h);
            yield return null;
        }
        SetCutoff(to);
    }

    private void SetCutoff(float value)
    {
        if (_material != null && _material.HasProperty(cutoffProperty))
            _material.SetFloat(cutoffProperty, value);
    }

    private float GetCutoff()
    {
        return _material != null && _material.HasProperty(cutoffProperty)
            ? _material.GetFloat(cutoffProperty)
            : MinTarget;
    }

    private bool Validate()
    {
        if (_material == null || !_material.HasProperty(cutoffProperty)) {
            Debug.LogWarning($"Material does not have property '{cutoffProperty}'");
            return false;
        }
        return true;
    }
    
}
