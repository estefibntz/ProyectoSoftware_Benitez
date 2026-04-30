# Sistema de Ticketing

Aplicación para visualizar eventos y reservar asientos.

---

## Tecnologías

* Backend: ASP.NET Core, Entity Framework
* Frontend: HTML, CSS, JS

---

## Cómo ejecutar el proyecto

### 1. Clonar el repositorio


https://github.com/estefibntz/ProyectoSoftware_Benitez.git


---

### 2. Abrir el proyecto

Abrir la solución del backend en Visual Studio.

---

### 3. Configurar la base de datos

Verificar la cadena de conexión en:


appsettings.json


Ejemplo:

"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=TicketingDB;Trusted_Connection=True;"
}

---

### 4. Ejecutar migraciones

En la consola de Visual Studio:


Update-Database

---

### 5. Ejecutar el backend

Presionar:
F5

El backend se ejecuta en:


https://localhost:7172


Swagger disponible en:

https://localhost:7172/swagger


---

### 6. Abrir el frontend

Ir en el navegador a:


https://localhost:7172/index.html


---

## Uso del sistema

1. Ver eventos
2. Ver mapa de asientos
3. Hacer click en un asiento disponible para reservar

---

## Estados de los asientos

* Verde: Disponible
* Naranja: Reservado
* Rojo: Vendido
