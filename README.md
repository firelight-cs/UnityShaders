# UnityShaders
> [!NOTE]
> * In this repository I store shaders I wrote in Unity or shaders I found in the internet
> 
> * These shaders stored in `.shadergraph` format, so you can easily import them to Unity
>
> * Each shader has parameters that can be modified to suit a specific case
>
> * In Unity you need to apply `.shadergraph` to material and this material apply to object to see shader
>
> * Some shaders depend on light in scene (Lit) and some shaders not (Unlit). There are shaders that can be applied to your render pass in render pipeline as a render feature (Fullscreen shaders)
>
> * Some shaders require subgraphs, you can find them in `/Bubgraphs` directory


-----------
## Lit Shaders
### Alpha Threshold
![Movie018](https://github.com/user-attachments/assets/f34823bf-33f2-43e5-a5cb-6b4a4bc81f20)

Can be useful, if you have sprite with background that should be transparent
 
---
### Dissolve Shader
![Movie012](https://github.com/user-attachments/assets/3c25abb4-0050-4841-a045-ee3e1011e2b6)

The most recognizable shader. For this shader I created 2 scripts: 

* <b>DissolveAnimation.cs</b> - When you apply `DissolveAnimation.cs` to an object it allows to control animations for dissolve: appear, disappear, ping-pong. You can also adjust speed and padding in case your object doesn't appear/disppear fully
* <b>DissolveEditor.cs</b> - add buttons to Editor. Just import it in your project


---
### Cel Shader
![Movie009](https://github.com/user-attachments/assets/7531df0e-f6e2-44f1-ab98-6521a892ed7c)

---
### Dithering Shader
![Movie013](https://github.com/user-attachments/assets/95aeb953-59c5-4814-9d2a-f3f6646ea307)

When you decrease transparency, appears dithering

---

### Silhouette Shader
![Movie016](https://github.com/user-attachments/assets/9ec8144d-7b45-47df-a072-d6d8b585479e)

It can be useful as a mask that only shows objects when you look through it

---
### Halftone Shader
![Movie024](https://github.com/user-attachments/assets/c9f38d41-1dcb-41b8-84f2-ea49f5aa3a58)

Shader that simulates a dithering effect for shadows

---
### Wave Vertex Shader (with foam)
![Movie020](https://github.com/user-attachments/assets/456287b4-6196-475b-b6b3-e71a8a2449cd)

Vertex shader. You can apply a texture to make foams

---
### Dot Matrix Shader
![Movie017](https://github.com/user-attachments/assets/e634b37f-0c7c-4bfe-9de8-e34460c679b3)

---
### Intersection Occlusion (Ambient Occlusion)
![Movie026](https://github.com/user-attachments/assets/046d99be-9683-47c1-ac99-f9cf0d8fc35f)

Creates shadow at the boundaries of intersection

---
### Glowing Intersection
![Movie032](https://github.com/user-attachments/assets/f064fec1-b227-48a5-8cbd-20d3ef2b8416)

Creates glowing at the boundaries of intersection, but depends on object's UV

---

## Unlit Shaders
### Fresnel Shader
![Movie014](https://github.com/user-attachments/assets/19c9cf95-6b91-43f4-81bc-8d49002db847)

Cool and versatile effect that can be used everywhere

---

### Balatro background Shader
![Movie022](https://github.com/user-attachments/assets/c79b6078-88d5-4ccb-b625-0e8fe9cd4c17)

Inspired by balatro background. To make shader more explicit you should apply a texture in editor (e.g. gradient)

---

### Portal Shader
![Movie023](https://github.com/user-attachments/assets/272bf830-745d-4a75-873b-4171ff4f1d2a)

Apply a texture in editor

---


## Fullscreen Shaders 
>[!WARNING]
> These shaders can only be applied into your render pipeline (URP, HDRP)
>
> Find your renderer (by default it's `PC_Renderer`)
>
> Add renderer feature -> Full Screen Pass Renderer Feature -> Add a metarial into `Pass Material`

### Grey scale Shader
![Movie033](https://github.com/user-attachments/assets/eeccc9c7-7489-41ba-803d-ef83ccfecb3c)

Well, it makes the image grey...

---

### Outline Shader
![Movie034](https://github.com/user-attachments/assets/829633de-29dc-42ae-9b8a-3f4ac688f4ec)

Outlines objects 

---

### Outline + Halftone (mix)
![Movie036](https://github.com/user-attachments/assets/2fa5a6a8-4977-4454-b213-82ae4b07849a)

Halftone applied to objects, outline applied to render pass

---

### Dithering
![Movie038](https://github.com/user-attachments/assets/92447289-595b-4aa3-b5c7-b2571539cb50)


---

### Dithering 1-bit
![Movie037](https://github.com/user-attachments/assets/699324d0-ab30-4036-939b-2b4c18431d5f)



---

## TOBEFIXED shaders
    1. Outline per object shader
