using System.Collections;
using Objects;
using Objects.Portal;
using UnityEngine;

namespace Player
{
    public class PlayerTrigger: MonoBehaviour
    {
        [SerializeField] private PlayerModel player;
        

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CoinPrefab coin))
            {
                player.Coin++;
                Destroy(coin.gameObject);
            }
            else if(other.TryGetComponent(out BombPrefab bomb))
            {
                player.Health--;
                Destroy(bomb.gameObject);
            }
            else if(other.TryGetComponent(out HealthRecoveryPrefab healthRecovery))
            {
                player.Health++;
                Destroy(healthRecovery.gameObject);
            }
            else if(other.TryGetComponent(out FreezeBombPrefab freezeBombPrefab))
            {
                ActivateDeceleration();
                Destroy(freezeBombPrefab.gameObject);
                StartCoroutine(nameof(DeactivateDeceleration));
            }
            else if(other.TryGetComponent(out PortalPrefab portalPrefab))
            {
                
            }
        }

        
        private void ActivateDeceleration() =>  player.ActiveDeceleration = true;
        private IEnumerator DeactivateDeceleration()
        {
            yield return new WaitForSeconds(5f);
            player.ActiveDeceleration = false;
        }
    }
}