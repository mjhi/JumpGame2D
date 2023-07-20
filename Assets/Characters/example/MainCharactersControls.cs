using Assets.Characters;
using UnityEngine;
using AnimationState = Assets.Characters.MainAnimationState;

namespace Assets.Characters {
    public class MainCharactersControls : MonoBehaviour
    {
        [SerializeField]private Rigidbody2D rigid;
        public MainCharacter Character;
        bool isJump=false;
        public float jumpPower = 0.0f;
        
    
    
    
        public void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            Debug.Log(GameManager.instance.isPlay);
            Character.SetState(MainAnimationState.Idle);
        }

        public void Update()
        {
            
            if(GameManager.instance.isPlay){
                Debug.Log("ww");
                if (Input.GetMouseButtonDown(0))
                {
                    Jump();
                    
                }
                else{
                    Character.SetState(MainAnimationState.Running);
                }

            }
        }

            
            


        void Jump()
        {
            
                if(!isJump){
                    isJump=true;
                    rigid.AddForce(Vector3.up*jumpPower,ForceMode2D.Impulse);
                    Character.SetState(MainAnimationState.Jumping);
                }
                
            
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag=="Floor")
            {
                isJump=false;
                if(GameManager.instance.isPlay){Character.SetState(MainAnimationState.Running);}
            }
        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag=="Mob")
            {
                Character.SetState(MainAnimationState.Dead);
                GameManager.instance.GameOver();
            }
        }
}
}




