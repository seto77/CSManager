# Átomos

En la pestaña `Info. átomos` se muestra y configura la información de los átomos que contiene el cristal. En la lista superior se muestra la relación de átomos y, al hacer clic en cada átomo, su información detallada aparece en la parte inferior.

!!! warning
    Después de editar un átomo, pulse el botón `Add` o `Replace`. Si no lo hace, la información del átomo no se guardará en la lista.

## Operaciones con la lista de átomos

- `Add` — Añade a la lista como nuevo el átomo configurado.
- `Replace` — Sustituye el átomo seleccionado actualmente por el átomo configurado.
- `Up` / `Down` — Mueve hacia arriba o hacia abajo el orden del átomo seleccionado.
- `Delete` — Elimina de la lista el átomo seleccionado.

## Elemento y posición

- `Label` — Introduce la etiqueta del átomo.
- `Element` — Configura el elemento.
- `X`, `Y`, `Z` — Configura las coordenadas fraccionarias del átomo. Introduzca un número real entre 0 y 1. También puede introducir fracciones como 1/2 o 2/3.
- `Occ` — Especifica la ocupación con un número real entre 0 y 1.

En **Origin shift** puede desplazar la posición del origen con los botones predefinidos o con un valor arbitrario.

## Factor de temperatura (Debye-Waller factor)

- **Notation** — Seleccione `U` o `B`.
- **Model** — Seleccione isótropo (Isotropy) o anisótropo (Anisotropy).
- Introduzca cada componente del factor de temperatura (`B##` o `U##`).

## Factor de dispersión (Scattering factor)

Configura la valencia y la composición isotópica que se usan al calcular el factor de dispersión atómica.

- **X-ray** — Selecciona la valencia que se usa para calcular el factor de dispersión atómica elástica frente a los rayos X. Los parámetros se basan en *International Tables for Crystallography volume C*.
- **Electron** — Selecciona la valencia del factor de dispersión atómica elástica frente al haz de electrones. Los parámetros se basan en Peng (1998, *Acta Cryst.* A54, 481-485).
- **Neutron** — Selecciona la composición isotópica para calcular la longitud de dispersión elástica de neutrones. Puede elegir `Natural isotope abundance` (abundancia isotópica natural) o `Custom isotope abundance` (configuración personalizada).
