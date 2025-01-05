using UnityEngine;
using UnityEngine.UI;  // Для работы с UI

public class PlayerTeleport : MonoBehaviour
{
    // Точка возрождения
    private Transform respawnPoint;

    // UI элементы
    public Text deathMessageText;  // Для отображения сообщения "Ты умер"
    private bool isDead = false;

    private void Start()
    {
        // Поиск блока с тегом 'Respawn'
        GameObject respawnBlock = GameObject.FindGameObjectWithTag("Respawn");
        if (respawnBlock != null)
        {
            respawnPoint = respawnBlock.transform;
        }
        else
        {
            Debug.LogError("Точка возрождения (Respawn) не найдена! Добавьте объект с тегом 'Respawn'.");
        }

        // Прячем сообщение о смерти в начале
        if (deathMessageText != null)
        {
            deathMessageText.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверка столкновения с объектом, у которого тег 'Killer'
        if (collision.gameObject.CompareTag("Killer"))
        {
            if (!isDead)
            {
                isDead = true;
                ShowDeathMessage();
                Invoke("Teleport", 0.01f);  // Телепортируем через 1 секунду
            }
        }
    }

    private void ShowDeathMessage()
    {
        if (deathMessageText != null)
        {
            deathMessageText.text = "Ты умер!";
            deathMessageText.color = Color.red;  // Красный цвет текста
            deathMessageText.gameObject.SetActive(true);  // Показываем сообщение
        }
    }

    private void Teleport()
    {
        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;
            Debug.Log($"{gameObject.name} был телепортирован на точку Respawn!");
        }
        else
        {
            Debug.LogError("Ошибка: Точка Respawn не установлена.");
        }

        // Скрыть сообщение после телепортации
        if (deathMessageText != null)
        {
            deathMessageText.gameObject.SetActive(false);
        }

        // Сброс флага смерти
        isDead = false;
    }
}
