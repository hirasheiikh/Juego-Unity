# 🎮 Juego-Unity — 2D Platformer Adventure

[![Unity](https://img.shields.io/badge/Unity-2022.3%20LTS-black?style=flat&logo=unity)](https://unity.com/)
[![C#](https://img.shields.io/badge/Language-C%23-239120?style=flat&logo=csharp)](https://docs.microsoft.com/en-us/dotnet/csharp/)
[![Render Pipeline](https://img.shields.io/badge/Pipeline-URP%202D-informational?style=flat)](https://unity.com/srp/Universal-Render-Pipeline)
[![License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

Videojoc de plataformes 2D desenvolupat en **Unity** i **C#**, dissenyat amb físiques dinàmiques personalitzades, sistema de càmera i fons parallax multicapa, màquines d'estats d'animació, IA modular d'enemics i 6 transformacions úniques (power-ups) al llarg de 5 mons temàtics.

---

## 🌟 Característiques Principals

- **5 Nivells Temàtics Progressius**: Des de metròpolis urbanes fins a cims nevats amb mecàniques pròpies de cada bioma.
- **6 Power-Ups Dinàmics**: Transformacions visuals completes de sprites (cap, braços, cames i tors) amb noves habilitats actives i passives.
- **Físiques 2D & Control Precís**: Moviment basat en `Rigidbody2D`, acceleració controlada, salt predictiu i detecció precisa del terra mitjançant `Physics2D.Raycast`.
- **Efecte Parallax Immersiu**: Sistema de càmera multicapa (`ParallaxLayer`, `ParallaxCamera`) que atorga sensació de profunditat a l'escena.
- **Intel·ligència Artificial Modular**: Enemics amb patrulla autònoma (`EnemyWalk`), persecució activa del jugador (`Chase`), atac especial (`PenguinSpin`) i gestió de mal (`DamageEnemy`).
- **HUD & Gestor Global**: HUD interactiu amb barra de vida dinàmica (`HealthBar`), menú de pausa i canvi d'escenes fluid (`GameManager`, `SceneChange`).

---

## 🗺️ Els 5 Nivells

| Nivell | Escena | Descripció |
| :--- | :--- | :--- |
| 🏙️ **Ciutat** | `NivelCiudad.unity` | Introducció a les mecàniques bàsiques, plataformes industrials i enemics urbans. |
| 🏜️ **Desert** | `NivelDesierto.unity` | Terreny àrid, dunes, escarabats hostils i plataformes suspeses. |
| 🌴 **Jungla** | `NivelJungla.unity` | Disseny vertical ple de vegetació, mantis religioses i plantes carnívores. |
| 🏔️ **Muntanya** | `NivelMountain.unity` | Precipicis exigents, plataformes rocoses i proves de precisió en el salt. |
| ❄️ **Neu** | `NivelNieve.unity` | Clímax final amb superfícies gelades, pingüins giratoris i màxima dificultat. |

---

## ⚡ Sistema de Power-Ups

El personatge principal (`Monito`) canvia dinàmicament d'aparença i atributs en recollir cadascun dels ítems:

| Power-Up | Icona / Efecte | Habilitat Atorgada |
| :--- | :---: | :--- |
| **Hielo** | ❄️ | Llançament de projectils congelants (`bolaHielo`) que aturen i danyen enemics. |
| **Fuego** | 🔥 | Trets ignis a distància (`bolaFuego`) per eliminar obstacles i enemics. |
| **Salto** | 🦘 | Increment notable de la força d'impuls vertical (`jumpSpeedPowerUp`). |
| **Estrella** | ⭐ | Velocitat supersònica (`speedEstrella`) amb estela de partícules i tret especial. |
| **Grande** | 🍄 | Multiplicador d'escala física i massa corporal per trencar barreres. |
| **Superman** | 🦸 | Invulnerabilitat total al mal (`hp` protegit) i capacitat de vol continu. |

---

## 🕹️ Controls del Joc

| Acció | Tecles |
| :--- | :--- |
| **Moure's a l'esquerra / dreta** | `A` / `D` o `←` / `→` |
| **Saltar** | `Espai` o `W` / `↑` |
| **Disparar (amb Power-Up actiu)** | `Clic Esquerre` o `Ctrl` / `K` |
| **Menú de Pausa** | `Esc` o `P` |

---

## 🏗️ Arquitectura del Codi (`Assets/Scripts/`)

- `Monito.cs`: Controlador central del jugador (físiques, raycasts, canvis d'estat de sprites i timers de power-up).
- `PowerUps.cs`: Detecció de col·lisions (`OnCollisionEnter2D`) i activació d'habilitats a través del `GameManager`.
- `GameManager.cs`: Singleton gestor de l'estat del joc, referències globals i flux de vida.
- `HealthBar.cs`: Renderitzat i actualització de la interfície de salut del personatge.
- `Enemy.cs` / `EnemyWalk.cs`: Comportament base dels enemics terrestres i patrullatge amb canvi de sentit.
- `Chase.cs`: Vector de persecució basat en la proximitat i línia de visió vers el jugador.
- `ParallaxBackground.cs` / `ParallaxCamera.cs`: Desplaçament diferencial de capes de fons per crear profunditat 2D.
- `SceneChange.cs` / `ButtonManager.cs`: Gestió d'esdeveniments d'UI, reinici de nivells i flux entre escenes.

---

## 🚀 Com Executar el Projecte

1. **Clonar el repositori**:
   ```bash
   git clone https://github.com/hirasheiikh/Juego-Unity.git
   ```

2. **Obrir amb Unity Hub**:
   - Versió recomanada: **Unity 2022.3 LTS** (o qualsevol versió compatible amb Universal RP 2D).
   - Fes clic a **Add project from disk** i selecciona la carpeta arrel del projecte.

3. **Iniciar el joc**:
   - Dins la finestra `Project`, ves a `Assets/Scenes/`.
   - Obre `NivelCiudad.unity` (o `SampleScene.unity`).
   - Prem el botó **Play ▶️** a la part superior de l'editor.

---

## 👥 Autors

Projecte desenvolupat col·laborativament per:
- **Hira Sheikh Ahmed** ([@hirasheiikh](https://github.com/hirasheiikh))
- **M. Grandolfi** ([@mgrandolfi](https://github.com/mgrandolfi))
