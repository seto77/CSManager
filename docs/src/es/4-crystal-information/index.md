---
title: Información de cristales
---

# Información de cristales

En el área de información de cristales (el control `Crystal Information`) se muestran y editan los parámetros de celda, la simetría, las posiciones atómicas, la referencia bibliográfica, etc. del cristal seleccionado. También puede cargar cualquier cristal arrastrando y soltando en esta área un archivo CIF o AMC.

!!! warning "Confirme los cambios con `Añadir` / `Reemplazar`"
    Si realiza algún cambio en el cristal, pulse siempre el botón `Añadir` o `Reemplazar`. Si no lo hace, los cambios no se guardarán en la tabla de la base de datos y se perderán.

En la parte superior se muestra información común como el nombre del cristal (`Name`) y la composición química (`Formula`), y con `Reset` puede reiniciar toda la información del cristal. En la parte inferior hay una serie de pestañas para configurar la simetría, los átomos, la referencia bibliográfica, etc.

## Pestañas

- [Información básica](1-basic-information.md) — Parámetros de celda, simetría, volumen, densidad, etc. (pestaña `Info. básica`)
- [Átomos](2-atoms.md) — Posiciones atómicas, ocupación, factor de temperatura, factor de dispersión (pestaña `Info. átomos`)
- [Enlaces y poliedros de coordinación](3-bonds-polyhedra.md) — Ajustes de representación de enlaces y poliedros de coordinación (pestaña `Enlaces y poliedros`)
- [Referencias](4-references.md) — Información de la referencia bibliográfica (pestaña `Ref.`)

## Menú contextual

Al hacer clic con el botón derecho en una zona vacía del control, puede realizar las siguientes operaciones.

- `Importar desde CIF o AMC...` — Importa la estructura cristalina en formato CIF / AMC.
- `Exportar a CIF` — Exporta el cristal actual en formato CIF.
- `Send this crystal to other software` — Envía el cristal seleccionado a PDIndexer, ReciPro u otros programas.
- `Información de simetría` — Abre una ventana con detalles sobre la simetría (número de orden del grupo espacial, grupo de Laue y grupo puntual, reglas de presencia, posición de Wyckoff, cálculos geométricos de planos cristalinos y ejes de zona, etc.).
- `Revertir constantes de celda` — Restablece los parámetros de celda a los valores que tenían justo después de cargar el cristal.
- `Convertir al grupo espacial P1` / `Convertir en una superestructura` / `Cambiar la configuración de ejes/origen` — Realiza conversiones del grupo espacial o de la red.
