# Desafío 2 Desarrollo de Software Empresarial

## Integrantes
- José Roberto Doradea Herrera  
- Carlos Alexander Alvarenga Claros  
- Enrique Moreno Lozano  

---

## Descripción
Este proyecto implementa un sistema para la **gestión de eventos, participantes y organizadores**, desarrollado en **.NET Core 9.0** con soporte de **Entity Framework/Dapper** y desplegado en **contenedores Docker**.  

La solución incluye:
- **API REST** con operaciones CRUD para eventos, participantes y organizadores.  
- **Validaciones** de datos en cada entidad.
- **API Gateway con Ocelot** para centralizar el acceso a los servicios.  
- **Swagger** habilitado en la API y en el Gateway para documentar los endpoints.  
- **Rate limiting** configurado (10 peticiones por minuto por endpoint).  
- **Caché** en el Gateway (20 segundos por endpoint).  
- **Orquestación con Docker Compose** para levantar API, Gateway, SQL Server y Redis.  

---



