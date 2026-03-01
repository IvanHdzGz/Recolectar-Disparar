# Roll A Ball – Survival Edition

Proyecto desarrollado en Unity basado en el tutorial clásico "Roll A Ball", expandido con nuevas mecánicas de combate y respawn del enemigo.

---

## Idea Principal

El jugador controla una esfera en tercera persona con cámara libre.  
Debe recolectar una cantidad determinada de objetos mientras es perseguido por un enemigo con inteligencia artificial.

El jugador puede disparar para eliminar temporalmente al enemigo, que reaparece después de 5 segundos en una posición aleatoria del mapa.

---

## Mecánicas Implementadas

- Movimiento relativo a la cámara
- Cámara libre con mouse
- Sistema de salto y gravedad
- Enemigo con NavMeshAgent
- Sistema de disparo con proyectiles físicos
- Eliminación temporal del enemigo
- Sistema de salud del jugador
- Sistema de victoria al recolectar todos los objetos
- Sistema de derrota si el enemigo atrapa al jugador

---

## Tecnologías Utilizadas

- Unity
- C#
- Input System (nuevo)
- NavMesh
- Rigidbody Physics

---

## Estructura del Proyecto

Scripts principales:

- PlayerController.cs
- MouseCameraController.cs
- Bullet.cs
- EnemyMovement.cs
- EnemyRespawn.cs

---

## Posibles Mejoras Futuras

- Múltiples enemigos
- Sistema de oleadas
- Barra de energía o munición limitada
- Spawn points dinámicos
- Menú principal y UI avanzada

---

- Programación orientada a componentes
- Sistemas de física
- IA básica
- Arquitectura modular en Unity
