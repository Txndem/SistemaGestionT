# \# Spec Driven Development

# 

# \## Funcionalidad: Registro de Equipos

# 

# \### Descripción

# Permite registrar los equipos participantes en el torneo de eSports.

# 

# \### Entradas

# \- Código

# \- Nombre del equipo

# \- País del equipo

# \- Lista de jugadores dentro del equipo

# \- Coach

# 

# \### Reglas de Negocio

# \- El código, nombre del equipo y país es obligatorio.

# \- No se permite tener los mismos jugadores de un equipo en otro.

# \- El equipo puede registrarse aun sin tener sus jugadores definidos.

# 

# \### Salidas

# \- Confirmación de registro exitoso.

# \- Almacenamiento de la información del equipo.

# 

# \### Criterios de Aceptación

# \- El sistema registra correctamente un equipo válido.

# \- El sistema muestra un mensaje de error si faltan datos obligatorios.

# \- El sistema impide registrar equipos duplicados.

