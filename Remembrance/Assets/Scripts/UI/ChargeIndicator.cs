using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ChargeIndicator : MonoBehaviour
    {
        /// <summary>
        /// Speed the indicator will move towards the center (in seconds)
        /// </summary>
        public float CloseInDuration = 1.1f;

        public float MinDistance = 80f;

        private float opacityIndex;
        private float xPositionindex;
        private float timeElapsed = 0f;
        private Vector3 startingPosition;
    
        private Image indicator;

    
        void Awake()
        {
            indicator = GetComponent<Image>();
            startingPosition = transform.localPosition;
        
            ChangeAlpha(indicator, 0f); //start transparent

            MinDistance *= Mathf.Sign(startingPosition.x);
            enabled = false;
        }

        private void OnEnable()
        {
            ResetIndicator();
        }

        // Update is called once per frame
        void Update()
        {
            if (timeElapsed < CloseInDuration)
            {
                xPositionindex = Mathf.Lerp(startingPosition.x, MinDistance, timeElapsed / CloseInDuration);
                opacityIndex = Mathf.Lerp(0f, 1f, timeElapsed / CloseInDuration);

                transform.localPosition = new Vector3(xPositionindex, transform.position.y, transform.position.z);
                ChangeAlpha(indicator, opacityIndex);
            }
            timeElapsed += Time.deltaTime;
        }

        public void ResetIndicator()
        {
            ChangeAlpha(indicator, 0f);
            transform.position = startingPosition;
            timeElapsed = 0f;
        }

        /// <summary>
        /// Calculates the percentage of how much the charge has finished charging.
        /// </summary>
        public float GetChargeMultiplier()
        {
            return timeElapsed / CloseInDuration;
        }
    
        /// <summary>
        /// Changes the Alpha on an Image
        /// </summary>
        /// <param name="image"> The Image to change the alpha in </param>
        /// <param name="alpha"> The alpha value to set </param>
        private void ChangeAlpha(Image image, float alpha)
        {

            Color tempColor = image.color;
            tempColor.a = alpha;
            image.color = tempColor;
        }
    }
}
