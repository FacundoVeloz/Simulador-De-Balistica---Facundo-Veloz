Requisitos mínimos:

Controles de disparo en pantalla:
Ángulo y fuerza con Slider o InputField.
Masa del proyectil seleccionable

Disparo físico:
Proyectil con Rigidbody y Collider.
Lanzamiento por AddForce o velocity según el ángulo configurado.

Escena de objetivos:
Estructuras armadas con Rigidbodies y Joints (FixedJoint, HingeJoint o SpringJoint).
Estabilidad inicial correcta. Si se cae sola, está mal configurada.

Registro del resultado:
Guardar datos como tiempo de vuelo, punto de impacto, velocidad relativa, impulso de colisión y piezas derribadas.
Mostrar al final de cada intento: puntuación y un breve “reporte de tiro”.

Como jugar?:

Panel de control:
Slider ángulo y: Sirve para subir y bajar el cañon del arma.
Slider ángulo x: Sirve para girar hacia la izquierda o derecha el arma.
Slider fuerza: Sirve para cambiar la fuerza de disparo. Valor min.:0, valor max.: 300.
Slider peso: Sirve para cambiar el peso de la bala. Valor min.:1kg, Valor maz.: 20kg.

Panel de registro:
Botón de panel de registro: Sirve para desplegar o guardar el panel de Registro, que marca elementos tales como la velocidad del proyectil, el punto de impacto, la fuerza de impacto, entre otros.
Botón de Guardar: Permite guardar la información de disparo.
Botón de Cargar: Permite cargar los datos del disparo anteriormente guardado.

Otros elementos de UI:
Botón cámara: Sirve para cambiar la perspectiva de las cámaras auxiliares.
Botón reinicio: Sirve para reiniciar la escena.

Versión de Unity:
6000.3.23f1

Video GamePlay:
https://www.youtube.com/watch?v=7-zPcHPhfTg
