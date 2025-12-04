📘 Sistema de Gestión de Estudiantes (C# .NET – Consola)

Un sistema CRUD (Crear, Leer, Actualizar, Eliminar) para gestionar estudiantes, desarrollado en C#, utilizando Programación Orientada a Objetos y persistencia en archivos JSON para mantener los datos incluso después de cerrar la aplicación.

Este proyecto fue creado con fines educativos, ideal para portafolio o prácticas de POO y manejo de archivos.

📌 Características principales

✅ Agregar nuevos estudiantes
✅ Listar todos los estudiantes
✅ Buscar estudiante por matrícula
✅ Editar información de un estudiante
✅ Eliminar estudiantes
✅ Validación completa de datos (edad, matrícula duplicada, promedio, campos vacíos, etc.)
✅ Persistencia de información utilizando JSON

Carga automática al iniciar

Guardado automático al modificar datos

🧱 Arquitectura del proyecto

El sistema está estructurado utilizando principios de POO:

📂 Clases:

Persona
Clase base con: Nombre, Apellido, Edad, Ciudad.

Estudiante (hereda de Persona)
Contiene: Carrera, Matrícula, Promedio.

EstudianteService
Responsable del CRUD y manejo de archivos JSON.

Program.cs
Contiene el menú de consola que interactúa con el usuario.

💾 Persistencia de datos (JSON)

Los estudiantes se guardan en un archivo:

estudiantes.json


El sistema:

✔ Carga automáticamente el archivo al iniciar
✔ Guarda automáticamente cada vez que agregas, editas o eliminas un estudiante

Esto permite que la información no se pierda al cerrar la consola.

▶️ Cómo ejecutar el proyecto

Clona el repositorio:

git clone https://github.com/RolandoManon/Sistema-de-Gestion-de-Estudiantes


Abre la solución en Visual Studio o VS Code.

Ejecuta el proyecto presionando F5.

El menú principal te mostrará las opciones disponibles.

🖼 Ejemplo del menú
Sistema de Estudiantes

1. Agregar Estudiante
2. Mostrar Estudiantes
3. Buscar estudiante por matrícula
4. Editar estudiante
5. Eliminar estudiante
6. Salir
Seleccione una opción:

🎯 Objetivo educativo

Este proyecto te ayuda a practicar:

Programación Orientada a Objetos (POO)

Herencia y encapsulación

Manejo de listas y colecciones

Validaciones de datos

JSON con System.Text.Json

Persistencia básica de información

Lógica de consola y manejo de menú

Excelente para incluir en tu portafolio como evidencia de tus conocimientos en C#.

📌 Futuras mejoras (ideas)

Implementar un menú más interactivo

Manejar excepciones globalmente con try/catch

Exportar datos a CSV

Agregar filtros (por carrera, ciudad, rango de promedios)

Crear una versión con Windows Forms o WPF

👨‍💻 Autor

Rolando Manón
Proyecto creado para fines educativos y práctica en C#.
