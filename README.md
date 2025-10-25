🌌 Aether Weaver
A thrilling 2D Roguelite Action-RPG where you harness elemental forces and strategically weave ability shards to master the ever-changing, minimalist dungeons of the Aether.

🎮 Gameplay Overview
In Aether Weaver, you are a solitary entity descending into a series of procedurally generated chambers. The core of the game lies in its Ability Weaving System: Defeat geometric enemies to earn Aether Shards (abilities) and strategically slot them onto your grid. The synergy created by placing specific shards next to each other creates powerful, run-defining builds. Death is inevitable, but every run contributes to persistent meta-progression, unlocking new Shards and starting bonuses for the next attempt.

✨ Key Features (Initial Scope)
Roguelite Run Structure: Highly replayable, session-based runs with permanent death and persistent meta-progression.

Ability Weaving System: A strategic grid-based mechanic for combining abilities and elemental effects into powerful synergies.

Simple, High-Impact Visuals: Minimalist, geometric art style enhanced by dazzling VFX (particle effects) to maximise visual return on minimal artistic effort.

Procedural Generation: Randomly generated dungeon layouts and enemy encounters for unique challenges in every run.

🛠️ Technology Stack
Game Engine: Unity (targeting 6.2)

Programming Language: C#

UI System: UI Toolkit (Industry Standard)

Input System: New Input System (Industry Standard)

Data Management: Extensive use of ScriptableObjects (SOAP Variables).

🗺️ Development Roadmap
This project will follow a phased development plan focused on establishing the core loops first. The current focus is on Phase 1.

[ ] 💡 Phase 0: Project Conception & Foundation

[ ] Initial Game Design & Concept

[ ] GitHub Repository Setup

[ ] ⚙️ Phase 1: Core Movement & Input

[ ] Implement New Input System Integration

[ ] PlayerMovement Component with PlayerMoveSpeedSOAP

[ ] Implement Dash action and cooldown system.

[ ] ⚔️ Phase 2: Combat & Core Loop

[ ] Implement Basic Enemy (The RedSquare) and movement AI.

[ ] Implement Player Primary Attack (Simple projectile).

[ ] Implement Player Health and Enemy Damage system.

[ ] Implement Enemy Death and Loot Drop (XP and base AetherShard).

[ ] 🌐 Phase 3: Roguelite Structure

[ ] Implement Basic Procedural Dungeon Generation (Room connections).

[ ] Implement Run Reset and Persistent Currency System.

[ ] Implement Ability Weaving Grid (UI Toolkit).

[ ] 🎉 Phase 4: Content & Polish

[ ] Implement 5 distinct Aether Shards and 3 Synergy Effects.

[ ] Implement 3 unique enemy types.

[ ] Final UI/UX Integration using UI Toolkit.

[ ] Initial Audio Implementation (SFX/Music).

🤝 How to Contribute
This project follows the GitFlow branching model (simplified).

The main branch contains the latest stable release.

The develop branch is the active development branch.

All new work must be done on a feature branch (e.g., feature/implement-healing-shard).

Once a feature is complete, submit a Pull Request (PR) to merge into develop. PRs will be reviewed before merging.
