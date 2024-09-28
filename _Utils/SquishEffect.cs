using UnityEngine;

namespace Utils
{
    public static class SquishEffect
    {
        public static void ApplySquishEffect(GameObject target, Vector3 originalSize)
        {
            if (LeanTween.isTweening(target))
            {
                return;
            }

            Vector3 squishSize = originalSize * 0.8f;
            Vector3 overshootSize = originalSize * 1.2f;

            LeanTween.scale(target, squishSize, 0.1f)
                .setEaseOutQuad()
                .setOnComplete(() =>
                {
                    LeanTween.scale(target, overshootSize, 0.1f)
                        .setEaseOutQuad()
                        .setOnComplete(() =>
                        {
                            LeanTween.scale(target, originalSize, 0.1f)
                                .setEaseOutQuad();
                        });
                });
        }
    }
}