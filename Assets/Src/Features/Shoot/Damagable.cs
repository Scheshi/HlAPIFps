using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


namespace Src.Features.Shoot
{
    public class Damagable: NetworkBehaviour
    {
        [SerializeField] private int maxHp;
        [SerializeField] private Text hpText;
        [SyncVar(hook = nameof(OnDamage))] private int currentHp;

        private void Start()
        {
            currentHp = maxHp;
            hpText.text = currentHp.ToString();
            if(!isLocalPlayer)
                hpText.gameObject.SetActive(false);
        }
        
        public void DamageAuthoritary(int damage)
        {
            currentHp -= damage;
            hpText.text = currentHp.ToString();
            if(currentHp <= 0)
                connectionToClient.Disconnect();
        }

        private void OnDamage()
        {
            hpText.text = currentHp.ToString();
        }
    }
}